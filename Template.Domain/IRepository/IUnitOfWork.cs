using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Domain.IRepository
{
    public interface IUnitOfWork
    {
        IFilmeRepository FilmeRepository {get;}
        IDescricaoRepository DescricaoRepository { get;}

        void Commit();
    }
}
