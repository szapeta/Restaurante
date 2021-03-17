using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteDATA
{
    public class Access
    {
        public string Query { get; set; }
        public string strError { get; set; }
        private string strConnection = "Server=localhost;Database=RestauranteAPP;Integrated Security=True;";
        private SqlConnection Connector = null;
        public DataSet Getds()
        {
            strError = string.Empty;
            DataSet d = new DataSet();
            try
            {
                Connector = new SqlConnection();
                Connector.ConnectionString = strConnection;
                Connector.Open();
                SqlCommand comando = new SqlCommand(Query);
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(d);
            }
            catch (Exception ex)
            {
                strError = ex.ToString(); 
                d = null;
            }
            finally
            {
                Connector.Close();
            }
            return d;
        }

        public bool Exec(SqlCommand cmd)
        {
            bool resp = false;
            try
            {
                Connector = new SqlConnection();
                Connector.ConnectionString = strConnection;
                Connector.Open();
                cmd.Connection = Connector;
                cmd.ExecuteNonQuery();
                resp = true;
            }
            catch (Exception ex)
            {
                resp = false;
            }
            finally
            {
                Connector.Close();
            }
            return resp;
        }

        public DataSet Getds(SqlCommand cmd)
        {
            strError = string.Empty;
            DataSet d = new DataSet();
            try
            {
                Connector = new SqlConnection();
                Connector.ConnectionString = strConnection;
                Connector.Open();
                cmd.Connection = Connector;
                using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                {
                    a.Fill(d);
                }
            }
            catch (Exception ex)
            {
                strError = ex.ToString();
                d = null;
            }
            finally
            {
                Connector.Close();
            }
            return d;
        }

    }
}
