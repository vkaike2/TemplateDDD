using System;
using System.Collections.Generic;
using System.Text;
using Template.Data.Context;
using Template.Domain.IRepository;

namespace Template.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FilmeContext _context;

        public UnitOfWork(FilmeContext context)
        {
            _context = context;
        }

        private IFilmeRepository _filmeRepository;
        public IFilmeRepository FilmeRepository => _filmeRepository ?? (_filmeRepository = new FilmeRepository(_context));

        private IDescricaoRepository _descricaoRepository;
        public IDescricaoRepository DescricaoRepository => _descricaoRepository ?? (_descricaoRepository = new DescricaoRepository(_context));

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
