using Connecta_IPBVC.Services;
using Connecta_IPBVC.ViewModels;

namespace Connecta_IPBVC.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
        //BindingContext = new HomeViewModel(
        //   MauiProgram.Services.GetRequiredService<AgendaService>()
        //  );
    }
        private async void OnEventsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///eventos");
    }

    private async void OnCreateEventClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///criarEvento");
    }

    //private async void OnEventsClicked(object sender, EventArgs e)
    //{
    //    await Shell.Current.GoToAsync("///Eventos");
    //}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var role = await SecureStorage.GetAsync("role");

        BtnCriarEvento.IsVisible = role == "Secretaria" || role == "Administrador";
    }



}