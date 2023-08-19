using SeguimientoDNT.Api.Resx;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDNT.Core.Dtos
{
    public class IdRequest
    {
        [Required(ErrorMessage = SecurityMsg.RequiredId)]
        public int Id { get; set; }
    }
}
