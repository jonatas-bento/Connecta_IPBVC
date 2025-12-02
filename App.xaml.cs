namespace Connecta_IPBVC;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new LoginShell();
    }
}
