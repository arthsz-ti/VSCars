namespace VSCars.Page
{
    public partial class AtualizacaoVeiculosPage : ContentPage
    {
        public AtualizacaoVeiculosPage(string idVeiculo, string nomeVeiculo, string anoFabricacao, string modelo)
        {
            InitializeComponent();

            // Preenche os campos com os dados passados
            txtIDVeiculo.Text = idVeiculo;
            txtNomeVeiculo.Text = nomeVeiculo;
            txtAnoFabricacao.Text = anoFabricacao;
            txtModelo.Text = modelo;
        }

        private async void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIDVeiculo.Text) || string.IsNullOrWhiteSpace(txtNomeVeiculo.Text))
            {
                await DisplayAlert("Erro", "Preencha o ID e o Nome do Veículo!", "OK");
                return;
            }

            // Aqui você pode adicionar a lógica para salvar as alterações no banco de dados

            // Mensagem de sucesso atualizada para incluir o nome do veículo
            await DisplayAlert("Sucesso", $"Veículo '{txtNomeVeiculo.Text}' atualizado com sucesso!", "OK");
            await Navigation.PopAsync();
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}