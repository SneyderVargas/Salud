using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using SeguimientoDNT.Core.Dtos.Persona;
using SeguimientoDNT.Core.Dtos;
using SeguimientoDNT.Core.Interfaces.Repositories;
using SeguimientoDNT.Core.Moldes;
using ApiCliente;
using ExportXml;

namespace SeguimientoDNT.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonasController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPersonasRepo _personasRepo;
        private readonly IValidationTableApi _validationTableApi;
        private readonly ISeguimientosRepo _seguimientosRepo;

        public PersonasController(IMapper mapper, IPersonasRepo personasRepo, IValidationTableApi validationTableApi, ISeguimientosRepo seguimientosRepo)
        {
            _mapper = mapper;
            _personasRepo = personasRepo;
            _validationTableApi = validationTableApi;
            _seguimientosRepo = seguimientosRepo;
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
        public async Task<IActionResult> SetPersona([FromBody] PersonaRequest param)
        {
            try 
            {
                
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var (SucceededTable0, MessageTable0) = await _validationTableApi.IsTable("TipoIdDemo", param.TipoIdentificacion);
                var (SucceededTable1, MessageTable1) = await _validationTableApi.IsTable("Sexo", param.Sexo);
                var (SucceededTable2, MessageTable2) = await _validationTableApi.IsTable("Municipio", param.CodMpioResidencia);
                var (SucceededTable3, MessageTable3) = await _validationTableApi.IsTable("AseguradorDemo", param.CodMpioResidencia);
                if (SucceededTable0 != true || SucceededTable1 != true || SucceededTable2 != true || SucceededTable3 != true)
                    return BadRequest("Validar la Informacion que esta enviando, por favor validar los codigo como los son, TipoIdDemo, Sexo, Municipio y AseguradorDemo");
                Personas data = _mapper.Map<Personas>(param);
                var (Succeeded, Message) = await _personasRepo.SetPersona(data);
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
        public async Task<IActionResult> UpdatePersona([FromBody] PersonaRequestUpdate param )
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                Personas data = _mapper.Map<Personas>(param);
                var IdPersona = param.IdPersona;
                var (Succeeded, Message) = await _personasRepo.UpdatePersona(data, IdPersona);
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
        public async Task<IActionResult> DeletePersona([FromBody] IdRequest param)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var (Succeeded, Message) = await _personasRepo.DeletePersona(param);
                if (!Succeeded)
                    return BadRequest(Message);
                return Ok(Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> ExpSeguimientos()
        {
            try
            {

                var personas = await _personasRepo.GetPersonas();
                var seguimientos = await _seguimientosRepo.GetSeguimientos();
                if (personas == null)
                    return BadRequest(ModelState);

                var excelGenerator = new Excel<Personas>();

                var listaDatos = new List<Personas>(personas);
                excelGenerator.Crear(listaDatos, "Personas");

                var otraListaDatos = new List<Seguimientos>(seguimientos);
                excelGenerator.AgregarHoja(otraListaDatos, "Seguimientos");

                string excelBase64 = excelGenerator.ExportarBase64();

                return Ok(excelBase64);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
