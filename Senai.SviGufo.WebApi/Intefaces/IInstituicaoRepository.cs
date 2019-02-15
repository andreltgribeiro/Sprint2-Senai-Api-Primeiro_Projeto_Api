using Senai.SviGufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Intefaces
{
    interface IInstituicaoRepository
    {
        List<InstituicaoDomain> Listar();

        InstituicaoDomain Buscar(int id);

        void Cadastrar(InstituicaoDomain instituicao);

        void Editar(InstituicaoDomain instituicao);

        void Deletar(int id);

    }
}
