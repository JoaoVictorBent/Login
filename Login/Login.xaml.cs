namespace Login;

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

            //Classe para armazenar os dados do usu�rio
            List<DadosUsario> lista_usuarios = new List<DadosUsario>() 
			{ 
			
				new DadosUsario()
				{ 
				
					Usuario = "jose",
					Senha = "123"

				},

				new DadosUsario()
				{ 
				
					Usuario = "maria",
					Senha = "456"
				},

            };

            //Classe para armazenar os dados digitados pelo usu�rio
            DadosUsario dados_digitados = new DadosUsario()
			{

				Usuario = txt_Usuario.Text,
				Senha = txt_Senha.Text

			};

			//LINQ 
			if (lista_usuarios.Any(x => x.Usuario == dados_digitados.Usuario && x.Senha == dados_digitados.Senha))
			{

                //Se o usu�rio e senha estiverem corretos, armazena o usu�rio logado e redireciona para a p�gina protegida
                await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);

				App.Current.MainPage = new Protegida();

            }

			else
			{

				throw new Exception("Usu�rio ou senha inv�lidos!");

            }


        } catch (Exception ex)
		{

			await DisplayAlert("Ops", ex.Message, "Fechar");

        }

    }
}