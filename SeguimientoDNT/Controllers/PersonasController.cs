using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SeguimientoDNT.Core.Interfaces.Repositories;

namespace SeguimientoDNT.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonasController : Controller
    {
        private readonly IPersonasRepo _personasRepo;

        public PersonasController(IPersonasRepo personasRepo)
        {
            _personasRepo = personasRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetGreetings()
        {
            return Ok(await _personasRepo.GetPersonas());
        }
    }
}
