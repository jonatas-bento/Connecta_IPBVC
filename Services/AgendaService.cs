using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Connecta_IPBVC.Models;

namespace Connecta_IPBVC.Services
{
	public class AgendaService
	{
		private readonly ApiClient _client;

		public AgendaService(ApiClient client)
		{
			_client = client;
		}

		public async Task<List<EventoDTO>> GetEventosFuturosAsync()
		{
			await _client.AddJwtHeaderAsync();

			var response = await _client.Http.GetAsync("AgendaEventos/futuros");
			var json = await response.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<List<EventoDTO>>(json,
				new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
		}

		public async Task<EventoDetalheDTO> GetEventoAsync(int id)
		{
			await _client.AddJwtHeaderAsync();

			var response = await _client.Http.GetAsync($"AgendaEventos/{id}");
			var json = await response.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<EventoDetalheDTO>(json,
				new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
		}

		public async Task<List<AnexoDTO>> GetAnexosAsync(int eventoId)
		{
			await _client.AddJwtHeaderAsync();

			var response = await _client.Http.GetAsync($"AgendaEventos/{eventoId}/anexos");
			var json = await response.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<List<AnexoDTO>>(json,
				new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
		}
	}
}
