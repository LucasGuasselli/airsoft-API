
using System;

namespace Dominio
{
	public class Jogador
	{
		public Jogador()
		{
		}

		public int Id { get; set; }
		public int EquipeId { get; set; }
		public int CampoId { get; set; }
		public Boolean CampoADM { get; set; }
		public string Nome { get; set; }
		public string CPF { get; set; }
		public string NomeMae { get; set; }
		public DateTime DataNascimento { get; set; }
		public string Email { get; set; }
        // public string Senha { get; set; }
        //	public Base64 Imagem { get; set; }
        public string Descricao { get; set; }

	}
}