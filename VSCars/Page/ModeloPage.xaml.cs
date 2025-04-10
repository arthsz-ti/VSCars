namespace VSCars.Page
{
    public partial class ModeloPage : ContentPage
    {
        public ModeloPage()
        {
            InitializeComponent();
        }

        private async void btnInserir_Clicked(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                await DisplayAlert("Erro", "Preencha todos os campos obrigatorios!", "OK");
                return;
            }

            var novoModelo = new Modelo
            {
                ID = int.Parse(txtIDModelo.Text),
                Nome = txtNomeModelo.Text,
                Observacao = txtObservacao.Text
            };

            await Navigation.PushAsync(new ListViewModelos(novoModelo));

        }

        private bool ValidarCampos()
        {
            return !string.IsNullOrWhiteSpace(txtIDModelo.Text) &&
                   !string.IsNullOrWhiteSpace(txtNomeModelo.Text);
        }

        private async void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                await DisplayAlert("Erro", "Preencha o ID e o Nome do Modelo!", "OK");
                return;
            }

            var modeloEditavel = new Modelo
            {
                ID = int.Parse(txtIDModelo.Text),
                Nome = txtNomeModelo.Text,
                Observacao = txtObservacao.Text
            };

            await Navigation.PushAsync(new AtualizacaoModelosPage(
                modeloEditavel.ID.ToString(),
                modeloEditavel.Nome,
                modeloEditavel.Observacao
            ));
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//TaskSelectionPage");
        }
    }
}
