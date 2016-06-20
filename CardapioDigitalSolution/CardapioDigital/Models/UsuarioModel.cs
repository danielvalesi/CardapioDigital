using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using CardapioDigital.Entity;


namespace CardapioDigital.Models
{
    public class UsuarioModel : Model
    {
        public Pessoa Login(string email, string senha)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"select * from Usuarios 
                where Email = @email AND Senha = @senha";

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                // Polimorfismo
                if ((string)reader["Tipo"] == "ClienteVIP")
                {
                    ClienteVIP clienteVip = new ClienteVIP();
                    clienteVip.Id = (int)reader["Id"];
                    clienteVip.Nome = (string)reader["Nome"];
                    clienteVip.Email = (string)reader["Email"];
                    clienteVip.Tipo = (string)reader["Tipo"];
                    clienteVip.Titulo = (string)reader["Titulo"];

                    return clienteVip;
                }
                else
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.Id = (int)reader["Id"];
                    funcionario.Nome = (string)reader["Nome"];
                    funcionario.Email = (string)reader["Email"];
                    funcionario.Tipo = (string)reader["Tipo"];

                    return funcionario;
                }
            }

            return null;
        }
    }
}