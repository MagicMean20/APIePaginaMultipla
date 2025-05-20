
namespace APIePaginaMultipla
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
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
