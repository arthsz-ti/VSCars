using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VSCars.Models;

namespace VSCars
{
    public partial class NewPage1 : ContentPage
    {
        ObservableCollection<Marca> lista = new ObservableCollection<Marca>();
        public NewPage1()
        {
            InitializeComponent();

            lstmarcas.ItemsSource = lista;
        }

        protected override async void OnAppearing()
        {
            await carregarListaMarcas();
        }

        private async Task carregarListaMarcas()
        {
            List<Marca> tmp = await App.Db.GetAll();

            lista.Clear();
            foreach (Marca marca in tmp)
            {
                lista.Add(marca);
            }
        }


        private async void btnInserir_Clicked(object sender, EventArgs e)
        {
            Marca mrc = new Marca();
            mrc.Nome = txtNome.Text;

            await App.Db.Insert(mrc);
            await DisplayAlert("Sucesso", "Registro inserido.", "OK!");
            await carregarListaMarcas();
        }

        private async void txtsearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string q = e.NewTextValue;

            lista.Clear();

            List<Marca> tmp = await App.Db.Search(q);
            foreach (Marca marca in tmp)
            {
                lista.Add(marca);
            }
        }
    }
}