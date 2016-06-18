using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Adiciona essa linha
using System.Data.SqlClient;
// Disciplina em outro namespace
using NotaWeb.Entity;


namespace NotaWeb.Models
{
    // Puxa do Model
    public class DisciplinaModel : Model
    {
        public void Create(Disciplina entity)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into Disciplina values (@idProfessor, @nome)";

            cmd.Parameters.AddWithValue("@idProfessor", entity.IdProfessor);
            cmd.Parameters.AddWithValue("@nome", entity.Nome);

            cmd.ExecuteNonQuery();
        }

        internal List<Disciplina> Read(int id)
        {
            List<Disciplina> lista = new List<Disciplina>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM Disciplina
                                WHERE IdProfessor = @Id";

            cmd.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Disciplina d = new Disciplina();
                d.Id = (int)reader["Id"];
                d.IdProfessor = (int)reader["IdProfessor"];
                d.Nome = (string)reader["Nome"];

                lista.Add(d);
            }

            return lista;
        }
    }
}