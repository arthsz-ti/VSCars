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
            // Aqui você pode implementar a lógica para salvar os dados alterados
            await DisplayAlert("Sucesso", "Alterações salvas com sucesso!", "OK");
            await Navigation.PopAsync(); // Volta para a página anterior
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // Volta para a página anterior
        }
    }
}
