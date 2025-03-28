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

            // Simulação de atualização do modelo (substituir por lógica real)
            await DisplayAlert("Sucesso", "Modelo atualizado com sucesso!", "OK");

            // Voltar para a página anterior após a atualização
            await Navigation.PopAsync();
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // Retorna para a página anterior
        }
    }
}