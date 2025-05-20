
namespace APIePaginaMultipla
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            string? usuarioLogado = null;
            Task.Run(async () =>
            {
                usuarioLogado = await SecureStorage.Default.GetAsync("usuarioLogado");
                if(usuarioLogado == null)
                {
                    MainPage = new Login();

                } else
                {
                    MainPage = new Protegida();
                }
            });

            MainPage = new Login();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var wind = base.CreateWindow(activationState);

            wind.Width = 400;
            wind.Height = 600;

            return wind;
        }
    }
}
