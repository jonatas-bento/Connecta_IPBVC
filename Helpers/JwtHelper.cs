using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Connecta_IPBVC.Helpers
{

    public static class JwtHelper
    {
        public static Dictionary<string, object> Decode(string token)
        {
            var parts = token.Split('.');
            if (parts.Length != 3)
                throw new ArgumentException("Token inválido");

            var payload = parts[1];

            // Corrige Base64
            payload = payload.Replace('-', '+').Replace('_', '/');
            switch (payload.Length % 4)
            {
                case 2: payload += "=="; break;
                case 3: payload += "="; break;
            }

            var jsonBytes = Convert.FromBase64String(payload);
            var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            return dict!;
        }
    }

}
