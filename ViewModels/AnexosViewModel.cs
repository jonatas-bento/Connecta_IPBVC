using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Connecta_IPBVC.Models;
using Connecta_IPBVC.Services;


namespace Connecta_IPBVC.ViewModels
{
	public class AnexosViewModel : BindableObject
	{
		private readonly AgendaService _agenda;

		public AnexosViewModel(AgendaService agenda, int eventoId)
		{
			_agenda = agenda;
			Carregar(eventoId);
		}

		public List<AnexoDTO> Anexos { get; set; }

		public ICommand AbrirAnexoCommand => new Command<string>(async (url) =>
		{
			await Launcher.OpenAsync(url);
		});

		public AnexosViewModel(int eventoId)
		{
			Carregar(eventoId);
		}

		private async void Carregar(int eventoId)
		{
			Anexos = await _agenda.GetAnexosAsync(eventoId);
			OnPropertyChanged(nameof(Anexos));
		}
	}
}
