using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace Gps.Datos
{
    public class LocationDatabase
    {
        readonly SQLiteAsyncConnection database;

        public LocationDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Ubicacion>().Wait();
        }

        public Task<List<Ubicacion>> GetLocationsAsync()
        {
            return database.Table<Ubicacion>().ToListAsync();
        }

        public Task<int> SaveLocationAsync(Ubicacion location)
        {
            if (location.Id != 0)
            {
                return database.UpdateAsync(location);
            }
            else
            {
                return database.InsertAsync(location);
            }
        }
        public Task<int> SaveUserAsync(Usuario user)
        {
            return database.InsertAsync(user); // Guardar el usuario en la base de datos
        }
    }
}
