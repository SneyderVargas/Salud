using SeguimientoDNT.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDNT.Core.Interfaces.Repositories
{
    public class GrertingsRepo : IGrertingsRepo
    {
        public Task<IEnumerable<GreetingsRepo>> GetGreetings()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetGreetings()
        {
            throw new NotImplementedException();
        }
    }
}
