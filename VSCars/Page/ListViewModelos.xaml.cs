using System.Collections.ObjectModel;

namespace VSCars.Page
{
    public partial class ListViewModelos : ContentPage
    {
        public ObservableCollection<Modelo> Modelos { get; set; } = new ObservableCollection<Modelo>();

        // Construtor padrão
        public ListViewModelos()
        {
            InitializeComponent();
            BindingContext = this;
        }

        // Construtor que recebe um novo modelo
        // Construtor que recebe um novo modelo
        public ListViewModelos(Modelo novoModelo) : this()
        {
            Modelos.Add(novoModelo);
        }

        private async void btnEditar_Clicked(object sender, EventArgs e)
        {
            var modelo = (sender as Button)?.BindingContext as Modelo;
            if (modelo != null)
            {
                await Navigation.PushAsync(new AtualizacaoModelosPage(
                    modelo.ID.ToString(),
                    modelo.Nome,
                    modelo.Observacao
                ));
            }
        }

        private async void btnExcluir_Clicked(object sender, EventArgs e)
        {
            var modelo = (sender as Button)?.BindingContext as Modelo;
            if (modelo != null && await DisplayAlert("Excluir", $"Excluir {modelo.Nome}?", "Sim", "Não"))
            {
                Modelos.Remove(modelo);
            }
        }
    }

    public class Modelo
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }
    }
}