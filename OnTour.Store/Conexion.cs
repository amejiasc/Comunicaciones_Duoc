using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicaciones.Store
{
    public class Conexion
    {
        SqlConnection cnx;
        SqlCommand cmd = new SqlCommand();
        bool vexito;                
        public Conexion() {
            cnx = new SqlConnection(GetConex());
        }
        private string GetConex()
        {
            string strConex = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;
            if (object.ReferenceEquals(strConex, string.Empty))
            {
                return string.Empty;
            }
            else
            {
                return strConex;
            }
        }

        public bool Ejecutar(string vSql) {

            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = vSql;
            try
            {
                cnx.Open();
                cmd.ExecuteNonQuery();
                vexito = true;
            }
            catch (SqlException)
            {
                vexito = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return vexito;

        }
        public DataTable EjecutarDT(string vSql)
        {
            DataSet dts = new DataSet();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = vSql;
            try
            {
                SqlDataAdapter miada;
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "datos");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
            }
            return (dts.Tables[0]);

        }



    }
}
