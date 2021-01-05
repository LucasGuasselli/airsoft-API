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
    public class CampoController : ControllerBase
    {
        public readonly JogadorContext _context;

        public CampoController(JogadorContext context)
        {
            _context = context;
        }

        // GET: api/<CampoController>
        [HttpGet]
        [Authorize]
        public ActionResult Get()
        {
            try
            {
                var campos = _context.Campos.ToList();
                    return Ok(campos);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex);        
            }               
        }

        // GET api/<CampoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var campo = _context.Campos.Find(id);
                    return Ok(campo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<CampoController>
        [HttpPost]
        [Authorize]
        public ActionResult Post([FromBody] CampoPayload payload)
        {
            try
            {
                var campo = new Campo();
                    campo.Nome = payload.Nome;
                    campo.Descricao = payload.Descricao;
                    campo.Local = payload.Local;

                _context.Campos.Add(campo);
                _context.SaveChanges();
                    return Ok("Campo Cadastrado");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<CampoController>/5
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult Put(int id, [FromBody] CampoPayload payload)
        {
            try
            {
                var campo = _context.Campos.Find(id);

                campo.Nome = payload.Nome;
                campo.Descricao = payload.Descricao;
                campo.Local = payload.Local;

                _context.Campos.Update(campo);
                _context.SaveChanges();
                      return Ok("Campo Editado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // DELETE api/<CampoController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            try
            {
                var campo = _context.Campos.Where(x => x.Id == id).Single();
                    _context.Campos.Remove(campo);
                    _context.SaveChanges();
                        return Ok("Campo Deletado");    
            }
            catch (Exception ex) 
            {
                return BadRequest(ex);
            }            
        }
    }
}

    public class CampoPayload 
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Local { get; set; }
    }
