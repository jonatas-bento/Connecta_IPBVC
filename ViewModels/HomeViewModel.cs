using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Connecta_IPBVC.Models;
using Connecta_IPBVC.Services;
using Connecta_IPBVC.Views;

namespace Connecta_IPBVC.ViewModels
{
	public class HomeViewModel : BindableObject
	{


		public List<EventoDTO> EventosDaSemana { get; set; } = new();

		private readonly AgendaService _agenda;

		public HomeViewModel(AgendaService agenda)
		{
			_agenda = agenda;
			CarregarEventos();
		}

		private async void CarregarEventos()
		{
			EventosDaSemana = await _agenda.GetEventosFuturosAsync();
			OnPropertyChanged(nameof(EventosDaSemana));
		}
	}
}
