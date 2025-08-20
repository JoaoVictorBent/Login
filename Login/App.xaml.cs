namespace Login
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

        }


        //Método para mudar resolução da janela
        protected override Window CreateWindow(IActivationState activationState)
        {

            var window = base.CreateWindow(activationState);

            window.Width = 400;
            window.Height = 700;

            return window;

        }

    }
}