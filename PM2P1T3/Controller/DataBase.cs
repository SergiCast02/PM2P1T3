using PM2P1T3.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM2P1T3.Controller
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection dbase;

        public DataBase(string dbpath)
        {
            dbase = new SQLiteAsyncConnection(dbpath);

            // TABLAS
            dbase.CreateTableAsync<personas>();
        }

        #region OperacionesPerson
        // Create
        public Task<int> PersonSave(personas person)
        {
            if (person.Id != 0)
            {
                return dbase.UpdateAsync(person); // Update
            }
            else
            {
                return dbase.InsertAsync(person);
            }
        }

        // Read
        public Task<List<personas>> obtenerListaPerson()
        {
            return dbase.Table<personas>().ToListAsync();
        }

        // Read V2
        public Task<personas> obtenerPerson(int pid)
        {
            return dbase.Table<personas>()
                .Where(i => i.Id == pid)
                .FirstOrDefaultAsync();
        }

        // Delete
        public Task<int> PersonDelete(personas person)
        {
            return dbase.DeleteAsync(person);
        }

        #endregion Operaciones
    }
}