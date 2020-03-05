using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Linq;
using Template.Data.Context;
using Template.Data.Entitys;
using Template.Domain.IRepository;
using Template.Domain.Models;

namespace Template.Data.Repository
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly FilmeContext _context;
        protected IMapper _mapper;

        public FilmeRepository(FilmeContext context)
        {
            _context = context;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(Mappings.MappingProfile));
            });
            _mapper = config.CreateMapper();
        }

        public void Salvar(FilmeModel filmeModel)
        {
            Filme entity = _mapper.Map<Filme>(filmeModel);
            _context.Filme.Add(entity);
        }

        public FilmeModel BuscarPorId(Guid id)
        {
            FilmeModel model = _context.Filme.ProjectTo<FilmeModel>(_mapper.ConfigurationProvider)
                .Where(e => e.Id == id).FirstOrDefault();
            return model;
        }

        public void Alterar(FilmeModel model)
        {
            Filme entidade = _mapper.Map<Filme>(model);
            _context.Filme.Update(entidade);
        }

        public void Delete(FilmeModel model)
        {
            _context.Filme.Remove(_mapper.Map<Filme>(model));
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

    }
}
