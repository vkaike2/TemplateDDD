using System;
using System.Threading.Tasks;
using Template.Domain.Models;

namespace Template.Domain.IServices
{
    public interface IFilmeService
    {
        RequestRetorno<FilmeModel> BuscarFilmePorId(Guid id);
        RequestRetorno<string> InserirFilme(FilmeModel model);
        RequestRetorno<string> AlterarFilme(FilmeModel model);
        RequestRetorno<string> RemoverFilme(Guid id);
    }
}
