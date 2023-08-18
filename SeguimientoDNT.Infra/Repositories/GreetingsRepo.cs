using SeguimientoDNT.Core.Interfaces.Repositories;
using SeguimientoDNT.Core.Moldes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDNT.Infra.Repositories
{
    public class GrertingsRepo : IGrertingsRepo
    {
        public Task<IEnumerable<Greetings>> GetGreetings()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetGreetings()
        {
            throw new NotImplementedException();
        }
    }
}
