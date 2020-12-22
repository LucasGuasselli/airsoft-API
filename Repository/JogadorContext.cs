using Microsoft.EntityFrameworkCore;
using System;
using Dominio;
public class JogadorContext : DbContext
{
	public JogadorContext(DbContextOptions<JogadorContext> options) : base(options)
	{ 
	
	}

	public DbSet<Campo> Campos { get; set; }
	public DbSet<Equipe> Equipes { get; set; }
	public DbSet<Jogador> Jogadores { get; set; }
	public DbSet<JogadorPartida> JogadoresPartidas { get; set; }
	public DbSet<Partida> Partidas { get; set; }
	public DbSet<SolicitacaoJogadorEquipe> Solicitacoes { get; set; }
	

	//nao sei se pode faz os dois N:M no mesmo metodo - TESTE
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<JogadorPartida>(entity =>
		{
			entity.HasKey(e => new { e.JogadorId, e.PartidaId });
		});

		modelBuilder.Entity<SolicitacaoJogadorEquipe>(entity =>
		{
			entity.HasKey(e => new { e.JogadorId, e.EquipeId });
		});
	}

}
