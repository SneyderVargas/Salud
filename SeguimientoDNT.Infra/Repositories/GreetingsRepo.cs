using MySql.Data.MySqlClient;
using SeguimientoDNT.Core.Interfaces.Repositories;
using SeguimientoDNT.Core.Moldes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDNT.Infra.Repositories
{
    public class GrertingsRepo : IGrertingsRepo
    {
        private readonly DbContext _connectionString;
        public GrertingsRepo(DbContext connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public Task<IEnumerable<Greetings>> GetGreetings()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetGreetings()
        {
            throw new NotImplementedException();
        }
    }
}
