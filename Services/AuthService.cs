using Connecta_IPBVC.Models;
using Connecta_IPBVC.Services;
using System.Text;
using System.Text.Json;

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
        try
        {

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(dto, options);

            // Debug: Verifique se aqui aparece "senha" e não "password"
            System.Diagnostics.Debug.WriteLine($"JSON ENVIADO: {json}");

            var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.Http.PostAsync("MembroApp/register", content);

            if (!response.IsSuccessStatusCode)
                //Catch the exception - return the message - how to go to exception message?
                throw new Exception("Erro ao registrar usuário: " + response.ReasonPhrase);


            var body = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);
        return doc.RootElement.GetProperty("token").GetString();
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
