using Microsoft.Maui.Controls;

namespace VSCars.Page
{
    public partial class TaskSelection : ContentPage
    {
        public TaskSelection()
        {
            InitializeComponent();
        }

        private async void btnMarcasSelected_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MarcasPage());
        }

        private async void btnVeiculosSelected_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VeiculosPage());
        }

        private async void btnModelosSelected_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ModeloPage());
        }
    }
}
