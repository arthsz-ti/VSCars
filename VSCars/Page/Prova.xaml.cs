namespace VSCars.Page;

public partial class Prova : ContentPage
{
    public Prova()
    {
        InitializeComponent();
    }

    private async void btnVoltarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}
