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
			var json = JsonSerializer.Serialize(dto);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await _client.Http.PostAsync("MembroApp/login", content);

			if (!response.IsSuccessStatusCode)
				return null;

			var body = await response.Content.ReadAsStringAsync();

			using var doc = JsonDocument.Parse(body);
			return doc.RootElement.GetProperty("token").GetString();
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
