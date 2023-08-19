using AutoMapper;
using SeguimientoDNT.Api.Controllers;
using SeguimientoDNT.Core.Dtos.Persona;
using SeguimientoDNT.Core.Moldes;

namespace SeguimientoDNT.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Personas, PersonaRequest>().ReverseMap();
            CreateMap<Personas, PersonaRequestUpdate>().ReverseMap();
            CreateMap<Seguimientos, SeguimientoRequest>().ReverseMap();
            CreateMap<Seguimientos, SeguimientoRequestUpdate>().ReverseMap();
        }
    }
}
