using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController] // Implementa funcionalidades no nosso controrller
    public class TiposEventosController : ControllerBase
    {
        List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>()
        {
            new TipoEventoDomain{ Id = 1, Nome = "Tecnologia"},
            new TipoEventoDomain{ Id = 2, Nome = "Redes"},
            new TipoEventoDomain{ Id = 3, Nome = "Desenvolvimento"},
            new TipoEventoDomain{ Id = 4, Nome = "Web Design"}
        };
        /// <summary>
        /// Retorna uma lista de tipos de eventos
        /// </summary>
        /// <returns>Lista de Eventos</returns>
        
        [HttpGet]
        public IEnumerable<TipoEventoDomain> Get()
        {
            return tiposEventos;
        }

        /// <summary>
        /// Busca o tipo de evento pelo Id
        /// </summary>
        /// <param name="id">Id do tipo de evento</param>
        /// <returns>Retorn um Tipo de evento</returns>
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Busca um tipo de evento pelo seu id
            TipoEventoDomain tipoEvento = tiposEventos.Find(x => x.Id == id);

            //Verifica se foi encontrado na lista o tipo de evento
            if(tipoEvento == null)
            {
                //retorna não encontrado
                return NotFound();
            }

            //retorna ok e o tipo de evento
            return Ok(tipoEvento);
        }

        /// <summary>
        /// Verbo para incluir um novo tipo de evento através do ID na url
        /// </summary>
        /// <param name="tipoEventoRecebido"></param>
        /// <returns>Ok</returns>
        [HttpPost]
        public IActionResult Post(TipoEventoDomain tipoEventoRecebido)
        {
            //Adciona o tipo de evento recebido na Api
            tiposEventos.Add(new TipoEventoDomain
            {
                Id = tiposEventos.Count + 1,
                Nome = tipoEventoRecebido.Nome
            });
            return Ok(tiposEventos);
        }
      
        /// <summary>
        /// Verbo para alterar um tipo de evento usando o id através da URL
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoEventoRecebido"></param>
        /// <returns>OK</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoEventoDomain tipoEventoRecebido)
        {
            return Ok();
        }

        /// <summary>
        /// Verbo para deletar um tipo de evento usando o id atrvés da URL
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            tiposEventos.Remove(tiposEventos.Find(x => x.Id == id));
            return Ok();
        }
    }
}