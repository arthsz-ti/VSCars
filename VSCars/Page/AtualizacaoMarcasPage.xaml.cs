namespace VSCars.Page
{
    public partial class AtualizacaoMarcasPage : ContentPage
    {
        public AtualizacaoMarcasPage(string nomeMarca, string idMarca, string observacao)
        {
            InitializeComponent();

            // Preenche os campos com os dados recebidos
            txtNomeMarca.Text = nomeMarca;
            txtIDMarca.Text = idMarca;
            txtObservacao.Text = observacao;
        }

        private async void btnSalvarAlteracao_Clicked(object sender, EventArgs e)
        {
            // Aqui voc� pode implementar a l�gica para salvar os dados alterados
            await DisplayAlert("Sucesso", "Altera��es salvas com sucesso!", "OK");
            await Navigation.PopAsync(); // Volta para a p�gina anterior
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // Volta para a p�gina anterior
        }
    }
}
