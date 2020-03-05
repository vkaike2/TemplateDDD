using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Data.Context;
using Template.Data.Entitys;
using Template.Domain.IRepository;
using Template.Domain.Models;

namespace Template.Data.Repository
{
    public class DescricaoRepository : IDescricaoRepository
    {

        private readonly FilmeContext _context;
        protected IMapper _mapper;

        public DescricaoRepository(FilmeContext context)
        {
            _context = context;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(Mappings.MappingProfile));
            });
            _mapper = config.CreateMapper();
        }

        public void Alterar(DescricaoModel model)
        {
            _context.Descricao.Update(_mapper.Map<Descricao>(model));
        }

        public void Delete(DescricaoModel model)
        {
            Descricao entity = _mapper.Map<Descricao>(model);
            entity.Filme = null;

            _context.Descricao.Remove(entity);
        }

        public void Salvar(DescricaoModel descricao)
        {
            Descricao entity = _mapper.Map<Descricao>(descricao);
            _context.Descricao.Add(entity);
        }
    }
}
