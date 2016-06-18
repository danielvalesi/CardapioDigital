using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// add notaweb
using NotaWeb.Entity;
using System.Data.SqlClient;

namespace NotaWeb.Models
{
    public class ProfessorModel : Model
    {
        public List<Professor> Read()
        {
            List<Professor> lista = new List<Professor>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT p.Id, p.Nome, p.Email, pr.Titulo
                                FROM Pessoa p, Professor pr
                                WHERE p.Id = pr.Id";

            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Professor pr = new Professor();
                pr.Id = (int)reader["Id"];
                pr.Nome = (string)reader["Nome"];
                pr.Email = (string)reader["Email"];
                pr.Titulo = (string)reader["Titulo"];



                lista.Add(pr);
            }

            return lista;
        }

        public void Create(Professor professor)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            // usando a procedure
            cmd.CommandText = "InsereProfessor";
            // chama o exec
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nome", professor.Nome);
            cmd.Parameters.AddWithValue("@email", professor.Email);
            cmd.Parameters.AddWithValue("@senha", professor.Senha);
            cmd.Parameters.AddWithValue("@titulo", professor.Titulo);

            cmd.ExecuteNonQuery();
        }
    }
}