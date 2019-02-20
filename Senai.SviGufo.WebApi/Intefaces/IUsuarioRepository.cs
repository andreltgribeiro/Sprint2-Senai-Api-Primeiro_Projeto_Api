using Senai.SviGufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Intefaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">UsuarioDomain</param>
        void Cadastrar(UsuarioDomain usuario);

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns></returns>
        List<UsuarioDomain> Listar();

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">Email do usuario</param>
        /// <param name="senha">senha do usuario</param>
        /// <returns>UsuarioDomain</returns>
        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}
