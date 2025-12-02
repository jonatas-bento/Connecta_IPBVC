using Connecta_IPBVC.Helpers;
using Connecta_IPBVC.Models;
using Connecta_IPBVC.Services;
using Connecta_IPBVC.Views;
using System.Windows.Input;

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
    await Shell.Current.GoToAsync("///register")
);




    private async Task DoLogin()
    {
        var dto = new LoginDTO { Email = Email, Password = Password };

        var token = await _auth.LoginAsync(dto);

        if (token == null)
        {
            await Shell.Current.DisplayAlert("Erro", "Login inválido!", "OK");
            return;
        }

        // Guarda token
        await SecureStorage.SetAsync("jwt", token);

        // Lê claims
        var claims = JwtHelper.Decode(token);

        foreach (var pair in claims)
        {
            if (pair.Key.Contains("role", StringComparison.OrdinalIgnoreCase))
            {
                var role = pair.Value.ToString();
                await SecureStorage.SetAsync("role", role);
            }
        }

        Application.Current.MainPage = new AppShell();
    }

}
