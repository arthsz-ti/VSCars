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

            // Simulação de atualização do veículo (substituir por lógica real)
            await DisplayAlert("Sucesso", "Veículo atualizado com sucesso!", "OK");

            // Voltar para a página anterior após a atualização
            await Navigation.PopAsync();
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // Retorna para a página anterior
        }
    }
}

