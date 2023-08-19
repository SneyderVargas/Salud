using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguimientoDNT.Api.Resx;

namespace SeguimientoDNT.Core.Dtos.Persona
{
    public class SeguimientoRequest
    {
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public int IdPersona { get; set; }
        [WebEstadoVitalValidationAttribute]
        public string EstadoVital { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public DateTime? FechaDefuncion { get; set; }
        [WebUbicacionDefuncionValidationAttribute]
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
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string CodUbicacion { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string DesUbicacion { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string CodTratamiento { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public int TotalSobresFTLC { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string OtroTratamiento { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public DateTime? FechaRegistro { get; set; }
    }

    internal class WebEstadoVitalValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string data = (string)value;

            if (data != "Vivo" && data != "Fallecido")
            {
                return new ValidationResult("El campo estado vital debe tener alguno estado en: Vivo o Fallecido"); // La validación falla si las condiciones no se cumplen
            }
            return ValidationResult.Success;
        }
    }

    internal class WebUbicacionDefuncionValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string data = (string)value;

            if (data != "IPS" && data != "Hogar")
            {
                return new ValidationResult("El campo Ubicación Defunción debe tener alguno estado en: IPS o Hogar"); // La validación falla si las condiciones no se cumplen
            }
            return ValidationResult.Success;
        }
    }
}
