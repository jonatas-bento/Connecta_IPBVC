namespace Connecta_IPBVC.Models;

public class AgendaEventoCreateDTO
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public string Local { get; set; }
    public bool EhGeral { get; set; }
    public List<int> FederacoesIds { get; set; } = new();
}
