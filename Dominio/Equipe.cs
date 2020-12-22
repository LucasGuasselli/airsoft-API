using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Equipe
    {
        public Equipe()
        { 
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tag { get; set; }
        public DateTime Data { get; set; }
       // public Base64FormattingOptions Imagem { get; set; }


    }
}
