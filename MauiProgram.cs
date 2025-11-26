using Connecta_IPBVC.Services;
using Microsoft.Extensions.Logging;

namespace Connecta_IPBVC
{
	public static class MauiProgram
	{
		public static IServiceProvider Services;
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder.Services.AddSingleton<ApiClient>();
			builder.Services.AddSingleton<AuthService>();
			builder.Services.AddSingleton<AgendaService>();

			var app = builder.Build();
			Services = app.Services;

			return app;
		}
	}
}
