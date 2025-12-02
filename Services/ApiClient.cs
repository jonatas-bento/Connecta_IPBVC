using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Connecta_IPBVC.Services
{
	public class ApiClient
	{
		public HttpClient Http { get; private set; }

		public ApiClient()
		{
			Http = new HttpClient
			{
				BaseAddress = new Uri("http://192.168.1.10:5000/api/")
			};
		}

		public async Task AddJwtHeaderAsync()
		{
			var token = await SecureStorage.GetAsync("jwt");

			if (!string.IsNullOrEmpty(token))
			{
				Http.DefaultRequestHeaders.Authorization =
					new AuthenticationHeaderValue("Bearer", token);
			}
		}
	}
}
