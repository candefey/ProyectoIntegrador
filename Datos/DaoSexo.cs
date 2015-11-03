using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class DaoSexo
    {
        private static string cadenaConex = "Data Source=GIU-PC\\SQLEXPRESS;Initial Catalog=Gimnasios;Integrated Security=True";

        /**
         Retorna una List con todos los productos existentes en la base de datos**/
        public static List<SexoDeportista> select()
        {
            List<SexoDeportista> lista = new List<SexoDeportista>();

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                string consulta = "SELECT idSexo, nombre FROM Sexos";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SexoDeportista sexo = new SexoDeportista();
                    sexo.IdSexo = (int)dr["idSexo"];
                    sexo.Nombre = dr["nombre"].ToString();
                    lista.Add(sexo);
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error SQL al obtener los sexos de los deportistas.");
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return lista;
        }

        public static SexoDeportista obtenerSexo(string nomSexo)
        {

            SqlConnection cn = new SqlConnection();

            SexoDeportista sexo = new SexoDeportista();
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                string consulta = "SELECT idSexo, nombre FROM Sexos WHERE nombre=";
                consulta += "'" + nomSexo + "'";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sexo.IdSexo = (int)dr["idSexo"];
                    sexo.Nombre = dr["nombre"].ToString();
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error SQL al obtener los sexos de los deportistas.");
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }

            return sexo;
        }
    }


   
}
