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
            try
            {
                var db = dbConnection();
                var sql = @"SELECT IdPersona, TipoIdentificacion, NroIdentificacion, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Sexo, FechaNacimiento, CodMpioResidencia, CodAsegurador, FechaRegistro FROM Personas WHERE IdPersona = @IdPersona";
                return await db.QueryFirstOrDefaultAsync<Personas>(sql, new { IdPersona = param.Id });
            }
            catch (Exception ex)
            {
                return (null);
            }
        }

        public Task<IEnumerable<Personas>> GetPersonas()
        {
            
            try
            {
                var db = dbConnection();
                var sql = @"SELECT IdPersona, TipoIdentificacion, NroIdentificacion, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Sexo, FechaNacimiento, CodMpioResidencia, CodAsegurador, FechaRegistro FROM Personas";
                return db.QueryAsync<Personas>(sql, new { });
            }
            catch (Exception ex)
            {
                return (null);
            }
        }

        public async Task<(bool Succeeded, string Message)> SetPersona(Personas personas)
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
                return (true, "Exito Creando Registro");
            } catch (Exception ex) { 
                return (false, ex.Message); 
            }
        }

        public async Task<(bool Succeeded, string Message)> UpdatePersona(Personas personas, int IdPersona)
        {
            try
            {
                var db = dbConnection();
                var sql = @"UPDATE personas SET TipoIdentificacion = @TipoIdentificacion, NroIdentificacion = @NroIdentificacion, PrimerNombre = @PrimerNombre, SegundoNombre = @SegundoNombre, PrimerApellido = @PrimerApellido, SegundoApellido = @SegundoApellido, Sexo = @Sexo, FechaNacimiento = @FechaNacimiento, CodMpioResidencia = @CodMpioResidencia, CodAsegurador = @CodAsegurador, FechaRegistro = @FechaRegistro WHERE (IdPersona = @IdPersona);";
                var result = await db.ExecuteAsync(sql, new
                {
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
                    personas.FechaRegistro,
                    IdPersona
                });
                return (true, "Exito Actualizando Registro");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool Succeeded, string Message)> DeletePersona(IdRequest param)
        {
            try
            {
                var db = dbConnection();
                var sql = @"DELETE FROM personas WHERE (IdPersona = @Id );";
                var result = await db.ExecuteAsync(sql, new
                {
                    param.Id
                });
                return (true, "Exito Eliminando Registro");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
