namespace Login;

public partial class Protegida : ContentPage
{
	public Protegida()
	{
		InitializeComponent();

        // Verifica se o usu�rio est� logado e mensagem de boas-vindas
        string? usuario_logado = null;

		Task.Run(async () =>
		{

			usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
			lbl_boasvindas.Text = $"Bem-vindo (a) {usuario_logado}";

		});
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {

        // M�todo para sair do app
        bool confirmacao = await DisplayAlert("Tem Certeza?", "Sair do app", "Sim", "N�o");

		if (confirmacao)
		{

            // Se o usu�rio confirmar, remove o usu�rio logado e redireciona para a p�gina de login
            SecureStorage.Default.Remove("usuario_logado");
			App.Current.MainPage = new Login();

		}

    }
}