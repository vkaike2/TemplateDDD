using System.Collections.Generic;
using Template.Domain.IServices;
using Template.Domain.Models;
using Template.Domain.IRepository;
using System.Threading.Tasks;
using System;
using Template.Data.Entitys;

namespace Template.Service.Services
{
    public class FilmeService : IFilmeService
    {
        public readonly IUnitOfWork _unitOfWork;

        public FilmeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RequestRetorno<FilmeModel> BuscarFilmePorId(Guid id)
        {
            FilmeModel filme = BuscarIdValidando(id);

            return
                new RequestRetorno<FilmeModel>()
                {
                    Informacao = filme,
                    Mensagens = new List<string>() { "Filme encontrado com sucesso!" }
                };
        }

        public RequestRetorno<FilmeModel> InserirFilme(FilmeModel model)
        {
            if (model.Descricao != null)
            {
                model.DescricaoId = InserirDescricao(model.Descricao);
            }


            model.Id = Guid.NewGuid();
            model.Descricao = null;
            _unitOfWork.FilmeRepository.Salvar(model);

            _unitOfWork.Commit();

            return new RequestRetorno<FilmeModel>()
            {
                Informacao = model
            };
        }

        private Guid InserirDescricao(DescricaoModel descricao)
        {
            descricao.Id = Guid.NewGuid();
            _unitOfWork.DescricaoRepository.Salvar(descricao);
            return descricao.Id;
        }

        public RequestRetorno<FilmeModel> AlterarFilme(FilmeModel model)
        {
            FilmeModel filmeCadastrado = BuscarIdValidando(model.Id);
            DescricaoModel descricaoCadastrada = null;

            // => ALTERANDO DESCRICAO
            if (filmeCadastrado.Descricao != null && model.Descricao != null)
            {
                filmeCadastrado.Descricao.Texto = model.Descricao.Texto;
                _unitOfWork.DescricaoRepository.Alterar(filmeCadastrado.Descricao);
            }
            // => INSERINDO NOVA DESCRICAO
            else if(filmeCadastrado.Descricao == null && model.Descricao != null)
            {
                filmeCadastrado.DescricaoId = InserirDescricao(model.Descricao);
            }
            // => EXCLUIR DESCRICAO
            else
            {
                descricaoCadastrada = filmeCadastrado.Descricao;
                filmeCadastrado.Descricao = null;
                filmeCadastrado.DescricaoId = null;
            }

            // => ALTERAR FILME
            filmeCadastrado.Nome = model.Nome;
            _unitOfWork.FilmeRepository.Alterar(filmeCadastrado);

            _unitOfWork.Commit();

            if (descricaoCadastrada != null)
                _unitOfWork.DescricaoRepository.Delete(descricaoCadastrada);

            _unitOfWork.Commit();

            return new RequestRetorno<FilmeModel>()
            {
                Informacao = model
            };
        }


        public RequestRetorno<string> RemoverFilme(Guid id)
        {
            _unitOfWork.FilmeRepository.Delete(BuscarIdValidando(id));

            return new RequestRetorno<string>()
            {
                Informacao = "Filme Deletado com sucesso!"
            };
        }

        private FilmeModel BuscarIdValidando(Guid id)
        {
            FilmeModel filme = _unitOfWork.FilmeRepository.BuscarPorId(id);
            if (filme is null)
            {
                throw new Exception("Id não encontrado !");
            }
            return filme;
        }
    }
}
