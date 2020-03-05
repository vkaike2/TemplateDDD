using System.Collections.Generic;
using Template.Domain.IServices;
using Template.Domain.Models;
using Template.Domain.IRepository;
using System.Threading.Tasks;
using System;

namespace Template.Service.Services
{
    public class FilmeService : IFilmeService
    {
        //public static List<FilmeModel> fakeDbLista = new List<FilmeModel>();

        public readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public RequestRetorno<FilmeModel> BuscarFilmePorId(Guid id)
        {
            ValidarId(id);
            FilmeModel filme = _filmeRepository.BuscarPorId(id);

            return
                new RequestRetorno<FilmeModel>()
                {
                    Informacao = filme,
                    Mensagens = new List<string>() { "Filme encontrado com sucesso!" }
                };
        }


        public RequestRetorno<string> InserirFilme(FilmeModel model)
        {
            model.Id = Guid.NewGuid();
            _filmeRepository.SalvarAsync(model);

            return new RequestRetorno<string>()
            {
                Informacao = "Filme alterado com sucesso!"
            };
        }


        public RequestRetorno<string> AlterarFilme(FilmeModel model)
        {
            //FilmeModel modelCadastrado = fakeDbLista.Where(e => e.Id == model.Id).FirstOrDefault();
            //modelCadastrado.Nome = model.Nome;
            //modelCadastrado.FaixaEtaria = model.FaixaEtaria;

            _filmeRepository.AlterarAsync(model);


            return new RequestRetorno<string>()
            {
                Informacao = "Filme alterado com sucesso!"
            };
        }

        public RequestRetorno<string> RemoverFilme(Guid id)
        {

            _filmeRepository.DeleteAsync(id);

            return new RequestRetorno<string>()
            {
                Informacao = "Filme Deletado com sucesso!"
            };
        }

        private bool ValidarId(Guid id)
        {


            FilmeModel filme = _filmeRepository.BuscarPorId(id);
            if (filme.Id == id)
            {
                return true;
            }

            throw new Exception("Id não encontrado !");

        }
        private void ValidarIdTeste(Guid id)
        {
            FilmeModel filme = _filmeRepository.BuscarPorId(id);
            if (filme is null)
            {
                throw new Exception("Id não encontrado !");
            }
        }
    }
}
