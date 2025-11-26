using System.Windows.Input;
using Connecta_IPBVC.Services;
using Connecta_IPBVC.Models;
using Connecta_IPBVC.Views;

namespace Connecta_IPBVC.ViewModels;

public class LoginViewModel : BindableObject
{
	private readonly AuthService _auth;
	public LoginViewModel(AuthService auth)
	{
		_auth = auth;
	}

	public string Email { get; set; }
	public string Password { get; set; }

	public ICommand LoginCommand => new Command(async () => await DoLogin());
	public ICommand GoToRegisterCommand => new Command(async () =>
		await App.Current.MainPage.Navigation.PushAsync(new RegisterPage()));

	private async Task DoLogin()
	{
		var dto = new LoginDTO { Email = Email, Password = Password };

		var token = await _auth.LoginAsync(dto);

		if (token == null)
		{
			await Application.Current.MainPage.DisplayAlert("Erro", "Login inválido", "OK");
			return;
		}

		await SecureStorage.SetAsync("jwt", token);
		await Application.Current.MainPage.DisplayAlert("Sucesso", "Login realizado!", "OK");
	}
}
