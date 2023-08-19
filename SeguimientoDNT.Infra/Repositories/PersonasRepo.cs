using Dapper;
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
    public class PersonasRepo : IPersonasRepo
    {
        private readonly DbContext _connectionString;
        public PersonasRepo(DbContext connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public Task<IEnumerable<Personas>> GetPersona(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Personas>> GetPersonas()
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM db_proyect.seguimientos;";
            return db.QueryAsync<Personas>(sql, new { });
        }

        public Task<(bool Succeeded, string Message)> SetPersonas(Personas personas)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Succeeded, string Message)> UpdatePersona(Personas personas)
        {
            throw new NotImplementedException();
        }
    }
}
