﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Intefaces;
using Senai.SviGufo.WebApi.Repositories;
using Senai.SviGufo.WebApi.ViewModels;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IUsuarioRepository UsuarioRepository { get; set; }

        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }
        [HttpPost]
        public IActionResult Validar(LoginViewModel login)
        {
            try
            {
                UsuarioDomain usuarioBuscado = UsuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Email ou senha inválido"
                    });
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("svigufo-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "SviGufo.WebApi",
                    audience: "SviGufo.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                return Ok(new {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch
            {
                return BadRequest();
            }
            
        }
    }
}