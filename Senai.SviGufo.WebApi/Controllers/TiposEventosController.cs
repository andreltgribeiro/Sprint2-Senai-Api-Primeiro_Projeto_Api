using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]//Define a rota
    public class TiposEventosController : ControllerBase //Base de controller que não tem suporte para view
    {
        List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>()
            {
                new TipoEventoDomain{Id = 1, Nome = "Tecnologia"},
                new TipoEventoDomain{Id = 2, Nome = "Redes"},
                new TipoEventoDomain{Id = 3, Nome = "Games"}
            };

        /// <summary>
        /// Retorna uma Lista de eventos
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
        /// <returns>Retorna tipo do evento</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Busca um tipo de evento pelo ID
            TipoEventoDomain tipoEvento = tiposEventos.Find(x => x.Id == id);

            //Verifica se foi encontrado na lista o tipo de evento
            if(tipoEvento == null)
                //Retorna não encontrado
                return NotFound();

            //Retorna ok e o tipo de evento
            return Ok(tipoEvento);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TipoEventoDomain tipoEvento)
        {
            return Ok();
        }
        
    }
}