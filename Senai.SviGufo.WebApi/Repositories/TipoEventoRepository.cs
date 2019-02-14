using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Intefaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        //Declarra uma string de conexão com o banco de dados
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=SENAI_SVIGUFO_APACHE;user id=sa; pwd=132";

        /// <summary>
        /// Lista todos os tipos de evento
        /// </summary>
        /// <returns></returns>
        public List<TipoEventoDomain> Listar()
        {
            List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>();

            //Declaro a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a ainstrução a ser executada
                string QueryaSerExecutada = "SELECT ID, TITULO FROM TIPOS_EVENTOS";

                //Abre o banco de dados
                con.Open();

                //Declara um SqlDataReader para percorrer a lista
                SqlDataReader rdr;

                //Declara um command passando o comando a ser executado e string de conexão
                using (SqlCommand cmd = new SqlCommand(QueryaSerExecutada, con))
                {
                    //Executa a query
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoEventoDomain tipoEvento = new TipoEventoDomain
                        {
                            Id = Convert.ToInt32(rdr["ID"]),
                            Nome = rdr["TITULO"].ToString()
                        };

                        tiposEventos.Add(tipoEvento);
                    }
                }
            }
            return tiposEventos;
        }

        /// <summary>
        /// Cadastra um novo tipo de evneto
        /// </summary>
        /// <param name="tipoEvento"></param>
        public void Cadastrar (TipoEventoDomain tipoEvento)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara o que vai ser inserido na query colocando dentro de values a declaração de uma variável
                string QueryaSerExecutada = "INSER INTO TIPOS_EVENTOS(TITULO) VALUES (@TITULO)";

                //Declara o command passando a query e a conecão como parametro
                SqlCommand cmd = new SqlCommand(QueryaSerExecutada, con);

                //Passa o valor do parametro
                cmd.Parameters.AddWithValue("@TITULO", tipoEvento.Nome);

                //Abre a conexão
                con.Open();

                //Executa o comando
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Altera um tipo de Evento
        /// </summary>
        /// <param name="tipoEvento"></param>
        public void Alterar(TipoEventoDomain tipoEvento)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Define os comandos a serem executados no banco de dados
                string QueryaSerExecutada = "UPDATE TIPOS_EVENTOS SET TITULO = TITULO WHERE ID = @ID";

                //Define a query a ser executada e a linha de conexão
                SqlCommand cmd = new SqlCommand(QueryaSerExecutada, con);

                //Determina pelo que a variavel vai ser substituida
                cmd.Parameters.AddWithValue("@TITULO", tipoEvento.Nome);
                
                //Determina pelo que a variavel vai ser substituida
                cmd.Parameters.AddWithValue("@ID", tipoEvento.Id);

                //Abre o basco
                con.Open();

                //Executa a query e não retorna nenhum valor
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Deleta um tipo de evento
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Determina os comando a serem executados no banco de dados
                string QueryaSerExecutada = "DELETE FROM TIPO_EVENTOS WHERE ID = @ID";

                //Determina a query a ser executada e a linha de conexão
                SqlCommand cmd = new SqlCommand(QueryaSerExecutada, con);

                //Substitui o valor da variável e  substiitui pela variável real
                cmd.Parameters.AddWithValue("@ID", id);

                //Abre o banco de dados
                con.Open();

                //Executa a query e não retorna nada
                cmd.ExecuteNonQuery();
            }

        }
    
    }
}
