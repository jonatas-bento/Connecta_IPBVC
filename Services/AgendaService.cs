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

        public async Task<List<AgendaEventoDTO>> GetEventosFuturosAsync()
        {
            try
            {
                await _client.AddJwtHeaderAsync();

                var response = await _client.Http.GetAsync("AgendaEventos/futuros");
                var json = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<List<AgendaEventoDTO>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CriarEventoAsync(AgendaEventoCreateDTO dto)
        {
            await _client.AddJwtHeaderAsync();

            var json = JsonSerializer.Serialize(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.Http.PostAsync("AgendaEventos", content);

            return response.IsSuccessStatusCode;
        }


        public async Task<AgendaEventoDTO> GetEventoAsync(int id)
        {
            await _client.AddJwtHeaderAsync();

            var response = await _client.Http.GetAsync($"AgendaEventos/{id}");
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<AgendaEventoDTO>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<List<AgendaEventoAnexoDTO>> GetAnexosAsync(int eventoId)
        {
            await _client.AddJwtHeaderAsync();

            var response = await _client.Http.GetAsync($"AgendaEventos/{eventoId}/anexos");
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<AgendaEventoAnexoDTO>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
