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
    public class PartidaController : ControllerBase
    {
        public readonly JogadorContext _context;

        public PartidaController(JogadorContext context)
        {
            _context = context;    
        }
        // GET: api/<PartidaController>
        [HttpGet]
        [Authorize]
        public ActionResult Get()
        {
            try
            {
                var partidas = _context.Partidas.ToList();
                    return Ok(partidas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<PartidaController>/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult Get(int id)
        {
            try
            {
                var partida = _context.Partidas.Find(id);
                    return Ok(partida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<PartidaController>
        [HttpPost]
        [Authorize]
        public ActionResult Post([FromBody] PartidaPayload payload)
        {
            try
            {
                var campo = _context.Campos.Find(payload.CampoId);
                if (campo != null)
                 {
                    var partida = new Partida();
                    partida.CampoId = payload.CampoId;
                    partida.Nome = payload.Nome;
                    partida.Descricao = payload.Descricao;
                    partida.Restrito = payload.Restrito;
                    partida.Preco = payload.Preco;
                    partida.Data = payload.Data;
                    partida.Periodo = payload.Periodo;
                    partida.Ativo = payload.Ativo;

                    _context.Partidas.Add(partida);
                    _context.SaveChanges();
                        return Ok("Partida Cadastrada");
                }
                    return Ok("Campo Inválido");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<PartidaController>/5
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult Put(int id, [FromBody] PartidaPayload payload)
        {
            try
            {
                var partida = _context.Partidas.Find(id);
                partida.CampoId = payload.CampoId;
                partida.Nome = payload.Nome;
                partida.Descricao = payload.Descricao;
                partida.Restrito = payload.Restrito;
                partida.Preco = payload.Preco;
                partida.Data = payload.Data;
                partida.Periodo = payload.Periodo;
                partida.Ativo = payload.Ativo;

                _context.Partidas.Update(partida);
                _context.SaveChanges();
                    return Ok("Partida Editada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/<PartidaController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            try
            {
                var partida = _context.Partidas.Find(id);
                _context.Remove(partida);
                _context.SaveChanges();
                    return Ok("Partida Deletada");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex);
            }
        }
    }
}

    public class PartidaPayload
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