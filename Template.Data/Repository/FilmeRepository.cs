using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Linq;
using Template.Data.Context;
using Template.Data.Models;
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

        public async void SalvarAsync(FilmeModel filmeModel)
        {
            var entity = _mapper.Map<Filme>(filmeModel);
            await _context.Filme.AddAsync(entity);
            
            Commit();
        }

        public FilmeModel BuscarPorId(Guid id)
        {
            FilmeModel model = _context.Filme.ProjectTo<FilmeModel>(_mapper.ConfigurationProvider)
                .Where(e => e.Id == id).FirstOrDefault();
            return model;
        }

        public void AlterarAsync(FilmeModel model)
        {
            FilmeModel FilmeModelo = BuscarPorId(model.Id);
                //_context.Filme.ProjectTo<FilmeModel>(_mapper.ConfigurationProvider).Where(e => e.Id == model.Id).FirstOrDefault();

            FilmeModelo.Nome = model.Nome;
            FilmeModelo.FaixaEtaria = model.FaixaEtaria;

            _context.Filme.Update(_mapper.Map<Filme>(FilmeModelo));
            Commit();

        }
        public void DeleteAsync(Guid id)
        {
            FilmeModel filmeModel = BuscarPorId(id);

            _context.Filme.Remove(_mapper.Map<Filme>(filmeModel));

            Commit();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

    }
}
