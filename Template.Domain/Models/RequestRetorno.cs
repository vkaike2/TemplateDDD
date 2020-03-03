using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Domain.Models
{
    public class RequestRetorno<T>
    {
        public T Informacao { get; set; }
        public List<string> Mensagens { get; set; }
        public bool Erro { get; set; }
    }
}
