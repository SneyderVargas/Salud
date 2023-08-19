using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDNT.Core.Moldes
{
    internal class Seguimientos
    {
        public int IdSeguimiento { get; set; }
        public int IdPersona { get; set; }
        public string EstadoVital { get; set; }
        public DateTime? FechaDefuncion { get; set; }
        public string UbicacionDefuncion { get; set; }
        public string CodLugarAtencion { get; set; }
        public DateTime? FechaAtencion { get; set; }
        public decimal PesoKg { get; set; }
        public short TallaCm { get; set; }
        public string CodClasificacionNutricional { get; set; }
        public string CodManejoActual { get; set; }
        public string DesManejo { get; set; }
    }
}
