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
    public class InstituicaoController : ControllerBase
    {

        private IInstituicaoRepository InstituicaoRepository{ get; set;}

        public InstituicaoController()
        {
            InstituicaoRepository = new InstituicaoRepository();
        }

        [HttpGet]
        public IEnumerable<InstituicaoDomain> Listar()
        {
            return InstituicaoRepository.Listar();
        }

        //[HttpGet("{id}")]
        //public IActionResult BuscarPorID(int id)
        //{
        //    InstituicaoDomain instituicao = InstituicaoRepository.Listar().Find(x => x.ID == id);

        //    if(instituicao == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(instituicao);
        //}

        [HttpGet("{id}")]
        public IActionResult BuscarPorID(int id)
        {
            // verificar primeiro se a instituicao foi encontrada pelo id - 10
            InstituicaoDomain instituicao = new InstituicaoDomain();
            instituicao = InstituicaoRepository.Buscar(id);

            return Ok(instituicao);
        }

        [HttpPost]
        public IActionResult Cadastrar(InstituicaoDomain instituicao)
        {
            InstituicaoRepository.Cadastrar(instituicao);

            var Lista = InstituicaoRepository.Listar();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, InstituicaoDomain instituicao)
        {
            instituicao.ID = id;
            InstituicaoRepository.Editar(instituicao);
            return Ok(instituicao);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            InstituicaoRepository.Deletar(id);
            return Ok();
        }
    }
}