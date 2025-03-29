using Microsoft.Maui.Controls;

namespace VSCars.Page
{
    public partial class VeiculosPage : ContentPage
    {
        public VeiculosPage() : this("") { }

        public VeiculosPage(string idModelo)
        {
            InitializeComponent();
            txtIDVeiculo.Text = idModelo;
        }

        private async void btnAdicionar_Clicked(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                await DisplayAlert("Erro", "Preencha todos os campos!", "OK");
                return;
            }

            // Criar um novo veículo com os dados inseridos
            var novoVeiculo = new Veiculo
            {
                ID = int.Parse(txtIDVeiculo.Text),
                Nome = txtNomeVeiculo.Text,
                Ano = int.Parse(txtAnoFabricacao.Text),
                Modelo = lblModelo.Text // assumindo que lblModelo contém o modelo
            };

            // Navegar para a ListViewModelosPage passando o novo veículo
            await Navigation.PushAsync(new ListViewModelosPage(novoVeiculo));
        }

        private bool ValidarCampos()
        {
            return !string.IsNullOrWhiteSpace(txtIDVeiculo.Text) &&
                   !string.IsNullOrWhiteSpace(txtNomeVeiculo.Text) &&
                   !string.IsNullOrWhiteSpace(txtAnoFabricacao.Text);
        }

        private async void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                await DisplayAlert("Erro", "Preencha todos os campos!", "OK");
                return;
            }

            await Navigation.PushAsync(new AtualizacaoVeiculosPage(
                txtIDVeiculo.Text,
                txtNomeVeiculo.Text,
                txtAnoFabricacao.Text,
                lblModelo.Text));
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//TaskSelectionPage");
        }
    }
}