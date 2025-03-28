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

            var novoVeiculo = new Veiculo
            {
                ID = int.Parse(txtIDVeiculo.Text),
                Nome = txtNomeVeiculo.Text,
                Ano = int.Parse(txtAnoFabricacao.Text),
                Modelo = txtObservacao.Text
            };

            // Envia o veículo para a ListViewVeiculosPage via MessagingCenter
            MessagingCenter.Send(this, "NovoVeiculoAdicionado", novoVeiculo);

            await Navigation.PopAsync(); // Volta para a página anterior
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtIDVeiculo.Text = "";
            txtNomeVeiculo.Text = "";
            txtAnoFabricacao.Text = "";
            txtObservacao.Text = "";
        }

        private bool ValidarCampos()
        {
            return !string.IsNullOrWhiteSpace(txtIDVeiculo.Text) &&
                   !string.IsNullOrWhiteSpace(txtNomeVeiculo.Text) &&
                   !string.IsNullOrWhiteSpace(txtAnoFabricacao.Text);
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}