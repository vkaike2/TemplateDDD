using AutoMapper;
using Template.Data.Entitys;
using Template.Domain.Models;

namespace Template.Data.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FilmeModel, Filme>()
                .ReverseMap();

            CreateMap<DescricaoModel, Descricao>()
                .ReverseMap();
        }
    }
}
