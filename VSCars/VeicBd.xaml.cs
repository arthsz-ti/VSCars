using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VSCars.Models;
using VSCars.Views;
using Microsoft.Maui.Controls;

namespace VSCars
{
    public partial class VeicBd : ContentPage
    {
        ObservableCollection<Veiculo> lista = new ObservableCollection<Veiculo>();

        public VeicBd()
        {
            InitializeComponent();
            lstveiculos.ItemsSource = lista;
        }

        protected override async void OnAppearing()
        {
            await carregarListaVeiculos();
        }

        private async Task carregarListaVeiculos()
        {
            List<Veiculo> tmp = await App.Db.GetAllVeiculos();
            lista.Clear();
            foreach (Veiculo veiculo in tmp)
            {
                lista.Add(veiculo);
            }
        }

        private async void btnInserir_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                await DisplayAlert("Erro", "Por favor, informe o nome do veículo", "OK");
                return;
            }

            Veiculo veic = new Veiculo { Nome = txtNome.Text };
            await App.Db.InsertVeiculo(veic);
            await DisplayAlert("Sucesso", "Veículo Inserido.", "OK");
            await carregarListaVeiculos();
        }

        private async void txtsearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string q = e.NewTextValue;
            lista.Clear();
            List<Veiculo> tmp = await App.Db.SearchVeiculos(q);
            foreach (Veiculo veiculo in tmp)
            {
                lista.Add(veiculo);
            }
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            if (sender is MenuItem selecionado && selecionado.BindingContext is Veiculo v)
            {
                bool confirma = await DisplayAlert("Atenção", "Confirma a remoção?", "Sim", "Não");
                if (confirma)
                {
                    await App.Db.DeleteVeiculo(v.Codigo);
                    await DisplayAlert("Aviso", "Veículo removido", "OK");
                    await carregarListaVeiculos();
                }
            }
        }

        private void lstveiculos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Veiculo v)
            {
                txtCodigo.Text = v.Codigo.ToString();
                txtNome.Text = v.Nome;
            }
        }

        private void btnLimpar_Clicked(object sender, EventArgs e)
        {
            txtCodigo.Text = string.Empty;
            txtNome.Text = string.Empty;
        }

        private async void btnAlterar_Clicked(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCodigo.Text, out int codigo))
            {
                await DisplayAlert("Erro", "Código inválido", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                await DisplayAlert("Erro", "Por favor, informe o nome do veículo", "OK");
                return;
            }

            Veiculo v = new Veiculo
            {
                Codigo = codigo,
                Nome = txtNome.Text
            };

            await App.Db.UpdateVeiculo(v);
            await DisplayAlert("Sucesso", "Veículo alterado", "OK");
            await carregarListaVeiculos();
        }

        private void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            if (sender is MenuItem selecionado && selecionado.BindingContext is Veiculo v)
            {
                Navigation.PushAsync(new VeiculosEditar { BindingContext = v });
            }
        }
    }
}