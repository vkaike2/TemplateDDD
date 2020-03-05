using System;
using System.Threading.Tasks;
using Template.Domain.Models;

namespace Template.Domain.IServices
{
    public interface IFilmeService
    {
        RequestRetorno<FilmeModel> BuscarFilmePorId(Guid id);
        RequestRetorno<FilmeModel> InserirFilme(FilmeModel model);
        RequestRetorno<FilmeModel> AlterarFilme(FilmeModel model);
        RequestRetorno<string> RemoverFilme(Guid id);
    }
}
