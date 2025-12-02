using Connecta_IPBVC.Views;

namespace Connecta_IPBVC
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Rotas das páginas
            Routing.RegisterRoute(nameof(EventoDetalhePage), typeof(EventoDetalhePage));
            Routing.RegisterRoute(nameof(EventosPage), typeof(EventosPage));
            Routing.RegisterRoute(nameof(AnexosPage), typeof(AnexosPage));
        }
    }
}
