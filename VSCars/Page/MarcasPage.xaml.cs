namespace VSCars.Page
{
    public partial class MarcasPage : ContentPage
    {
        public MarcasPage() => InitializeComponent();

        private async void btnInserir_Clicked(object sender, EventArgs e)
        {
            string nomeMarca = txtNomeMarca.Text, idMarca = txtIDMarca.Text, observacao = txtObservacao.Text;

            if (string.IsNullOrWhiteSpace(nomeMarca) || string.IsNullOrWhiteSpace(idMarca))
            {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos!", "OK");
                return;
            }

            // Criar nova marca com os dados inseridos
            var novaMarca = new Marca
            {
                ID = int.Parse(idMarca),
                Nome = nomeMarca,
                Observacao = observacao
            };

            // Navegar para a ListViewMarcas passando a nova marca
            await Navigation.PushAsync(new ListViewMarcas(novaMarca));
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//TaskSelectionPage");
        }

        private async void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            string nomeMarca = txtNomeMarca.Text, idMarca = txtIDMarca.Text, observacao = txtObservacao.Text;

            if (string.IsNullOrWhiteSpace(nomeMarca) || string.IsNullOrWhiteSpace(idMarca))
            {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos!", "OK");
                return;
            }

            // Criar marca tempor�ria com os dados para edi��o
            var marcaEditavel = new Marca
            {
                ID = int.Parse(idMarca),
                Nome = nomeMarca,
                Observacao = observacao
            };

            await Navigation.PushAsync(new AtualizacaoMarcasPage(
                marcaEditavel.ID.ToString(),
                marcaEditavel.Nome,
                marcaEditavel.Observacao
            ));
        }
    }

    public class Marca
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }
    }
}