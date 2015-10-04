using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class DaoTipoDocumento
    {
        private static string cadenaConex = "Data Source=ASUS-FEY;Initial Catalog=Gimnasios;Integrated Security=True";

        /**
         Retorna una List con todos los productos existentes en la base de datos**/
        public static List<TipoDocumento> select()
        {
            List<TipoDocumento> lista = new List<TipoDocumento>();

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                string consulta = "SELECT idTipoDocumento, nombre FROM TiposDocumento";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoDocumento tp = new TipoDocumento();
                    tp.IdTipoDoc = (int)dr["idTipoDocumento"];
                    tp.Nombre = dr["nombre"].ToString();
                    lista.Add(tp);
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error SQL al obtener los tipo de documentos.");
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return lista;
        }

        public static TipoDocumento obtenerTipoDoc(string nom)
        {
            SqlConnection cn = new SqlConnection();

            TipoDocumento tp = new TipoDocumento();

            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                string consulta = "SELECT idTipoDocumento, nombre FROM TiposDocumento WHERE nombre =";
                consulta += "'" + nom + "'";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tp.IdTipoDoc = (int)dr["idTipoDocumento"];
                    tp.Nombre = dr["nombre"].ToString();
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error SQL al obtener los tipo de documentos.");
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return tp;
        }
    }


}
