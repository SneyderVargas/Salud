using SeguimientoDNT.Core.Dtos;
using SeguimientoDNT.Core.Moldes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDNT.Core.Interfaces.Repositories
{
    public interface ISeguimientosRepo
    {
        Task<Seguimientos> GetSeguimiento(IdRequest param);
        Task<IEnumerable<Seguimientos>> GetSeguimientos();
        Task<(bool Succeeded, string Message)> SetSeguimiento(Seguimientos seguimiento);
        Task<(bool Succeeded, string Message)> UpdateSeguimiento(Seguimientos seguimientos, int Id);
        Task<(bool Succeeded, string Message)> DeleteSeguimineto(IdRequest param);

    }
}
