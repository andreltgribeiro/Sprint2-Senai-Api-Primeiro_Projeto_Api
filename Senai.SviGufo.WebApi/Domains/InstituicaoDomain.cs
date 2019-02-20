using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Domains
{
    public class InstituicaoDomain
    {
        public int ID { get; set; }

        public string NomeFantasia { get; set; }

        [Required]
        public string RazaoSocial { get; set; }

        [StringLength(14, MinimumLength = 14)]
        public string CNPJ { get; set; }

        public string Logradouro { get; set; }

        [StringLength(8, MinimumLength = 8)]
        public string CEP{ get; set; }

        [StringLength(2, MinimumLength= 2)]
        public string UF { get; set; }

        public string Cidade { get; set; }

    }
}
