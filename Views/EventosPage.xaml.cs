using Connecta_IPBVC.ViewModels;

namespace Connecta_IPBVC.Views;

public partial class EventosPage : ContentPage
{
    private readonly EventosViewModel _vm;

    public EventosPage(EventosViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.LoadAsync();
    }

    
}