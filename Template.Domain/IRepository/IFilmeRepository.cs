using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Template.Domain.Models;

namespace Template.Domain.IRepository
{
    public interface IFilmeRepository
    {
        void SalvarAsync(FilmeModel model);
        FilmeModel BuscarPorId(Guid id);
        void AlterarAsync(FilmeModel model);
        void DeleteAsync(Guid id);
        void Commit();//Retorno ou nao
    }
}
