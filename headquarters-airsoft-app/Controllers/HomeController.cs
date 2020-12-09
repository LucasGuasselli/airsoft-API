using Dominio;
using headquarters_airsoft_app.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace headquarters_airsoft_app.Controllers
{
    public class HomeController : ControllerBase
    {

        public readonly JogadorContext _context;

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
