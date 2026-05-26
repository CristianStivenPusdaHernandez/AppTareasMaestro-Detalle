using MauiExamen_PusdaStiven.Models;
using MauiExamen_PusdaStiven.Services;

namespace MauiExamen_PusdaStiven
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _dbService;
        private Categoria _categoriaSeleccionada;

        public MainPage(DatabaseService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CargarCategorias();
        }

        private async Task CargarCategorias()
        {
            lstCategorias.ItemsSource = await _dbService.GetCategoriasAsync();
        }

        private async void OnGuardarCategoriaClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoria.Text)) return;

            if (_categoriaSeleccionada == null)
            {
                await _dbService.SaveCategoriaAsync(new Categoria { Nombre = txtCategoria.Text });
            }
            else
            {
                _categoriaSeleccionada.Nombre = txtCategoria.Text;
                await _dbService.SaveCategoriaAsync(_categoriaSeleccionada);
                _categoriaSeleccionada = null;
            }

            txtCategoria.Text = string.Empty;
            btnGuardarCat.Text = "Guardar"; 
            await CargarCategorias();
        }

        private async void OnCategoriaTapped(object sender, TappedEventArgs e)
        {
            var categoria = e.Parameter as Categoria;
            if (categoria != null)
            {
                await Navigation.PushAsync(new TareasPage(_dbService, categoria));
            }
        }

        private void OnCategoriaLongPressed(object sender, TappedEventArgs e)
        {
            var categoria = e.Parameter as Categoria;
            if (categoria != null)
            {
                _categoriaSeleccionada = categoria;
                txtCategoria.Text = _categoriaSeleccionada.Nombre;
                btnGuardarCat.Text = "Actualizar Categoría";
            }
        }
        private async void OnBorrarCategoriaClicked(object sender, EventArgs e)
        {
            var boton = sender as Button;
            var categoria = boton?.CommandParameter as Categoria;

            if (categoria != null)
            {
                bool confirmar = await DisplayAlert("Confirmar", $"¿Eliminar {categoria.Nombre} y todas sus tareas?", "Sí", "No");
                if (confirmar)
                {
                    await _dbService.DeleteCategoriaAsync(categoria);
                    await CargarCategorias();
                }
            }
        }

        private void OnLimpiarClicked(object sender, EventArgs e)
        {
            _categoriaSeleccionada = null;
            txtCategoria.Text = string.Empty;
            btnGuardarCat.Text = "Guardar";
        }
        private void OnEditarCategoriaClicked(object sender, EventArgs e)
        {
            var boton = sender as Button;
            var categoria = boton?.CommandParameter as Categoria;

            if (categoria != null)
            {
                _categoriaSeleccionada = categoria;
                txtCategoria.Text = _categoriaSeleccionada.Nombre; 
                btnGuardarCat.Text = "Actualizar Categoría"; 
                txtCategoria.Focus(); 
            }
        }

    }
}