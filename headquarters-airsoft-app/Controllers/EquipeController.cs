using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace headquarters_airsoft_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipeController : ControllerBase
    {
        public readonly JogadorContext _context;
        public EquipeController(JogadorContext context)
        {
            _context = context;
        }

        // GET: api/<EquipeController>
        [HttpGet]
        [Authorize]
        public ActionResult Get()
        {
            var Equipes = _context.Equipes.ToList();
            return Ok(Equipes);
        }

        // GET api/<EquipeController>/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult Get(int id)
        {
            var equipe = _context.Equipes.Find(id);
                return Ok(equipe);
        }

        // POST api/<EquipeController>
        [HttpPost]
        [Authorize]
        public EquipeViewModel Post([FromBody] EquipePayload payload)
        {
            EquipeViewModel viewModel = new EquipeViewModel();
            var novaEquipe = new Equipe();
            novaEquipe.Nome = payload.Nome;
            novaEquipe.Tag = payload.Tag;
            novaEquipe.Data = payload.Data;
            novaEquipe.jogadores = new List<Jogador>();
                viewModel.Data = novaEquipe;

            _context.Equipes.Add(novaEquipe);
            _context.SaveChanges();
                return viewModel;
        }

        // PUT api/<EquipeController>/5
        [HttpPut("{id}")]
        [Authorize]
        public EquipeViewModel Put(int id, [FromBody] EquipePayload payload)
        {
            EquipeViewModel viewModel = new EquipeViewModel();

            var equipe = _context.Equipes.Find(id);
                if (payload.Nome != null)
                {
                    equipe.Nome = payload.Nome;
                }
                if (payload.Tag != null)
                {
                    equipe.Tag = payload.Tag;
                }
               
                viewModel.Data = equipe;
            _context.Equipes.Update(equipe);
            _context.SaveChanges();
                return viewModel;
        }

        // DELETE api/<EquipeController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            var equipe = _context.Equipes.Where(x => x.Id == id).Single();

            _context.Equipes.Remove(equipe);
            _context.SaveChanges();
                return Ok("Equipe Deletado");
        }
    }
}

public class EquipePayload
{
    public string Nome { get; set; }
    public string Tag { get; set; }
    public DateTime Data { get; set; }
}

public class EquipeViewModel
{
    public Equipe Data { get; set; }
}
