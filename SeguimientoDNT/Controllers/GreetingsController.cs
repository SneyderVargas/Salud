using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SeguimientoDNT.Core.Interfaces.Repositories;

namespace SeguimientoDNT.Api.Controllers
{
    public class GreetingsController : Controller
    {
        private readonly IGrertingsRepo _grertingsRepo;

        public GreetingsController(IGrertingsRepo _grertingsRepo)
        {
            _grertingsRepo = _grertingsRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetGreetings()
        {
            return Ok(await _grertingsRepo.GetGreetings());
        }
    }
}
