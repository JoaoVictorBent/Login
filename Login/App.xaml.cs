namespace Login
{
    public partial class App : Application
    {
        public App()
        {
            
            InitializeComponent();

            MainPage = new Login();

            // Verifica se o usuário está logado
            string? usuario_logado = null;

            Task.Run(async () =>
            {

                usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

                if( usuario_logado == null)
                {

                    MainPage = new Login();

                }

                else
                {

                    MainPage = new Protegida();

                }

            });

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