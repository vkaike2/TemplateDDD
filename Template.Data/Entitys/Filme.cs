using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Data.Entitys
{
    public class Filme
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public Guid? DescricaoId { get; set; }
        public Descricao Descricao { get; set; }
    }
}
