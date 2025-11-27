using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Connecta_IPBVC.Models;

namespace Connecta_IPBVC.Services
{
	public class AuthService
	{
		private readonly ApiClient _client;

		public AuthService(ApiClient client)
		{
			_client = client;
		}

        public async Task<string?> LoginAsync(LoginDTO dto)
        {
            try
            {
                // 1. Configura a serialização correta (camelCase)
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };

                var json = JsonSerializer.Serialize(dto, options);

                // Debug: Verifique se aqui aparece "senha" e não "password"
                System.Diagnostics.Debug.WriteLine($"JSON ENVIADO: {json}");

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // 2. Tenta enviar (AQUI QUE ESTÁ O ERRO ATUAL)
                var response = await _client.Http.PostAsync("MembroApp/login", content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMsg = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine($"ERRO API ({response.StatusCode}): {errorMsg}");
                    return null;
                }

                var body = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(body);

                // Cuidado: Verifique se sua API retorna "token" minúsculo ou maiúsculo
                if (doc.RootElement.TryGetProperty("token", out var tokenElement))
                {
                    return tokenElement.GetString();
                }

                return null;
            }
            catch (Exception ex)
            {
                // 3. COLOQUE O BREAKPOINT AQUI NESTA LINHA ABAIXO
                System.Diagnostics.Debug.WriteLine($"EXCEÇÃO FATAL: {ex.Message}");
                return null;
            }
        }

        public async Task<string?> RegisterAsync(RegisterDTO dto)
		{
			var json = JsonSerializer.Serialize(dto);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await _client.Http.PostAsync("MembroApp/register", content);

			if (!response.IsSuccessStatusCode)
				return null;

			var body = await response.Content.ReadAsStringAsync();

			using var doc = JsonDocument.Parse(body);
			return doc.RootElement.GetProperty("token").GetString();
		}
	}
}
