using SeguimientoDNT.Core.Moldes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDNT.Core.Interfaces.Repositories
{
    public interface IGrertingsRepo
    {
        Task<IEnumerable<Greetings>> GetGreetings();
        Task<bool> SetGreetings();
    }
}
