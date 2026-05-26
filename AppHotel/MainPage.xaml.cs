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

            if (string.IsNullOrWhiteSpace(nome) || quarto == null)
            {
                await DisplayAlert("Aviso", "Preencha todos os campos.", "OK");
                return;
            }

            await DisplayAlert(
                "Reserva Realizada",
                $"Hóspede: {nome}\n" +
                $"Pessoas: {quantidadeHospedes}\n" +
                $"Data: {data}\n" +
                $"Quarto: {quarto}",
                "OK");
        }

        private async void Sobre_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SobrePage());
        }
    }
}