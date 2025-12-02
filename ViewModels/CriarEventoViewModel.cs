using System.Windows.Input;
using Connecta_IPBVC.Models;
using Connecta_IPBVC.Services;

namespace Connecta_IPBVC.ViewModels;

public class CriarEventoViewModel : BindableObject
{
    private readonly AgendaService _agenda;

    public CriarEventoViewModel(AgendaService agenda)
    {
        _agenda = agenda;

        DataInicio = DateTime.Now;
        DataFim = DateTime.Now.AddHours(1);
    }

    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Local { get; set; }

    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }

    public bool EhGeral { get; set; }

    // CHECKBOXES DAS FEDERAÇÕES
    public bool IsUPH { get; set; }
    public bool IsSAF { get; set; }
    public bool IsUMP { get; set; }
    public bool IsUPA { get; set; }
    public bool IsUCP { get; set; }

    public ICommand CriarEventoCommand => new Command(async () => await Criar());

    private async Task Criar()
    {
        var federacoes = new List<int>();

        if (IsUPH) federacoes.Add(1);
        if (IsSAF) federacoes.Add(2);
        if (IsUMP) federacoes.Add(3);
        if (IsUPA) federacoes.Add(4);
        if (IsUCP) federacoes.Add(5);

        var dto = new AgendaEventoCreateDTO
        {
            Titulo = Titulo,
            Descricao = Descricao,
            Local = Local,
            DataInicio = DataInicio,
            DataFim = DataFim,
            EhGeral = EhGeral,
            FederacoesIds = federacoes
        };

        var sucesso = await _agenda.CriarEventoAsync(dto);

        if (!sucesso)
        {
            await Shell.Current.DisplayAlert("Erro", "Não foi possível criar o evento.", "OK");
            return;
        }

        await Shell.Current.DisplayAlert("Sucesso", "Evento criado com sucesso!", "OK");

        await Shell.Current.GoToAsync("///eventos");
    }
}
