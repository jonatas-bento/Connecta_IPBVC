using Connecta_IPBVC.Services;
using Connecta_IPBVC.ViewModels;
using Connecta_IPBVC.Views;

namespace Connecta_IPBVC;

public static class MauiProgram
{
    public static IServiceProvider Services;

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Services
        builder.Services.AddSingleton<ApiClient>();
        builder.Services.AddSingleton<AuthService>();
        builder.Services.AddSingleton<AgendaService>();
        builder.Services.AddSingleton<IDialogService, DialogService>();

        // ViewModels
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<EventosViewModel>();
        builder.Services.AddTransient<EventoDetalheViewModel>();
        builder.Services.AddTransient<AnexosViewModel>();
        builder.Services.AddTransient<CriarEventoViewModel>();

        // Pages
        builder.Services.AddTransient<CriarEventoPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<EventosPage>();
        builder.Services.AddTransient<EventoDetalhePage>();
        builder.Services.AddTransient<AnexosPage>();

        var app = builder.Build();
        Services = app.Services;

        return app;
    }
}
