using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Models;

namespace Template.Domain.IServices
{
    public interface IFilmeService
    {
        RequestRetorno<Filme> BuscarFilmePorId(int id);
        RequestRetorno<string> InserirFilme(Filme model);
        RequestRetorno<string> AlterarFilme(Filme model);
        RequestRetorno<string> RemoverFilme(int id);
    }
}
