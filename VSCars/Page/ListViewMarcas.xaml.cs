using System.Collections.ObjectModel;

namespace VSCars.Page
{
    public partial class ListViewMarcas : ContentPage
    {
        public ObservableCollection<Marca> Marcas { get; set; } = new ObservableCollection<Marca>();

        public ListViewMarcas()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public ListViewMarcas(Marca novaMarca) : this()
        {
            Marcas.Add(novaMarca);
        }

        private async void btnEditar_Clicked(object sender, EventArgs e)
        {
            var marca = (sender as Button)?.BindingContext as Marca;
            if (marca != null)
            {
                await Navigation.PushAsync(new AtualizacaoMarcasPage(
                    marca.ID.ToString(),
                    marca.Nome,
                    marca.Observacao
                ));
            }
        }

        private async void btnExcluir_Clicked(object sender, EventArgs e)
        {
            var marca = (sender as Button)?.BindingContext as Marca;
            if (marca != null && await DisplayAlert("Excluir", $"Excluir {marca.Nome}?", "Sim", "Não"))
            {
                Marcas.Remove(marca);
            }
        }
    }
}