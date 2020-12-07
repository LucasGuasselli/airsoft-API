using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class Partida
    {
        public int Id { get; set; }
        public int CampoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Boolean Restrito { get; set; }
        public float Preco { get; set; }
        public DateTime Data { get; set; }
        public char Periodo { get; set; }
        public Boolean Ativo { get; set; }


    }
}
