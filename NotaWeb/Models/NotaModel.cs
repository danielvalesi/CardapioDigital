using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NotaWeb.Entity;

namespace NotaWeb.Models
{
    public class NotaModel : Model
    {
        public List<Notas> Relatorio(int id)
        {
            List<Notas> lista = new List<Notas>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM Notas
                                WHERE IdDisciplina = @Id";

            cmd.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Notas n = new Notas();
                n.IdDisciplina = (int) reader["IdDisciplina"];
                n.IdAluno = (int)reader["IdAluno"];
                n.Disciplina = (string)reader["Disciplina"];
                n.Aluno = (string)reader["Aluno"];
                n.Nota = (decimal)reader["Nota"];

                lista.Add(n);

            }

            return lista;
        }
    }
}