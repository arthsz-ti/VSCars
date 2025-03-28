using System.Collections.ObjectModel;

namespace VSCars.Page
{
    public partial class ListViewModelosPage : ContentPage
    {
        public ObservableCollection<Veiculo> Veiculos { get; set; } = new ObservableCollection<Veiculo>();

        // Construtor padr�o (usado quando a p�gina � aberta sem dados)
        public ListViewModelosPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        // Construtor que recebe um novo ve�culo e o adiciona � lista
        public ListViewModelosPage(Veiculo novoVeiculo) : this()
        {
            Veiculos.Add(novoVeiculo);
        }

        private async void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            var veiculo = (sender as Button)?.BindingContext as Veiculo;
            if (veiculo != null)
                await Navigation.PushAsync(new AtualizacaoVeiculosPage(
                    veiculo.ID.ToString(),
                    veiculo.Nome,
                    veiculo.Ano.ToString(),
                    veiculo.Modelo
                ));
        }

        private async void btnDeletar_Clicked(object sender, EventArgs e)
        {
            var veiculo = (sender as Button)?.BindingContext as Veiculo;
            if (veiculo != null && await DisplayAlert("Excluir", $"Excluir {veiculo.Nome}?", "Sim", "N�o"))
                Veiculos.Remove(veiculo);
        }
    }

    public class Veiculo
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public string Modelo { get; set; }
    }
}
