using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Domains
{
    public class UsuarioDomain
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Informe o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Indorme o Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe o tipo de usuário")]
        public string TipoUsuario { get; set; }
    }
}
