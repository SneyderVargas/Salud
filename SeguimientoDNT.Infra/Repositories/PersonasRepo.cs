using Dapper;
using MySql.Data.MySqlClient;
using SeguimientoDNT.Core.Dtos;
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

        public async Task<Personas> GetPersona(IdRequest param)
        {
            var db = dbConnection();
            var sql = @"SELECT IdPersona, TipoIdentificacion, NroIdentificacion, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Sexo, FechaNacimiento, CodMpioResidencia, CodAsegurador, FechaRegistro FROM Personas WHERE IdPersona = @IdPersona";
            return await db.QueryFirstOrDefaultAsync<Personas>(sql, new { IdPersona = param.Id });
        }

        public Task<IEnumerable<Personas>> GetPersonas()
        {
            var db = dbConnection();
            var sql = @"SELECT IdPersona, TipoIdentificacion, NroIdentificacion, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Sexo, FechaNacimiento, CodMpioResidencia, CodAsegurador, FechaRegistro FROM Personas";
            return db.QueryAsync<Personas>(sql, new { });
        }

        public async Task<(bool Succeeded, string Message)> SetPersonas(Personas personas)
        {
            try {
                var db = dbConnection();
                var sql = @"INSERT INTO personas (TipoIdentificacion, NroIdentificacion, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Sexo, FechaNacimiento, CodMpioResidencia, CodAsegurador, FechaRegistro) VALUES (@TipoIdentificacion, @NroIdentificacion, @PrimerNombre, @SegundoNombre, @PrimerApellido, @SegundoApellido, @Sexo, @FechaNacimiento, @CodMpioResidencia, @CodAsegurador, @FechaRegistro);";
                var result = await db.ExecuteAsync(sql, new {
                    personas.TipoIdentificacion,
                    personas.NroIdentificacion,
                    personas.PrimerNombre,
                    personas.SegundoNombre,
                    personas.PrimerApellido,
                    personas.SegundoApellido,
                    personas.Sexo,
                    personas.FechaNacimiento,
                    personas.CodMpioResidencia,
                    personas.CodAsegurador,
                    personas.FechaRegistro
                });
                return (true, "Exito");
            } catch (Exception ex) { 
                return (false, ex.Message); 
            }
        }

        public Task<(bool Succeeded, string Message)> UpdatePersona(Personas personas)
        {
            throw new NotImplementedException();
        }
    }
}
