﻿using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Intefaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog =SENAI_SVIGUFO_APACHE;user id=sa; pwd=132";

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "SELECT ID, NOME, EMAIL, SENHA, TIPO_USUARIO FROM USUARIOS WHERE EMAIL = @EMAIL AND SENHA = @SENHA";

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    cmd.Parameters.AddWithValue("@SENHA", senha);

                    con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        UsuarioDomain usuario = new UsuarioDomain();

                        while (sdr.Read())
                        {
                            usuario.Id = Convert.ToInt32(sdr["ID"]);
                            usuario.Nome = sdr["NOME"].ToString();
                            usuario.Email = sdr["EMAIL"].ToString();
                            usuario.TipoUsuario = sdr["TIPO_USUARIO"].ToString();
                        }
                        return usuario;
                    }
                }
                return null;
            }
        }

        public void Cadastrar(UsuarioDomain usuario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryInsert = "INSERT INTO USUARIOS (NOME, EMAIL, SENHA, TIPO_USUARIO) " +
                                     "VALUES (@NOME, @EMAIL, @SENHA, @TIPO_USUARIO)";

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NOME", usuario.Nome);
                    cmd.Parameters.AddWithValue("@EMAIL", usuario.Email);
                    cmd.Parameters.AddWithValue("@SENHA", usuario.Senha);
                    cmd.Parameters.AddWithValue("@TIPO_USUARIO", usuario.TipoUsuario);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<UsuarioDomain> Listar()
        {
            List<UsuarioDomain> ListaComUsuarios = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "SELECT ID, NOME, EMAIL, SENHA, TIPO_USUARIO FROM USUARIOS";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand comandos = new SqlCommand(QuerySelect, con))
                {
                    reader = comandos.ExecuteReader();

                    while (reader.Read())
                    {
                        UsuarioDomain Usuario = new UsuarioDomain
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            Nome = reader["NOME"].ToString(),
                            Email = reader["EMAIL"].ToString(),
                            Senha = reader["SENHA"].ToString(),
                            TipoUsuario = reader["TIPO_USUARIO"].ToString()
                        };
                        ListaComUsuarios.Add(Usuario);
                    }
                }
            }
            return ListaComUsuarios;
        }
    }
}
