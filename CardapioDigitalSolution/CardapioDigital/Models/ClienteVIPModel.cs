using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CardapioDigital.Entity;
using System.Data.SqlClient;

namespace CardapioDigital.Models
{
    public class ClienteVIPModel : Model
    {
        public List<ClienteVIP> Read()
        {
            List<ClienteVIP> lista = new List<ClienteVIP>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT p.Id, p.Nome, p.Email, pr.Titulo
                                FROM Pessoa p, Professor pr
                                WHERE p.Id = pr.Id";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ClienteVIP cli = new ClienteVIP();
                cli.Id = (int)reader["Id"];
                cli.Nome = (string)reader["Nome"];
                cli.Email = (string)reader["Email"];
                cli.Titulo = (string)reader["Titulo"];

                lista.Add(cli);
            }

            return lista;
        }

        public void Create(ClienteVIP clienteVip)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            // usando a procedure
            cmd.CommandText = "InsereProfessor";
            // chama o exec
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nome", clienteVip.Nome);
            cmd.Parameters.AddWithValue("@email", clienteVip.Email);
            cmd.Parameters.AddWithValue("@senha", clienteVip.Senha);
            cmd.Parameters.AddWithValue("@titulo", clienteVip.Titulo);

            cmd.ExecuteNonQuery();
        }
    }
}