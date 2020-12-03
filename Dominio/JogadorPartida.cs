using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class JogadorPartida
    {
        public int JogadorId { get; set; }
        public int PartidaId { get; set; }
        public Boolean Aceito { get; set; }
        public string Comentario { get; set; }
        public Boolean Pago { get; set; }
    }
}
