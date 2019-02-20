using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Intefaces;
using Senai.SviGufo.WebApi.Repositories;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="usuario">UsuarioDomain</param>
        /// <returns>Retorna um status code</returns>
        [HttpPost]
        public IActionResult Cadastrar(UsuarioDomain usuario)
        {
            try
            {
                UsuarioRepository.Cadastrar(usuario);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }



        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(UsuarioRepository.Listar());
        }

    }
}