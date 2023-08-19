using SeguimientoDNT.Core.Dtos;
using SeguimientoDNT.Core.Moldes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDNT.Core.Interfaces.Repositories
{
    public interface IPersonasRepo
    {
        Task<Personas> GetPersona(IdRequest param);
        Task<IEnumerable<Personas>> GetPersonas();
        Task<(bool Succeeded, string Message)> SetPersona(Personas personas);
        Task<(bool Succeeded, string Message)> UpdatePersona(Personas personas, int IdPersona);
        Task<(bool Succeeded, string Message)> DeletePersona(IdRequest param);

    }
}
