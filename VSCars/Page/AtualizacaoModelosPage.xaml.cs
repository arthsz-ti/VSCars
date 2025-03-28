namespace VSCars.Page
{
    public partial class AtualizacaoModelosPage : ContentPage
    {
        public AtualizacaoModelosPage(string idModelo, string nomeModelo, string observacao)
        {
            InitializeComponent();

            // Preenche os campos com os dados passados
            txtIDModelo.Text = idModelo;
            txtNomeModelo.Text = nomeModelo;
            txtObservacao.Text = observacao;
        }

        private async void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIDModelo.Text) || string.IsNullOrWhiteSpace(txtNomeModelo.Text))
            {
                await DisplayAlert("Erro", "Preencha o ID e o Nome do Modelo!", "OK");
                return;
            }

            // Simula��o de atualiza��o do modelo (substituir por l�gica real)
            await DisplayAlert("Sucesso", "Modelo atualizado com sucesso!", "OK");

            // Voltar para a p�gina anterior ap�s a atualiza��o
            await Navigation.PopAsync();
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // Retorna para a p�gina anterior
        }
    }
}