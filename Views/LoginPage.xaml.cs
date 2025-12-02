namespace Connecta_IPBVC.Views;

using Connecta_IPBVC.Services;
using Connecta_IPBVC.ViewModels;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
