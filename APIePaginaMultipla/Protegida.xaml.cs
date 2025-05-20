namespace APIePaginaMultipla;

public partial class Protegida : ContentPage
{
	public Protegida()
	{
		InitializeComponent();

		string? usuarioLogado = null;

		Task.Run(async () =>
		{
			usuarioLogado = await SecureStorage.Default.GetAsync("usuarioLogado");
			lblBoasVindas.Text = $"Bem-vindo(a) {usuarioLogado}";
		});
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		bool confirma = await DisplayAlert("Tem certeza?","Sair do App?","Sim","Não");
		
		if(confirma)
		{
			SecureStorage.Default.Remove("usuarioLogado");
			App.Current.MainPage = new Login();
		}
	}
}