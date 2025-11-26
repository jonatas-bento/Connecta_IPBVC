using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Connecta_IPBVC.Models;
using Connecta_IPBVC.Services;
using Connecta_IPBVC.Views;


namespace Connecta_IPBVC.ViewModels
{
	public class EventoDetalheViewModel : BindableObject
	{
		private readonly AgendaService _agenda;

		public EventoDetalheDTO Evento { get; set; }

		public ICommand AbrirAnexosCommand => new Command(async () =>
		{
			await App.Current.MainPage.Navigation.PushAsync(new AnexosPage(Evento.Id));
		});

		public EventoDetalheViewModel(AgendaService agenda, int id)
		{
			_agenda = agenda;
			Carregar(id);
		}

		private async void Carregar(int id)
		{
			Evento = await _agenda.GetEventoAsync(id);
			OnPropertyChanged(nameof(Evento));
		}
	}
}
