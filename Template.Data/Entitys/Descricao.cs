using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Data.Entitys
{
    public class Descricao
    {
        public Guid Id { get; set; }
        public string Texto { get; set; }
        public virtual Filme Filme { get; set; }
    }
}
