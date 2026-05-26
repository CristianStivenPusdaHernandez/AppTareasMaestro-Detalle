using SQLite;

namespace MauiExamen_PusdaStiven.Models
{
    public class Categoria
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}