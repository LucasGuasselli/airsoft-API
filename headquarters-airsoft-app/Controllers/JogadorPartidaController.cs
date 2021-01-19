using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace headquarters_airsoft_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorPartidaController : ControllerBase
    {

        public readonly JogadorContext _context;
        public JogadorPartidaController(JogadorContext context)
        {
            _context = context;
        }

        // GET: api/<JogadorPartidaController>
        [HttpGet]
        [Authorize]
        public ActionResult Get()
        {
            try
            {
                var jogadoresPartidas = _context.JogadoresPartidas.ToList();
                    return Ok(jogadoresPartidas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<JogadorPartidaController>/5
        [HttpGet("Jogador/{JogadorId}/Partida/{PartidaId}")]
        [Authorize]
        public ActionResult Get(int JogadorId, int PartidaId)
        {
            try
            {
                var jogadorPartida = _context.JogadoresPartidas
                                  .Where(s => s.JogadorId == JogadorId && s.PartidaId == PartidaId)
                                  .FirstOrDefault();
                return Ok(jogadorPartida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<JogadorPartidaController>
        [HttpPost]
        [Authorize]
        public ActionResult Post([FromBody] JogadorPartidaPayload payload)
        {
            try
            {
                var jogador = _context.Jogadores.Find(payload.JogadorId);
                var partida = _context.Equipes.Find(payload.PartidaId);

                if (jogador != null && partida != null)
                {
                    var jogadorPartida = new JogadorPartida();
                    jogadorPartida.JogadorId = payload.JogadorId;
                    jogadorPartida.PartidaId = payload.PartidaId;
                    jogadorPartida.Aceito = payload.Aceito;
                    jogadorPartida.Comentario = payload.Comentario;
                    jogadorPartida.Pago = payload.Pago;
                    
                    _context.JogadoresPartidas.Add(jogadorPartida);
                    _context.SaveChanges();
                        return Ok("JogadorPartida Cadastrada");
                }
                return Ok("Jogador ou Equipe inválidos");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<JogadorPartidaController>/5
        [HttpPut("Jogador/{JogadorId}/Partida/{PartidaId}")]
        [Authorize]
        public ActionResult Put(int JogadorId, int PartidaId, [FromBody] JogadorPartidaPayload payload)
        {
            try
            {
                var jogadorPartida = _context.JogadoresPartidas
                                   .Where(s => s.JogadorId == JogadorId && s.PartidaId == PartidaId)
                                   .FirstOrDefault();                
                   
                    jogadorPartida.Aceito = payload.Aceito;
                    jogadorPartida.Comentario = payload.Comentario;
                    jogadorPartida.Pago = payload.Pago;

                    _context.JogadoresPartidas.Update(jogadorPartida);
                    _context.SaveChanges();
                        return Ok("JogadorPartida Cadastrada");                
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/<JogadorPartidaController>/5
        [HttpDelete("Jogador/{JogadorId}/Partida/{PartidaId}")]
        [Authorize]
        public ActionResult Delete(int JogadorId, int PartidaId)
        {
            try
            {
                var jogadorPartida = _context.JogadoresPartidas
                                  .Where(s => s.JogadorId == JogadorId && s.PartidaId == PartidaId)
                                  .FirstOrDefault();
                _context.JogadoresPartidas.Remove(jogadorPartida);
                _context.SaveChanges();
                    return Ok("JogadorPartida deletado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

public class JogadorPartidaPayload
{
    public int JogadorId { get; set; }
    public Jogador jogador { get; set; }
    public int PartidaId { get; set; }
    public Partida partida { get; set; }
    public Boolean Aceito { get; set; }
    public string Comentario { get; set; }
    public Boolean Pago { get; set; }
}
