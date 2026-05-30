namespace AppHotel
{
    public partial class MainPage : ContentPage
    {
        int quantidadeHospedes = 1;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            quantidadeHospedes = (int)e.NewValue;
            lblHospedes.Text = $"{quantidadeHospedes} Pessoa(s)";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string data = dateReserva.Date.Value.ToShortDateString();
            string? quarto = pickerQuarto.SelectedItem?.ToString();
            Hospede hospede = new Hospede();

            hospede.Nome = nome;

            hospede.QuantidadePessoas = quantidadeHospedes;

            hospede.Quarto = quarto;

            hospede.DataReserva = data;

            if (string.IsNullOrWhiteSpace(nome) || quarto == null)
            {
                await DisplayAlert("Aviso", "Preencha nome e selecione um quarto.", "OK");
                return;
            }

            await DisplayAlert(
                "Reserva Realizada",
                $"Hóspede: {hospede.Nome}\n" +
                $"Pessoas: {hospede.QuantidadePessoas}\n" +
                $"Data: {hospede.DataReserva}\n" +
                $"Quarto: {hospede.Quarto}",
                "OK");
        }

        private async void Sobre_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SobrePage());
        }
    }
}