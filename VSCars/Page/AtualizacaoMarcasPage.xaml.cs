namespace VSCars.Page
{
    public partial class AtualizacaoMarcasPage : ContentPage
    {
        public AtualizacaoMarcasPage(string idMarca, string nomeMarca, string observacao)
        {
            InitializeComponent();

            txtIDMarca.Text = idMarca;
            txtNomeMarca.Text = nomeMarca;
            txtObservacao.Text = observacao;
        }

        private async void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                await DisplayAlert("Erro", "Preencha todos os campos obrigatórios!", "OK");
                return;
            }

            var marcaAtualizada = new Marca
            {
                ID = int.Parse(txtIDMarca.Text),
                Nome = txtNomeMarca.Text,
                Observacao = txtObservacao.Text
            };

            await DisplayAlert("Sucesso", $"Marca '{marcaAtualizada.Nome}' atualizada com sucesso!", "OK");

            // Navegar de volta para a lista
            await Navigation.PopAsync();
        }

        private bool ValidarCampos()
        {
            return !string.IsNullOrWhiteSpace(txtIDMarca.Text) &&
                   !string.IsNullOrWhiteSpace(txtNomeMarca.Text);
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}