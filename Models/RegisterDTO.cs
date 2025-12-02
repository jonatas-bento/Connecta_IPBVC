using System.Text.Json.Serialization;

namespace Connecta_IPBVC.Models;

public class RegisterDTO
{
	public string Nome { get; set; }
	public string? Celular { get; set; }
	public string Email { get; set; }
    
	[JsonPropertyName("senha")]
    public string Password { get; set; }
}
