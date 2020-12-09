using Microsoft.EntityFrameworkCore;
using System;
using Dominio;
public class JogadorContext : DbContext
{
	public JogadorContext(DbContextOptions<JogadorContext> options) : base(options)
	{ 
	
	}
		
	public DbSet<Jogador> Jogadores { get; set; }	
    
}
