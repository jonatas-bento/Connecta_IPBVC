using Connecta_IPBVC.Services;
using Connecta_IPBVC.ViewModels;
using Microsoft.Extensions.Logging;

namespace Connecta_IPBVC.Views;

public partial class EventoDetalhePage : ContentPage
{
    private readonly EventoDetalheViewModel _vm;

    public EventoDetalhePage(EventoDetalheViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.LoadAsync();
    }
}