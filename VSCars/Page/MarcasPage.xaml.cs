namespace VSCars.Page
{
    public partial class MarcasPage : ContentPage
    {
        public MarcasPage() => InitializeComponent();

        private async void btnInserir_Clicked(object sender, EventArgs e)
        {
            string nomeMarca = txtNomeMarca.Text, idMarca = txtIDMarca.Text, observacao = txtObservacao.Text;
            if (string.IsNullOrWhiteSpace(nomeMarca) || string.IsNullOrWhiteSpace(idMarca))
            {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos!", "OK");
                return;
            }
            await Navigation.PushAsync(new VeiculosPage(idMarca)); // Enviar o ID da marca para a tela de veículos
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new TaskSelection());

        private async void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            string nomeMarca = txtNomeMarca.Text, idMarca = txtIDMarca.Text, observacao = txtObservacao.Text;
            if (string.IsNullOrWhiteSpace(nomeMarca) || string.IsNullOrWhiteSpace(idMarca))
            {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos!", "OK");
                return;
            }
            await Navigation.PushAsync(new AtualizacaoMarcasPage(nomeMarca, idMarca, observacao));
        }
    }
}
