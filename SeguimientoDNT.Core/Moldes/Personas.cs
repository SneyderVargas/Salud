using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDNT.Core.Moldes
{
    public class Personas
    {
        public int IdPersona { get; set; }
        public string TipoIdentificacion { get; set; }
        public string NroIdentificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Sexo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string CodMpioResidencia { get; set; }
        public string CodAsegurador { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
