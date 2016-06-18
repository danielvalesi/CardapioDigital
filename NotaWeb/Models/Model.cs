using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Adiciona essa linha
using System.Data.SqlClient;

namespace NotaWeb.Models
{
    // Implementa o Abstract e o IDisposable
    public abstract class Model : IDisposable
    {
        protected SqlConnection conn;

        public Model()
        {
            // String de conexão
            string strConn = @"Data source=localhost;
                               Initial Catalog=BDNotas;
                                Integrated Security=true";
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}