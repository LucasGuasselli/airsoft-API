using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class JogadorPartida
    {
        public JogadorPartida()
        { 
        }
        public int JogadorId { get; set; }
        public Jogador jogador { get; set; }
        public int PartidaId { get; set; }
        public Partida partida { get; set; }
        public Boolean Aceito { get; set; }
        public string Comentario { get; set; }
        public Boolean Pago { get; set; }
    }
}
