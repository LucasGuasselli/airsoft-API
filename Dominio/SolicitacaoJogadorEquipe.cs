using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class SolicitacaoJogadorEquipe
    {
        public SolicitacaoJogadorEquipe()
        { 
        }
        public int JogadorId { get; set; }
        public Jogador jogador { get; set; }
        public int EquipeId { get; set; }
        public Equipe equipe { get; set; }
    }
}
