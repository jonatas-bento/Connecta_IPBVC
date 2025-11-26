using Connecta_IPBVC.Services;
using Connecta_IPBVC.ViewModels;
using Microsoft.Extensions.Logging;

namespace Connecta_IPBVC.Views;

public partial class AnexosPage : ContentPage
{
	public AnexosPage(int eventoId)
	{
		InitializeComponent();
		BindingContext = new AnexosViewModel(
			MauiProgram.Services.GetRequiredService<AgendaService>(),
			eventoId
		);
	}
}