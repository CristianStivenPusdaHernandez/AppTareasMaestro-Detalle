using MauiExamen_PusdaStiven.Services;

namespace MauiExamen_PusdaStiven
{
    public partial class ContenedorPrincipal : TabbedPage
    {
        public ContenedorPrincipal(DatabaseService dbService)
        {
            InitializeComponent();
            var paginaCategorias = new MainPage(dbService) { Title = "Categorías" };
            var paginaTareasGlobales = new TareasPage(dbService, null) { Title = "Tareas Globales" };
            Children.Add(paginaCategorias);
            Children.Add(paginaTareasGlobales);
        }
    }
}
