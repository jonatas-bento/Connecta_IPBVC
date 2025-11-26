using Connecta_IPBVC.Services;
using Connecta_IPBVC.ViewModels;

namespace Connecta_IPBVC.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		BindingContext = new HomeViewModel(
		   MauiProgram.Services.GetRequiredService<AgendaService>()
	   );
	}
}