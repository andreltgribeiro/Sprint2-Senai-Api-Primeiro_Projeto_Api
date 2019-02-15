using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Intefaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private string StringConexaoBD = "Data Source=.\\SqlExpress; initial catalog=SENAI_SVIGUFO_APACHE;user id=sa; pwd=132";

        public List<InstituicaoDomain> Listar()
        {
            List<InstituicaoDomain> ListaComInstituicoes = new List<InstituicaoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexaoBD))
            {
                string QuerySeraExecutada = "SELECT ID, NOME_FANTASIA, RAZAO_SOCIAL, CNPJ, LOGRADOURO, CEP, UF, CIDADE FROM INSTITUICOES";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand comandos = new SqlCommand(QuerySeraExecutada, con))
                {
                    reader = comandos.ExecuteReader();

                    while (reader.Read())
                    {
                        InstituicaoDomain instituicao = new InstituicaoDomain
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            NomeFantasia = reader["NOME_FANTASIA"].ToString(),
                            RazaoSocial = reader["RAZAO_SOCIAL"].ToString(),
                            CNPJ = reader["CNPJ"].ToString(),
                            Logradouro = reader["LOGRADOURO"].ToString(),
                            CEP = reader["CEP"].ToString(),
                            UF = reader["UF"].ToString(),
                            Cidade = reader["CIDADE"].ToString()
                        };
                        ListaComInstituicoes.Add(instituicao);
                    }
                }
            }
            return ListaComInstituicoes;
        }

        public void Cadastrar(InstituicaoDomain instituicao)
        {
            using (SqlConnection con = new SqlConnection(StringConexaoBD))
            {
                string QuerySeraExecutada = "INSERT INTO INSTITUICOES(NOME_FANTASIA, RAZAO_SOCIAL, CNPJ, LOGRADOURO, CEP, UF, CIDADE) VALUES(@NOME_FANTASIA, @RAZAO_SOCIAL, @CNPJ, @LOGRADOURO, @CEP, @UF, @CIDADE)";

                SqlCommand comandos = new SqlCommand(QuerySeraExecutada, con);

                comandos.Parameters.AddWithValue("@NOME_FANTASIA", instituicao.NomeFantasia);
                comandos.Parameters.AddWithValue("@RAZAO_SOCIAL", instituicao.RazaoSocial);
                comandos.Parameters.AddWithValue("@CNPJ", instituicao.CNPJ);
                comandos.Parameters.AddWithValue("@LOGRADOURO", instituicao.Logradouro);
                comandos.Parameters.AddWithValue("@CEP", instituicao.CEP);
                comandos.Parameters.AddWithValue("@UF", instituicao.UF);
                comandos.Parameters.AddWithValue("@CIDADE", instituicao.Cidade);

                con.Open();

                comandos.ExecuteNonQuery();

            }
        }

        public void Editar (InstituicaoDomain instituicao)
        {
            using (SqlConnection con = new SqlConnection(StringConexaoBD))
            {
                string QuerySeraExecutada = "UPDATE INSTITUICOES SET NOME_FANTASIA = @NOME_FANTASIA, RAZAO_SOCIAL = @RAZAO_SOCIAL, CNPJ = @CNPJ, LOGRADOURO = @LOGRADOURO, CEP = @CEP, UF = @UF, CIDADE = @CIDADE WHERE ID = @ID";

                SqlCommand comando = new SqlCommand(QuerySeraExecutada, con);

                comando.Parameters.AddWithValue("@NOME_FANTASIA", instituicao.NomeFantasia);
                comando.Parameters.AddWithValue("@RAZAO_SOCIAL", instituicao.RazaoSocial);
                comando.Parameters.AddWithValue("@CNPJ", instituicao.CNPJ);
                comando.Parameters.AddWithValue("@LOGRADOURO", instituicao.Logradouro);
                comando.Parameters.AddWithValue("@CEP", instituicao.CEP);
                comando.Parameters.AddWithValue("@UF", instituicao.UF);
                comando.Parameters.AddWithValue("@CIDADE", instituicao.Cidade);
                comando.Parameters.AddWithValue("@ID", instituicao.ID);

                con.Open();

                comando.ExecuteNonQuery();


            }
            return ;
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexaoBD))
            {
                string QueryaSerExecutada = "DELETE FROM INSTITUICOES WHERE ID = @ID";

                SqlCommand comando = new SqlCommand(QueryaSerExecutada, con);

                comando.Parameters.AddWithValue("@ID", id);

                con.Open();

                comando.ExecuteNonQuery();
            }

        }

        public InstituicaoDomain Buscar(int id)
        {

            using (SqlConnection con = new SqlConnection(StringConexaoBD))
            {
                SqlDataReader reader;

                con.Open();

                string QueryaSerExecutada = "SELECT ID, NOME_FANTASIA, RAZAO_SOCIAL, CNPJ, LOGRADOURO, CEP, UF, CIDADE FROM INSTITUICOES WHERE ID = @ID";

                using (SqlCommand comandos = new SqlCommand(QueryaSerExecutada, con))
                {
                    comandos.Parameters.AddWithValue("@ID", id);
                    reader = comandos.ExecuteReader();

                    while (reader.Read())
                    {
                        InstituicaoDomain instituicao = new InstituicaoDomain
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            NomeFantasia = reader["NOME_FANTASIA"].ToString(),
                            RazaoSocial = reader["RAZAO_SOCIAL"].ToString(),
                            CNPJ = reader["CNPJ"].ToString(),
                            Logradouro = reader["LOGRADOURO"].ToString(),
                            CEP = reader["CEP"].ToString(),
                            UF = reader["UF"].ToString(),
                            Cidade = reader["CIDADE"].ToString()
                        };
                        return instituicao;
                        
                    }
                }
            }
            return null;
        }
    }
}
