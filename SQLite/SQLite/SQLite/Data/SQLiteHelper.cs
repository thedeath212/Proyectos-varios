using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite.Models;

namespace SQLite.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string path)
        {
            db = new SQLiteAsyncConnection(path);
            db.CreateTableAsync<Usuario>().Wait();

        }
        public Task<int> SaveUsuarioAsync(Usuario usuario)
        {
            if (usuario.Id == 0)
            {
                // return db.UpdateAsync(usuario);
                return db.InsertAsync(usuario);
            }
            else
            {
                return null;
               // return db.InsertAsync(usuario);
            }
        }

        public Task<List<Usuario>> GetUsuariosAsync()
        {
            return db.Table<Usuario>().ToListAsync();
        }

        public Task<Usuario> GetUsuarioByIdAsync(int Id)
        {
            return db.Table<Usuario>().Where(a => a.Id == Id).FirstOrDefaultAsync();
        }

        public Task <int> DeleteUsuarioAnsyc(Usuario usuario)
        {
            return db.DeleteAsync(usuario);  
        }

        public Task<int> UpdateUsuarioAsync(Usuario usuario)
        {
            return db.UpdateAsync(usuario);
        }

        public Task<Usuario> GetUsuarioByEmailAsync(string email)
        {
            return db.Table<Usuario>().Where(u => u.Email == email).FirstOrDefaultAsync();
        }
    }
}
