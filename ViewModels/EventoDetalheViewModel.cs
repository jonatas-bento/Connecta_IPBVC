using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Connecta_IPBVC.Models;
using Connecta_IPBVC.Services;
using Connecta_IPBVC.Views;
using System.Collections.ObjectModel;

namespace Connecta_IPBVC.ViewModels
{
    [QueryProperty(nameof(EventoId), "id")]
    public partial class EventoDetalheViewModel : ObservableObject
    {
        private readonly AgendaService _service;

        [ObservableProperty] private int eventoId;
        [ObservableProperty] private AgendaEventoDTO evento;
        [ObservableProperty] private ObservableCollection<AgendaEventoAnexoDTO> anexos;
        [ObservableProperty] private bool isBusy;
        [ObservableProperty] private string errorMessage;

        // 🔵 Propriedades visuais
        [ObservableProperty] private string dataFormatada;
        [ObservableProperty] private string imagemUrl;
        [ObservableProperty] private bool hasAnexos;

        public EventoDetalheViewModel(AgendaService service)
        {
            _service = service;
        }

        public async Task LoadAsync()
        {
            try
            {
                IsBusy = true;

                // EVENTO
                var ev = await _service.GetEventoAsync(EventoId);
                Evento = ev;

                DataFormatada = $"{ev.DataInicio:dd/MM/yyyy} - {ev.DataFim:dd/MM/yyyy}";

                // ANEXOS
                var lista = await _service.GetAnexosAsync(EventoId);
                Anexos = new ObservableCollection<AgendaEventoAnexoDTO>(lista ?? new List<AgendaEventoAnexoDTO>());

                HasAnexos = Anexos.Count > 0;

                // IMAGEM (usa primeiro anexo)
                ImagemUrl = HasAnexos ? Anexos[0].Url : "noimage.png";
            }
            finally
            {
                IsBusy = false;
            }
        }

        // 🔵 Comando para abrir anexos
        [RelayCommand]
        private async Task AbrirAnexosAsync()
        {
            if (!HasAnexos)
            {
                await Shell.Current.DisplayAlert("Aviso", "Este evento não possui anexos.", "OK");
                return;
            }

            await Shell.Current.GoToAsync(nameof(AnexosPage), new Dictionary<string, object>
            {
                ["eventoId"] = EventoId
            });
        }
    }
}
