using System;
using System.Collections.Generic;
using System.Text;

namespace Connecta_IPBVC.Models
{
    public class AgendaEventoDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Local { get; set; }
        public bool EhGeral { get; set; }
        public List<string> Federacoes { get; set; }
        public List<AgendaEventoAnexoDTO> Anexos { get; set; }
    }

}
