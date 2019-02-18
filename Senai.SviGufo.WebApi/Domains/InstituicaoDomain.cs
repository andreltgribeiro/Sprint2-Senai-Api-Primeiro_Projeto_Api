using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Domains
{
    public class InstituicaoDomain
    {
        public int ID { get; set; }

        public string NomeFantasia { get; set; }

        public string RazaoSocial { get; set; }

        public string CNPJ { get; set; }

        public string Logradouro { get; set; }

        public string CEP{ get; set; }

        public string UF { get; set; }

        public string Cidade { get; set; }

    }
}
