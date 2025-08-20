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

			DadosUsario dados_digitados = new DadosUsario()
			{

				Usuario = txt_Usuario.Text,
				Senha = txt_Senha.Text

			};

			//LINQ 
			if (lista_usuarios.Any(x => x.Usuario == dados_digitados.Usuario && x.Senha == dados_digitados.Senha))
			{

				 await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);

				App.Current.MainPage = new Protegida();

            }

			else
			{

				throw new Exception("Usuário ou senha inválidos!");

            }


        } catch (Exception ex)
		{

			await DisplayAlert("Ops", ex.Message, "Fechar");

        }

    }
}