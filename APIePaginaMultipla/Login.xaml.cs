namespace APIePaginaMultipla;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			//Valores já registrados
			List<DadosUsuario> listaUsuarios = new List<DadosUsuario>
			{
				new DadosUsuario()
				{
					Usuario = "josé", Senha = "123"
				},
				new DadosUsuario()
				{
					Usuario = "maria", Senha = "321"
				}
			};

			//Valores novos
			DadosUsuario dadosDigitados = new DadosUsuario()
			{
				Usuario = txtUsuario.Text,
				Senha = txtSenha.Text
			};

			//LINQ
			if (listaUsuarios.Any(
				i => (dadosDigitados.Usuario == i.Usuario &&
				dadosDigitados.Senha == i.Senha)
				)/*any*/)/*if*/ 
			{
				await SecureStorage.Default.SetAsync("usuarioLogado", dadosDigitados.Usuario);

				App.Current.MainPage = new Protegida();
			}
			else 
			{
				throw new Exception("Usuário ou senha Incorretos.");
			}
		} catch(Exception ex) 
		{
			await DisplayAlert("Ops", ex.Message, "Fechar");
		}
    }
}