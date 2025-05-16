using VSCars.Models; 

namespace VSCars.Views;

public partial class MarcaEditar : ContentPage
{
    public MarcaEditar()
    {
        InitializeComponent();
    }

    private async void btnAlterar_Clicked(object sender, EventArgs e)
    {
        Marca p = new Marca();
        p.Codigo = int.Parse(txtCodigo.Text);
        p.Nome = txtNome.Text;

        await App.Db.Update(p);
        await DisplayAlert("Atenção", "Registro alterado!", "OK");
    }
}
