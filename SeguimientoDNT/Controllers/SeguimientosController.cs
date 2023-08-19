using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using SeguimientoDNT.Core.Dtos.Persona;
using SeguimientoDNT.Core.Dtos;
using SeguimientoDNT.Core.Interfaces.Repositories;
using SeguimientoDNT.Core.Moldes;
using SeguimientoDNT.Infra.Repositories;

namespace SeguimientoDNT.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SeguimientosController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISeguimientosRepo _seguimientosRepo;
        private readonly IValidationTableApi _validationTableApi;

        public SeguimientosController(IMapper mapper, ISeguimientosRepo seguimientosRepo, IValidationTableApi validationTableApi)
        {
            _mapper = mapper;
            _seguimientosRepo = seguimientosRepo;
            _validationTableApi = validationTableApi;
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
                //var (SucceededTable0, MessageTable0) = await _validationTableApi.IsTable("CodSedeIPSDemo", param.CodLugarAtencion);
                //var (SucceededTable1, MessageTable1) = await _validationTableApi.IsTable("DNTClasificacionNutricional", param.CodClasificacionNutricional);
                //var (SucceededTable2, MessageTable2) = await _validationTableApi.IsTable("DNTManejo", param.CodManejoActual);
                //var (SucceededTable3, MessageTable3) = await _validationTableApi.IsTable("DNTUbicacion", param.CodUbicacion);
                //var (SucceededTable4, MessageTable4) = await _validationTableApi.IsTable("DNTTratamiento", param.CodTratamiento);
                //if (SucceededTable0 != true || SucceededTable1 != true || SucceededTable2 != true || SucceededTable3 != true)
                //    return BadRequest("Validar la Informacion que esta enviando, por favor validar los codigo como los son, TipoIdDemo, Sexo, Municipio y AseguradorDemo");
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
