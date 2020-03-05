using AutoMapper;
using Template.Data.Models;
using Template.Domain.Models;

namespace Template.Data.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FilmeModel, Filme>()
                .ReverseMap();
        }
    }
}
