using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace CardapioDigital.Models
{
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