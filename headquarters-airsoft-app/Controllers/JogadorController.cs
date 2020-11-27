using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorController : ControllerBase
    {
        public readonly JogadorContext _context;
        public JogadorController(JogadorContext context)
        {
            _context = context;
        }

        //GET
        [HttpGet]
        public ActionResult Get()
        {

            var jogadores = _context.Jogadores;

             return Ok(jogadores);
        }

        // GET api/jogador/5
        [HttpGet("{nameJogador}")]
        public ActionResult Get(string nameJogador)
        {
            var jogador = new Jogador { Nome = nameJogador };

            _context.Jogadores.Add(jogador);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE
        [HttpDelete("{id}")]
        public void Delete(int id) 
        {
            var jogador = _context.Jogadores.Where(x => x.Id == id).Single();

            _context.Jogadores.Remove(jogador);
            _context.SaveChanges();
        }

    }
}