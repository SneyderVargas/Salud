﻿using Dapper;
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
            var db = dbConnection();
            var sql = @"SELECT id, name FROM tableprueba";
            return db.QueryAsync<Greetings>(sql, new {});
        }

        public Task<bool> SetGreetings()
        {
            throw new NotImplementedException();
        }
    }
}
