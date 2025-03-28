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
                await DisplayAlert("Erro", "Preencha o ID e o Nome do Ve�culo!", "OK");
                return;
            }

            // Simula��o de atualiza��o do ve�culo (substituir por l�gica real)
            await DisplayAlert("Sucesso", "Ve�culo atualizado com sucesso!", "OK");

            // Voltar para a p�gina anterior ap�s a atualiza��o
            await Navigation.PopAsync();
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // Retorna para a p�gina anterior
        }
    }
}

