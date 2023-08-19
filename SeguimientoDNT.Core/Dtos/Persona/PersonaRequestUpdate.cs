using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguimientoDNT.Api.Resx;

namespace SeguimientoDNT.Core.Dtos.Persona
{
    public class PersonaRequestUpdate
    {
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public int IdPersona { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string TipoIdentificacion { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string NroIdentificacion { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string PrimerNombre { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string SegundoNombre { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string PrimerApellido { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string SegundoApellido { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string Sexo { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public DateTime? FechaNacimiento { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string CodMpioResidencia { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string CodAsegurador { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public DateTime? FechaRegistro { get; set; }
    }
}
