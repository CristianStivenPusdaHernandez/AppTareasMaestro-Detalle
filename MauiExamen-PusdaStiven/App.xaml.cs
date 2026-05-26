using MauiExamen_PusdaStiven.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MauiExamen_PusdaStiven
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var dbService = Handler.MauiContext.Services.GetRequiredService<DatabaseService>();

            var contenedor = new ContenedorPrincipal(dbService);

            return new Window(new NavigationPage(contenedor));
        }
    }
}