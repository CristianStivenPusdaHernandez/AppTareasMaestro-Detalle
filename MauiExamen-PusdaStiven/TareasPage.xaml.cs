using MauiExamen_PusdaStiven.Models;
using MauiExamen_PusdaStiven.Services;

namespace MauiExamen_PusdaStiven
{
    public partial class TareasPage : ContentPage
    {
        private readonly DatabaseService _dbService;
        private readonly Categoria _categoriaActual;
        private Tarea _tareaSeleccionada;

        public TareasPage(DatabaseService dbService, Categoria categoria = null)
        {
            InitializeComponent();
            _dbService = dbService;
            _categoriaActual = categoria;

            if (_categoriaActual != null)
            {
                lblCategoriaTitulo.Text = $"Tareas de {_categoriaActual.Nombre}";
                Title = _categoriaActual.Nombre;
            }
            else
            {
                lblCategoriaTitulo.Text = "Todas las Tareas Registradas";
                Title = "Todas las Tareas";
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CargarTareas();
        }

        private async Task CargarTareas()
        {
            if (_categoriaActual != null)
            {
                lstTareas.ItemsSource = await _dbService.GetTareasByCategoriaAsync(_categoriaActual.Id);
            }
            else
            {
                lstTareas.ItemsSource = await _dbService.GetTareasAsync();
            }
        }

        private async void OnGuardarTareaClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text)) return;

            if (_tareaSeleccionada == null)
            {
                var nuevaTarea = new Tarea
                {
                    Titulo = txtTitulo.Text,
                    Descripcion = txtDesc.Text,
                    IsCompletada = chkCompletada.IsChecked,
                    CategoriaId = _categoriaActual != null ? _categoriaActual.Id : 1
                };
                await _dbService.SaveTareaAsync(nuevaTarea);
            }
            else
            {
                _tareaSeleccionada.Titulo = txtTitulo.Text;
                _tareaSeleccionada.Descripcion = txtDesc.Text;
                _tareaSeleccionada.IsCompletada = chkCompletada.IsChecked;

                await _dbService.SaveTareaAsync(_tareaSeleccionada);
                _tareaSeleccionada = null;
            }

            LimpiarFormulario();
            await CargarTareas();
        }

        private void OnTareaTapped(object sender, TappedEventArgs e)
        {
            _tareaSeleccionada = e.Parameter as Tarea;
            if (_tareaSeleccionada != null)
            {
                txtTitulo.Text = _tareaSeleccionada.Titulo;
                txtDesc.Text = _tareaSeleccionada.Descripcion;
                chkCompletada.IsChecked = _tareaSeleccionada.IsCompletada;
                btnGuardarTarea.Text = "Actualizar Tarea";
            }
        }

        private async void OnBorrarTareaClicked(object sender, EventArgs e)
        {
            var boton = sender as Button;
            var tarea = boton?.CommandParameter as Tarea;

            if (tarea != null)
            {
                bool confirmar = await DisplayAlert("Eliminar", $"¿Borrar: {tarea.Titulo}?", "Sí", "No");
                if (confirmar)
                {
                    await _dbService.DeleteTareaAsync(tarea);
                    await CargarTareas();
                    LimpiarFormulario();
                }
            }
        }

        private void OnLimpiarClicked(object sender, EventArgs e) => LimpiarFormulario();

        private void LimpiarFormulario()
        {
            _tareaSeleccionada = null;
            txtTitulo.Text = string.Empty;
            txtDesc.Text = string.Empty;
            chkCompletada.IsChecked = false;
            btnGuardarTarea.Text = "Guardar Tarea";
        }
    }
}