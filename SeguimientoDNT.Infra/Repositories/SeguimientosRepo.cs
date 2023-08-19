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
    public class SeguimientosRepo : ISeguimientosRepo
    {
        private readonly DbContext _connectionString;
        public SeguimientosRepo(DbContext connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<Seguimientos> GetSeguimiento(IdRequest param)
        {
            try
            {
                var db = dbConnection();
                var sql = @"SELECT IdSeguimiento, IdPersona, EstadoVital, FechaDefuncion, UbicacionDefuncion, CodLugarAtencion, FechaAtencion, PesoKg, TallaCm, CodClasificacionNutricional, CodManejoActual, DesManejo, CodUbicacion, DesUbicacion, CodTratamiento, TotalSobresFTLC, OtroTratamiento, FechaRegistro FROM Seguimientos WHERE IdSeguimiento = @IdSeguimiento ;";
                return await db.QueryFirstOrDefaultAsync<Seguimientos>(sql, new { IdSeguimiento = param.Id });
            }
            catch (Exception ex)
            {
                return (null);
            }
        }

        public Task<IEnumerable<Seguimientos>> GetSeguimientos()
        {
            
            try
            {
                var db = dbConnection();
                var sql = @"SELECT IdSeguimiento, IdPersona, EstadoVital, FechaDefuncion, UbicacionDefuncion, CodLugarAtencion, FechaAtencion, PesoKg, TallaCm, CodClasificacionNutricional, CodManejoActual, DesManejo, CodUbicacion, DesUbicacion, CodTratamiento, TotalSobresFTLC, OtroTratamiento, FechaRegistro FROM Seguimientos ;";
                return db.QueryAsync<Seguimientos>(sql, new { });
            }
            catch (Exception ex)
            {
                return (null);
            }
        }

        public async Task<(bool Succeeded, string Message)> SetSeguimiento(Seguimientos seguimiento)
        {
            try {
                var db = dbConnection();
                var sql = @"INSERT INTO seguimientos (IdPersona, EstadoVital, FechaDefuncion, UbicacionDefuncion, CodLugarAtencion, FechaAtencion, PesoKg, TallaCm, CodClasificacionNutricional, CodManejoActual, DesManejo, CodUbicacion, DesUbicacion, CodTratamiento, TotalSobresFTLC, OtroTratamiento, FechaRegistro) VALUES ( @IdPersona, @EstadoVital, @FechaDefuncion, @UbicacionDefuncion, @CodLugarAtencion, @FechaAtencion, @PesoKg, @TallaCm, @CodClasificacionNutricional, @CodManejoActual, @DesManejo, @CodUbicacion, @DesUbicacion, @CodTratamiento, @TotalSobresFTLC, @OtroTratamiento, @FechaRegistro);";
                var result = await db.ExecuteAsync(sql, new {
                    seguimiento.IdPersona,
                    seguimiento.EstadoVital,
                    seguimiento.FechaDefuncion,
                    seguimiento.UbicacionDefuncion,
                    seguimiento.CodLugarAtencion,
                    seguimiento.FechaAtencion,
                    seguimiento.PesoKg,
                    seguimiento.TallaCm,
                    seguimiento.CodClasificacionNutricional,
                    seguimiento.CodManejoActual,
                    seguimiento.DesManejo,
                    seguimiento.CodUbicacion,
                    seguimiento.DesUbicacion,
                    seguimiento.CodTratamiento,
                    seguimiento.TotalSobresFTLC,
                    seguimiento.OtroTratamiento,
                    seguimiento.FechaRegistro
                });
                return (true, "Exito Creando Registro");
            } catch (Exception ex) { 
                return (false, ex.Message); 
            }
        }

        public async Task<(bool Succeeded, string Message)> UpdateSeguimiento(Seguimientos seguimientos, int Id)
        {
            try
            {
                var db = dbConnection();
                var sql = @"UPDATE seguimientos SET IdPersona = @IdPersona, EstadoVital = @EstadoVital, FechaDefuncion = @FechaDefuncion, UbicacionDefuncion = @UbicacionDefuncion, CodLugarAtencion = @CodLugarAtencion, FechaAtencion = @FechaAtencion, PesoKg = @PesoKg, TallaCm = @TallaCm, CodClasificacionNutricional = @CodClasificacionNutricional, CodManejoActual = @CodManejoActual, DesManejo = @DesManejo, CodUbicacion = @CodUbicacion, DesUbicacion = @DesUbicacion, CodTratamiento = @CodTratamiento, TotalSobresFTLC = @TotalSobresFTLC, OtroTratamiento = @OtroTratamiento, FechaRegistro = @FechaRegistro WHERE (IdSeguimiento = @Id);";
                var result = await db.ExecuteAsync(sql, new
                {
                    seguimientos.IdPersona,
                    seguimientos.EstadoVital,
                    seguimientos.FechaDefuncion,
                    seguimientos.UbicacionDefuncion,
                    seguimientos.CodLugarAtencion,
                    seguimientos.FechaAtencion,
                    seguimientos.PesoKg,
                    seguimientos.TallaCm,
                    seguimientos.CodClasificacionNutricional,
                    seguimientos.CodManejoActual,
                    seguimientos.DesManejo,
                    seguimientos.CodUbicacion,
                    seguimientos.DesUbicacion,
                    seguimientos.CodTratamiento,
                    seguimientos.TotalSobresFTLC,
                    seguimientos.OtroTratamiento,
                    seguimientos.FechaRegistro,
                    Id
                });
                return (true, "Exito Actualizando Registro");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool Succeeded, string Message)> DeleteSeguimineto(IdRequest param)
        {
            try
            {
                var db = dbConnection();
                var sql = @"DELETE FROM seguimientos WHERE (IdSeguimiento = @Id );";
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
