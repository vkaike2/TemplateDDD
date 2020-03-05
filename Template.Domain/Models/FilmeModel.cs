using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Domain.Models
{
    public class FilmeModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public Guid? DescricaoId { get; set; }
        public DescricaoModel Descricao { get; set; }
    }
}
