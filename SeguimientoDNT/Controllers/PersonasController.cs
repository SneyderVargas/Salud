using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using SeguimientoDNT.Core.Dtos.Persona;
using SeguimientoDNT.Core.Dtos;
using SeguimientoDNT.Core.Interfaces.Repositories;
using SeguimientoDNT.Core.Moldes;

namespace SeguimientoDNT.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonasController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPersonasRepo _personasRepo;

        public PersonasController(IMapper mapper, IPersonasRepo personasRepo)
        {
            _mapper = mapper;
            _personasRepo = personasRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetPersona([FromQuery] IdRequest param)
        {
            try
            {
                return Ok(await _personasRepo.GetPersona(param));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetPersonas()
        {
            return Ok(await _personasRepo.GetPersonas());
        }
        [HttpPost]
        public async Task<IActionResult> SetPersonas([FromBody] PersonaRequest param)
        {
            try 
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                Personas data = _mapper.Map<Personas>(param);
                var (Succeeded, Message) = await _personasRepo.SetPersonas(data);
                if (!Succeeded)
                    return BadRequest(Message);
                return Ok(Message);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
