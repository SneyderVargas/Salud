using ApiCliente;
using Newtonsoft.Json;
using SeguimientoDNT.Core.Interfaces.Repositories;
using SeguimientoDNT.Core.Moldes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDNT.Infra.Repositories
{
    public class ValidationTableApi : IValidationTableApi
    {
        public async Task<(bool Succeeded, string Message)> IsTable(string name, string code)
        {
            TablaReferencia item = null;
            var client = new HttpClient();
            var apiClient = new Client(client);
            item = await apiClient.AnonymousAsync(name);
            if (item == null)
                return (false, name);
            if (item.Items.Count == 0)
                return (false, name);
            var itemEcontrado = item.Items.FirstOrDefault(item => item.Codigo == code);
            if (itemEcontrado == null)
                return (false, name);

            return (true, "");
        }
    }
}
