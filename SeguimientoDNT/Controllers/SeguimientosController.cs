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
    [Route("[controller]/[action]")]
    public class SeguimientosController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISeguimientosRepo _seguimientosRepo;

        public SeguimientosController(IMapper mapper, ISeguimientosRepo seguimientosRepo)
        {
            _mapper = mapper;
            _seguimientosRepo = seguimientosRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeguimiento([FromQuery] IdRequest param)
        {
            try
            {
                return Ok(await _seguimientosRepo.GetSeguimiento(param));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetSeguimientos()
        {
            return Ok(await _seguimientosRepo.GetSeguimientos());
        }
        [HttpPost]
        public async Task<IActionResult> SetSeguimiento([FromBody] SeguimientoRequest param)
        {
            try 
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                Seguimientos data = _mapper.Map<Seguimientos>(param);
                var (Succeeded, Message) = await _seguimientosRepo.SetSeguimiento(data);
                if (!Succeeded)
                    return BadRequest(Message);
                return Ok(Message);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSeguimiento([FromBody] SeguimientoRequestUpdate param )
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                Seguimientos data = _mapper.Map<Seguimientos>(param);
                var Id = param.IdSeguimiento;
                var (Succeeded, Message) = await _seguimientosRepo.UpdateSeguimiento(data, Id);
                if (!Succeeded)
                    return BadRequest(Message);
                return Ok(Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSeguimineto([FromBody] IdRequest param)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var (Succeeded, Message) = await _seguimientosRepo.DeleteSeguimineto(param);
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
