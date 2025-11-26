using Connecta_IPBVC.Services;
using Connecta_IPBVC.ViewModels;
using Microsoft.Extensions.Logging;

namespace Connecta_IPBVC.Views;

public partial class EventoDetalhePage : ContentPage
{
	public EventoDetalhePage(int eventoId)
	{
		InitializeComponent();
		BindingContext = new EventoDetalheViewModel(
			MauiProgram.Services.GetRequiredService<AgendaService>(),
			eventoId
		);
	}
}