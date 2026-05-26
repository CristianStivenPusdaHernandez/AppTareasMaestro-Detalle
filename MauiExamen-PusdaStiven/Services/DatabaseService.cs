using SQLite;
using MauiExamen_PusdaStiven.Models;

namespace MauiExamen_PusdaStiven.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _db;

        async Task Init()
        {
            if (_db is not null) return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "MaestroDetalle.db3");
            _db = new SQLiteAsyncConnection(dbPath);

            await _db.CreateTableAsync<Categoria>();
            await _db.CreateTableAsync<Tarea>();
        }

        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            await Init();
            return await _db.Table<Categoria>().ToListAsync();
        }

        public async Task<List<Tarea>> GetTareasAsync()
        {
            await Init();
            return await _db.Table<Tarea>().ToListAsync();
        }

        public async Task<int> SaveCategoriaAsync(Categoria categoria)
        {
            await Init();
            if (categoria.Id != 0)
                return await _db.UpdateAsync(categoria);
            return await _db.InsertAsync(categoria);
        }

        public async Task<int> DeleteCategoriaAsync(Categoria categoria)
        {
            await Init();
            await _db.Table<Tarea>().Where(t => t.CategoriaId == categoria.Id).DeleteAsync();
            return await _db.DeleteAsync(categoria);
        }

        public async Task<List<Tarea>> GetTareasByCategoriaAsync(int categoriaId)
        {
            await Init();
            return await _db.Table<Tarea>().Where(t => t.CategoriaId == categoriaId).ToListAsync();
        }

        public async Task<int> SaveTareaAsync(Tarea tarea)
        {
            await Init();
            if (tarea.Id != 0)
                return await _db.UpdateAsync(tarea);
            return await _db.InsertAsync(tarea);
        }

        public async Task<int> DeleteTareaAsync(Tarea tarea)
        {
            await Init();
            return await _db.DeleteAsync(tarea);
        }
    }
}
