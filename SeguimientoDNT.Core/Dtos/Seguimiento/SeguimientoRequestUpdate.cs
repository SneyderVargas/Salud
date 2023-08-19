using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguimientoDNT.Api.Resx;

namespace SeguimientoDNT.Core.Dtos.Persona
{
    public class SeguimientoRequestUpdate
    {
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public int IdSeguimiento { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public int IdPersona { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string EstadoVital { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public DateTime? FechaDefuncion { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string UbicacionDefuncion { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string CodLugarAtencion { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public DateTime? FechaAtencion { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public decimal PesoKg { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public short TallaCm { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string CodClasificacionNutricional { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string CodManejoActual { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string DesManejo { get; set; }
    }
}
