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
                await DisplayAlert("Erro", "Preencha todos os campos obrigatórios!", "OK");
                return;
            }

            var novoModelo = new Modelo
            {
                ID = int.Parse(txtIDModelo.Text),  // Nome corrigido
                Nome = txtNomeModelo.Text,          // Nome corrigido
                Observacao = txtObservacao.Text
            };

            // Se estiver usando a abordagem do construtor:
            await Navigation.PushAsync(new ListViewModelos(novoModelo));

            // Ou se estiver usando MessagingCenter:
            // MessagingCenter.Send(this, "NovoModeloAdicionado", novoModelo);
            // await Navigation.PopAsync();
        }

        private bool ValidarCampos()
        {
            return !string.IsNullOrWhiteSpace(txtIDModelo.Text) &&
                   !string.IsNullOrWhiteSpace(txtNomeModelo.Text);
        }

        private async void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIDModelo.Text) || string.IsNullOrWhiteSpace(txtNomeModelo.Text))
            {
                await DisplayAlert("Erro", "Preencha o ID e o Nome do Modelo!", "OK");
                return;
            }

            await Navigation.PushAsync(new AtualizacaoModelosPage(
                txtIDModelo.Text,
                txtNomeModelo.Text,
                txtObservacao.Text
            ));
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}