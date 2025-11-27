using System.Text.Json.Serialization;

namespace Connecta_IPBVC.Models;

public class LoginDTO
{
	public string Email { get; set; }
		
	[JsonPropertyName("senha")]
	public string Password { get; set; }
}
