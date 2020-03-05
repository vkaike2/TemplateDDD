using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Template.Domain.Models;

namespace Template.Domain.IRepository
{
    public interface IFilmeRepository
    {
        void Salvar(FilmeModel model);
        FilmeModel BuscarPorId(Guid id);
        void Alterar(FilmeModel model);
        void Delete(FilmeModel model);
        void Commit();//Retorno ou nao
    }
}
