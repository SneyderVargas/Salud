using AutoMapper;
using SeguimientoDNT.Core.Dtos.Persona;
using SeguimientoDNT.Core.Moldes;

namespace SeguimientoDNT.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Personas, PersonaRequest>().ReverseMap();
        }
    }
}
