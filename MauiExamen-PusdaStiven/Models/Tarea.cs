using SQLite;

namespace MauiExamen_PusdaStiven.Models
{
    public class Tarea
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool IsCompletada { get; set; }
        public int CategoriaId { get; set; }
    }
}