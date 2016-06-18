using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using NotaWeb.Entity;

namespace NotaWeb.Models
{
    public class UsuarioModel : Model
    {
        public Pessoa Login(string email, string senha)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"select * from Usuario 
                where Email = @email AND Senha = @senha";

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                // Polimorfismo
                if ((string)reader["Tipo"] == "Professor")
                {
                    Professor professor = new Professor();
                    professor.Id = (int)reader["Id"];
                    professor.Nome = (string)reader["Nome"];
                    professor.Email = (string)reader["Email"];
                    professor.Tipo = (string)reader["Tipo"];
                    professor.Titulo = (string)reader["Titulo"];

                    return professor;
                }
                else
                {
                    Aluno aluno = new Aluno();
                    aluno.Id = (int)reader["Id"];
                    aluno.Nome = (string)reader["Nome"];
                    aluno.Email = (string)reader["Email"];
                    aluno.Tipo = (string)reader["Tipo"];

                    return aluno;
                }
            }

            return null;
        }
    }
}