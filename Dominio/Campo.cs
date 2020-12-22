using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Campo
    {
        public Campo() 
        {
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrição { get; set; }
       // public Base64FormattingOptions Imagem { get; set; }
        public string Local { get; set; }

    }
}
