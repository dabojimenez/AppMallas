using AppMallas.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppMallas.Data
{
    public class MallaDatabase
    {
        private readonly SQLiteAsyncConnection database;

        public MallaDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Malla>().Wait();
        }

        public async Task<List<Malla>> GetMallasAsync()
        {
            return await database.Table<Malla>().ToListAsync();
        }
        public Task<int> SaveMalla(Malla data)
        {
            if(data.ID != 0)
            {
                return database.UpdateAsync(data);
            }
            else
            {
                return database.InsertAsync(data);
            }
        }
        public Task<int> DeleteMalla( Malla data)
        {
            return database.DeleteAsync(data);
        }
    }
}
