using Connecta_IPBVC.ViewModels;

namespace Connecta_IPBVC.Views;

public partial class CriarEventoPage : ContentPage
{
    public CriarEventoPage(CriarEventoViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}