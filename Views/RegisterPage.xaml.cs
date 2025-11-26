using Connecta_IPBVC.Services;
using Connecta_IPBVC.ViewModels;

namespace Connecta_IPBVC.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();

		BindingContext = new RegisterViewModel(
			MauiProgram.Services.GetRequiredService<AuthService>()
		);
	}
}