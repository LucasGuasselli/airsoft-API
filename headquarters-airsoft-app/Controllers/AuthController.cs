using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using headquarters_airsoft_app.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace headquarters_airsoft_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly JogadorContext _context;

        public AuthController(JogadorContext context) 
        {
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Jogador jogador)
        {
            var user = _context.Jogadores.Where(x => x.Email == jogador.Email && x.Senha == jogador.Senha).Single();

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválido!" });

            var token = TokenService.GenerateToken(user);
            user.Senha = "";

            return new
            {
                user = user,
                data = DateTime.Now,
                token = token
            };
        }

        [HttpPost]
        [Route("token")]
        [Authorize]
        public async Task<ActionResult<dynamic>> VerificaToken([FromBody] Jogador jogador)
        {
            var user = _context.Jogadores.Where(x => x.Email == jogador.Email && x.Senha == jogador.Senha).Single();

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválido!" });

            var token = TokenService.GenerateToken(user);
            user.Senha = "";

            return new
            {
                user = user,
                data = DateTime.Now,
                token = token
            };
        }


        //[HttpPost]
        //[Route("login")]
        //[AllowAnonymous]
        //public async Task<ActionResult<dynamic>> Authenticate([FromBody]Jogador jogador)
        //{
        //    var user = _context.Jogadores.Where(x => x.CPF == jogador.CPF).Single();

        //    if (user == null)
        //        return NotFound(new { message = "Usuário ou senha inválido" });

        //    var token = TokenService.GenerateToken(user);
        //    // user.Senha = "";
        //    return new
        //    {
        //        user = user,
        //        token = token
        //    };
        //}
    }

}

