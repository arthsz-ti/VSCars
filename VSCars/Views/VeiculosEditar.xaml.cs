namespace VSCars.Views;

using VSCars.Models;

public partial class VeiculosEditar : ContentPage
{
    public VeiculosEditar()
    {
        InitializeComponent();
    }

    private async void btnAlterar_Clicked(object sender, EventArgs e)
    {
        Veiculo v = new Veiculo();
        v.Codigo = int.Parse(txtCodigo.Text);
        v.Nome = txtNome.Text;

        await App.Db.UpdateVeiculo(v);
        await DisplayAlert("Atenção", "Veículo alterado!", "OK");
    }
}