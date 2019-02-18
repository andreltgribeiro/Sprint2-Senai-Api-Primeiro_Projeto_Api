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
    public class InstituicoesController : ControllerBase
    {

        private IInstituicaoRepository InstituicaoRepository{ get; set;}

        public InstituicoesController()
        {
            InstituicaoRepository = new InstituicaoRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(InstituicaoRepository.Listar());
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

            if (instituicao == null)
            {
                return NotFound();
            }
            return Ok(instituicao);
        }

        [HttpPost]
        public IActionResult Cadastrar(InstituicaoDomain instituicao)
        {
            try
            {
                InstituicaoRepository.Cadastrar(instituicao);

                var Lista = InstituicaoRepository.Listar();

                return Ok(Lista);
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, InstituicaoDomain instituicao)
        {
            InstituicaoDomain instituicaoBuscada = InstituicaoRepository.Buscar(id);
            if (instituicaoBuscada == null)
            {
                return NotFound();
            }

            try
            {
                InstituicaoRepository.Editar(instituicao, id);

                return Ok(instituicao);
            }
            catch
            {

                return NotFound();
            }
            
            
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            InstituicaoDomain instituicaoBuscada = InstituicaoRepository.Buscar(id);
            if (instituicaoBuscada == null)
            {
                return NotFound();
            }

            try
            {
                InstituicaoRepository.Deletar(id);

                return Ok();
            }
            catch
            {

                return NotFound();
            }
        }
    }
}