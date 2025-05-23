namespace VSCars.Page
{
    public partial class AtualizacaoModelosPage : ContentPage
    {
        public AtualizacaoModelosPage(string idModelo, string nomeModelo, string observacao)
        {
            InitializeComponent();

            txtIDModelo.Text = idModelo;
            txtNomeModelo.Text = nomeModelo;
            txtObservacao.Text = observacao;
        }

        private async void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                await DisplayAlert("Erro", "Preencha todos os campos obrigatórios!", "OK");
                return;
            }

            var modeloAtualizado = new Modelo
            {
                ID = int.Parse(txtIDModelo.Text),
                Nome = txtNomeModelo.Text,
                Observacao = txtObservacao.Text
            };

            await DisplayAlert("Sucesso", $"Modelo '{modeloAtualizado.Nome}' atualizado com sucesso!", "OK");

            await Navigation.PopAsync();
        }

        private bool ValidarCampos()
        {
            return !string.IsNullOrWhiteSpace(txtIDModelo.Text) &&
                   !string.IsNullOrWhiteSpace(txtNomeModelo.Text);
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}