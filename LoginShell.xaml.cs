using Connecta_IPBVC.Views;

namespace Connecta_IPBVC;

public partial class LoginShell : Shell
{
	public LoginShell()
	{
		InitializeComponent();


        Routing.RegisterRoute(nameof(EventoDetalhePage), typeof(EventoDetalhePage));
        Routing.RegisterRoute(nameof(AnexosPage), typeof(AnexosPage));
    }
}