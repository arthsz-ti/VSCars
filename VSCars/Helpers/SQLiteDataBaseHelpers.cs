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
            _conn.CreateTableAsync<Veiculo>().Wait();
        }

        // Métodos para Marca 
        public Task<int> Insert(Marca p)
        {
            return _conn.InsertAsync(p);
        }
        public Task<List<Marca>> Update(Marca p)
        {
            string sql = "UPDATE Marca SET Nome=? WHERE Codigo=?";
            return _conn.QueryAsync<Marca>(sql, p.Nome, p.Codigo);
        }
        public Task<int> Delete(int p)
        {
            return _conn.Table<Marca>().DeleteAsync(i => i.Codigo == p);
        }
        public Task<List<Marca>> GetAll()
        {
            return _conn.Table<Marca>().ToListAsync();
        }
        public Task<List<Marca>> Search(string p)
        {
            string sql = "SELECT * FROM Marca WHERE Nome LIKE'%" + p + "%'";
            return _conn.QueryAsync<Marca>(sql);
        }

        // Métodos para Veículo 
        public Task<int> InsertVeiculo(Veiculo v)
        {
            return _conn.InsertAsync(v);
        }
        public Task<List<Veiculo>> UpdateVeiculo(Veiculo v)
        {
            string sql = "UPDATE Veiculo SET Nome=? WHERE Codigo=?";
            return _conn.QueryAsync<Veiculo>(sql, v.Nome, v.Codigo);
        }
        public Task<int> DeleteVeiculo(int v)
        {
            return _conn.Table<Veiculo>().DeleteAsync(i => i.Codigo == v);
        }
        public Task<List<Veiculo>> GetAllVeiculos()
        {
            return _conn.Table<Veiculo>().ToListAsync();
        }
        public Task<List<Veiculo>> SearchVeiculos(string v)
        {
            string sql = "SELECT * FROM Veiculo WHERE Nome LIKE'%" + v + "%'";
            return _conn.QueryAsync<Veiculo>(sql);
        }
    }
}