using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace Walmart.Data
{
    public class DataDAO
    {
        /// <summary>
        /// Cria conexão com o banco de dados
        /// </summary>
        /// <returns></returns>
        public static SqlConnection Conection()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
