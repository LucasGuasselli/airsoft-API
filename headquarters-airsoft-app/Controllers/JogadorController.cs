﻿using System;
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

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
        
            var jogador = _context.Jogadores.Find(id);
            return Ok(jogador);
        }

        [HttpPost]
        public JogadorViewModel Post([FromBody] JogadorPayload payload)
        {
            JogadorViewModel viewModel = new JogadorViewModel();
            var novoJogador = new Jogador();
            novoJogador.CPF = payload.CPF;
            novoJogador.Email = payload.Email;
            novoJogador.Nome = payload.Nome;
            //jogador.Senha = payload.Senha; 
            viewModel.Data = novoJogador;

            _context.Jogadores.Add(novoJogador);
            _context.SaveChanges();           

            return viewModel;
        }

        [HttpPut("{id}")]
        public JogadorViewModel Put(int id, [FromBody] JogadorPayload payload)
        {
            JogadorViewModel viewModel = new JogadorViewModel();

            var jogador = _context.Jogadores.Find(id);
            jogador.CPF = payload.CPF;
            jogador.Email = payload.Email;
            jogador.Nome = payload.Nome;
            //jogador.Senha = payload.Senha;            
            viewModel.Data = jogador;

            _context.SaveChanges();

            return viewModel;
        }

        // DELETE
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        {
            var jogador = _context.Jogadores.Where(x => x.Id == id).Single();

            _context.Jogadores.Remove(jogador);
            _context.SaveChanges();
            return Ok("Jogador Deletado");
        }

        [HttpGet]
        public ActionResult Get()
        {         
            var jogadores = _context.Jogadores.ToList();
            return Ok(jogadores);
        }

    }

    public class JogadorPayload
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }

    public class JogadorViewModel
    {
        public Jogador Data{ get; set; }
    }
}