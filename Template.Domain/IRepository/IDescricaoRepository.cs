using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Models;

namespace Template.Domain.IRepository
{
    public interface IDescricaoRepository
    {
        void Salvar(DescricaoModel descricao);
        void Alterar(DescricaoModel descricao);
        void Delete(DescricaoModel descricao);
    }
}
