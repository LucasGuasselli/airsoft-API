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
    public class SolicitacaoController : ControllerBase
    {
        public readonly JogadorContext _context;

        public SolicitacaoController(JogadorContext context)
        {
            _context = context;
        }

        // GET: api/<SolicitacaoController>
        [HttpGet]
        [Authorize]
        public ActionResult Get()
        {
            try
            {
                var solicitacoes = _context.Solicitacoes.ToList();
                    return Ok(solicitacoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }            
        }

        // GET api/<SolicitacaoController>/5
        [HttpGet("Jogador/{JogadorId}/Equipe/{EquipeId}")]
        [Authorize]
        public ActionResult Get(int JogadorId,int EquipeId)
        {
            try
            {
               var solicitacao = _context.Solicitacoes
                                 .Where(s => s.JogadorId == JogadorId && s.EquipeId == EquipeId)
                                 .FirstOrDefault();
                    return Ok(solicitacao);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex);
            } 
        }

        // POST api/<SolicitacaoController>
        [HttpPost]
        [Authorize]
        public ActionResult Post([FromBody] SolicitacaoJogadorEquipePayload payload)
        {
            try
            {
                var jogador = _context.Jogadores.Find(payload.JogadorId);
                var equipe = _context.Equipes.Find(payload.EquipeId);

                if (jogador != null && equipe != null)
                {
                    var solicitacao = new SolicitacaoJogadorEquipe();
                        solicitacao.JogadorId = payload.JogadorId;
                        solicitacao.EquipeId = payload.EquipeId;
                            _context.Solicitacoes.Add(solicitacao);
                            _context.SaveChanges();
                                return Ok("Solicitação Cadastrada");
                }
                return Ok("Jogador ou Equipe inválidos");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<SolicitacaoController>/5
        //[HttpPut("/{id}")]
        //[Authorize]
        //public ActionResult Put(int id, [FromBody] SolicitacaoJogadorEquipePayload payload)
        //{
        //    try
        //    {
        //        var jogador = _context.Jogadores.Find(payload.JogadorId);
        //        var equipe = _context.Equipes.Find(payload.EquipeId);

        //        if (jogador != null && equipe != null)
        //        {
        //            var solicitacao = new SolicitacaoJogadorEquipe();
        //            solicitacao.JogadorId = payload.JogadorId;
        //            solicitacao.EquipeId = payload.EquipeId;
        //            _context.Solicitacoes.Add(solicitacao);
        //            _context.SaveChanges();
        //            return Ok("Solicitação Cadastrada");
        //        }
        //        return Ok("Jogador ou Equipe inválidos");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}

        // DELETE api/<SolicitacaoController>/5
        [HttpDelete("Jogador/{JogadorId}/Equipe/{EquipeId}")]
        [Authorize]
        public ActionResult Delete(int JogadorId, int EquipeId)
        {
            try
            {
                var solicitacao = _context.Solicitacoes.Find(JogadorId, EquipeId);
                    _context.Remove(solicitacao);
                    _context.SaveChanges();
                        return Ok("Solicitação Deletada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
    }
}

public class SolicitacaoJogadorEquipePayload
{
    public int JogadorId { get; set; }
    public int EquipeId { get; set; }
}
