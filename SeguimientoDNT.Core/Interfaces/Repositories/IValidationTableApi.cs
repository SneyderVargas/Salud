using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDNT.Core.Interfaces.Repositories
{
    public interface IValidationTableApi
    {
        Task<(bool Succeeded, string Message)> IsTable(string name, string code);
    }
}
