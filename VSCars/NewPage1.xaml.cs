using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VSCars.Models;
using VSCars.Views;

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
            await DisplayAlert("Sucesso", "Registro Inserido.", "OK!");

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

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem selecionado = sender as MenuItem;
            Marca p = selecionado.BindingContext as Marca;

            bool confirma =
                await DisplayAlert("Atenção", "Confirma a remoção?", "Sim", "Não");

            if (confirma = true)
            {
                await App.Db.Delete(p.Codigo);
                await DisplayAlert("Aviso", "Registro removido", "OK");
                await carregarListaMarcas();
            }
        }

        private void lstmarcas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Marca p = e.SelectedItem as Marca;

            txtCodigo.Text = p.Codigo.ToString();
            if (p.Nome != null)
            {
                txtNome.Text = p.Nome.ToString();
            }

        }
        private void btnLimpar_Clicked(object sender, EventArgs e)
        {
            txtCodigo.Text = String.Empty;
            txtNome.Text = String.Empty;
        }

        private async void btnAlterar_Clicked(object sender, EventArgs e)
        {
            if (txtCodigo.Text == null)
            {
                await DisplayAlert("Atenção", "Campo Código obrigatório!", "OK");
            }
            else
            {
                if (txtNome.Text == null)
                {
                    await DisplayAlert("Atenção", "Campo Nome obrigatório!", "OK");
                }
                else
                {
                    Marca p = new Marca();
                    p.Codigo = int.Parse(txtCodigo.Text);
                    p.Nome = txtNome.Text;

                    await App.Db.Update(p);
                    await DisplayAlert("Atenção!", "Registro alterado", "OK");
                    await carregarListaMarcas();
                }
            }

        }
        private void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            MenuItem selecionado = sender as MenuItem;
            Marca p = selecionado.BindingContext as Marca;

            Navigation.PushAsync(new Views.MarcaEditar { BindingContext = p });
        }
    }

}
