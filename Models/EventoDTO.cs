using System;
using System.Collections.Generic;
using System.Text;

namespace Connecta_IPBVC.Models
{
	public class EventoDTO
	{
		public int Id { get; set; }
		public string Titulo { get; set; }
		public DateTime Data { get; set; }
		public string Local { get; set; }

		public string DataFormatada => Data.ToString("dddd, dd 'de' MMMM - HH:mm");
	}
}
