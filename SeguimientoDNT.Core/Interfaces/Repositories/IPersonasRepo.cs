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
        Task<IEnumerable<Personas>> GetPersonas();
        Task<IEnumerable<Personas>> GetPersona(int id);
        Task<(bool Succeeded, string Message)> UpdatePersona(Personas personas);
        Task<(bool Succeeded, string Message)> SetPersonas(Personas personas);
    }
}
