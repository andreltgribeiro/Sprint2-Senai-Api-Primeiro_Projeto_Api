using Senai.SviGufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Intefaces
{
    public interface ITipoEventoRepository
    {
        /// <summary>
        /// Lista todos os tipos de eventos
        /// </summary>
        /// <returns>Retorna uma lista de tipo de eventos</returns>
        List<TipoEventoDomain> Listar();

        //Insere um novo tipo de Evento no Banco de Dados
        void Cadastrar(TipoEventoDomain tipoEvento);

        /// <summary>
        /// Altera um tipo de evento
        /// </summary>
        /// <param name="TipoEventoDomain"></param>
        void Alterar(TipoEventoDomain tipoEvento);

        void Deletar(int id);
    }
}
