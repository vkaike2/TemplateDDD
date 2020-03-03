using System;
using System.Collections.Generic;
using System.Linq;
using Template.Domain.IServices;
using Template.Domain.Models;

namespace Template.Service.Services
{
    public class FilmeService : IFilmeService
    {
        public static List<Filme> fakeDbLista = new List<Filme>();

        public RequestRetorno<Filme> BuscarFilmePorId(int id)
        {
            ValidarId(id);

            Filme teste = null;
            teste.Id = 4;
            return new RequestRetorno<Filme>()
            {
                Informacao = fakeDbLista.FirstOrDefault(e => e.Id == id),
                Mensagens = new List<string>() { "Filme encontrado com sucesso!" }
            };
        }

        public RequestRetorno<string> InserirFilme(Filme model)
        {
            fakeDbLista.Add(model);
            return new RequestRetorno<string>()
            {
                Informacao = "Filme inserido com sucesso!"
            };
        }

        public RequestRetorno<string> AlterarFilme(Filme model)
        {
            Filme modelCadastrado = fakeDbLista.Where(e => e.Id == model.Id).FirstOrDefault();
            modelCadastrado.Nome = model.Nome;
            modelCadastrado.FaixaEtaria = model.FaixaEtaria;

            return new RequestRetorno<string>()
            {
                Informacao = "Filme alterado com sucesso!"
            };
        }

        public RequestRetorno<string> RemoverFilme(int id)
        {
            ValidarId(id);
            fakeDbLista.Remove(fakeDbLista.FirstOrDefault(e => e.Id == id));
            return new RequestRetorno<string>()
            {
                Informacao = "Filme deletado com sucesso!"
            };
        }

        private void ValidarId(int id)
        {
            if (!fakeDbLista.Any(e => e.Id == id))
            {
                throw new Exception("Não existe um filme para este Id!");
            }
        }
    }
}
