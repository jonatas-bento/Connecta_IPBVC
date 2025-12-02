using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Connecta_IPBVC.Models;
using Connecta_IPBVC.Services;
using Connecta_IPBVC.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Connecta_IPBVC.ViewModels
{
    public partial class EventosViewModel : ObservableObject
    {
        private readonly AgendaService _service;

        [ObservableProperty]
        private ObservableCollection<AgendaEventoDTO> eventos;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string errorMessage;

        public EventosViewModel(AgendaService service)
        {
            _service = service;
            Eventos = new ObservableCollection<AgendaEventoDTO>();

        }

        

        [RelayCommand]
        public async Task LoadAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                ErrorMessage = string.Empty;

                var lista = await _service.GetEventosFuturosAsync();
                Eventos.Clear();

                foreach (var ev in lista)
                    Eventos.Add(ev);
            }
            catch (HttpRequestException)
            {
                ErrorMessage = "Não foi possível conectar ao servidor. Verifique sua internet.";
                await Shell.Current.DisplayAlert("Erro de conexão", ErrorMessage, "OK");
            }
            catch (Exception)
            {
                ErrorMessage = "Ocorreu um erro ao carregar os eventos.";
                await Shell.Current.DisplayAlert("Erro", ErrorMessage, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task AbrirDetalhesAsync(AgendaEventoDTO evento)
        {
            if (evento is null) return;

            await Shell.Current.GoToAsync(
                nameof(EventoDetalhePage),
                new Dictionary<string, object>
                {
            { "id", evento.Id }
                });
        }

    }

}
