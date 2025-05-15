using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using VSCars.Models;
namespace VSCars.Helpers
{
    public class SQLiteDataBaseHelpers
    {
        readonly SQLiteAsyncConnection _conn;
        public SQLiteDataBaseHelpers(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Marca>().Wait();
        }
        public Task<int> Insert(Marca p)
        {
            return _conn.InsertAsync(p);
        }
        public Task<List<Marca>> Update(Marca p)
        {
            string sql = "UPDATE Marca SET Nome =? WHERE Codigo =?";
            return _conn.QueryAsync<Marca>(sql, p.Nome, p.Codigo);
        }
        public Task<int> Delete(int p)
        {
            return _conn.Table<Marca>().DeleteAsync(i => i.Codigo == p);
        }
        /*
        string sql = "DELETE Marca WHERE Codigo=?";
        _conn.QueryAsync<Marca>(sql p);
        */
        public Task<List<Marca>> GetAll()
        {
            return _conn.Table<Marca>().ToListAsync();
        }
        public Task<List<Marca>> Search(string p)
        {
            string sql = "SELECT * FROM Marca WHERE Nome LIKE'%" + p + "%'";
            return _conn.QueryAsync<Marca>(sql);
        }
    }
}