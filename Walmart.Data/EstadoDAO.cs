using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Walmart.Entity;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Walmart.Data
{
    public class EstadoDAO : DataDAO
    {
        private static Func<IDataReader, Estado> drEstado = reader => new Estado()
        {
            Codigo = Convert.ToInt32(reader["Codigo"]),
            Nome = reader["nome"].ToString(),
            Pais = reader["Pais"].ToString(),
            Regiao = reader["Regiao"].ToString(),
            Sigla = reader["Sigla"].ToString()
        };


        #region "CRUD"

        public static void Adicionar(Estado prEstado)
        {
            try
            {
                using (SqlConnection conn = DataDAO.Conection())
                {
                    string commandStr = "INSERT INTO ESTADO VALUES(@Pais,@Nome,@Sigla,@Regiao)";
                    SqlCommand command = new SqlCommand(commandStr, conn);
                    command.Parameters.AddWithValue("@Pais", prEstado.Pais);
                    command.Parameters.AddWithValue("@Nome", prEstado.Nome);
                    command.Parameters.AddWithValue("@Sigla", prEstado.Sigla);
                    command.Parameters.AddWithValue("@Regiao", prEstado.Regiao);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static List<Estado> Listar()
        {
            try
            {
                List<Estado> lstEstados = new List<Estado>();
                using (SqlConnection conn = DataDAO.Conection())
                {
                    string commandStr = "SELECT * FROM ESTADO";
                    SqlCommand command = new SqlCommand(commandStr, conn);
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        lstEstados.Add(drEstado(dr));
                    }

                    return lstEstados;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Estado ObterEstado(int codigo)
        {
            try
            {
                using (SqlConnection conn = DataDAO.Conection())
                {
                    string commandStr = "SELECT * FROM ESTADO WHERE CODIGO = @CODIGO";
                    SqlCommand command = new SqlCommand(commandStr, conn);
                    command.Parameters.AddWithValue("@CODIGO", codigo);
                    SqlDataReader dr = command.ExecuteReader();
                    Estado estado = null;
                    if (dr.Read())
                        estado = drEstado(dr);
                    
                    return estado;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void Atualizar(Estado estado)
        {
            try
            {
                using (SqlConnection conn = DataDAO.Conection())
                {
                    string commandStr = "UPDATE ESTADO SET PAIS = @PAIS, NOME=@NOME, SIGLA=@SIGLA, REGIAO=@REGIAO WHERE CODIGO = @CODIGO";
                    SqlCommand command = new SqlCommand(commandStr, conn);
                    command.Parameters.AddWithValue("@Pais", estado.Pais);
                    command.Parameters.AddWithValue("@Nome", estado.Nome);
                    command.Parameters.AddWithValue("@Sigla", estado.Sigla);
                    command.Parameters.AddWithValue("@Regiao", estado.Regiao);
                    command.Parameters.AddWithValue("@Codigo", estado.Codigo);
                    command.ExecuteNonQuery();                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Excluir(int codigo)
        {
            if (CidadeDAO.ObterCidade(codEstado: codigo) != null)
            {
                throw new Exception("CIDADE");
            }
            try
            {
                using (SqlConnection conn = DataDAO.Conection())
                {
                    string commandStr = "DELETE FROM ESTADO WHERE CODIGO = @CODIGO";
                    SqlCommand command = new SqlCommand(commandStr, conn);
                    command.Parameters.AddWithValue("@CODIGO", codigo);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
