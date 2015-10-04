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
    public class DaoPatologia
    {
        private static string cadenaConex = "Data Source=ASUS-FEY;Initial Catalog=Gimnasios;Integrated Security=True";

        /**
         Retorna una List con todos los productos existentes en la base de datos**/
        public static List<Patologia> select()
        {
            List<Patologia> lista = new List<Patologia>();

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                string consulta = "SELECT idPatologia, nombre, descripcion FROM Patologias ";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Patologia p = new Patologia();
                    p.IdPatologia = (int)dr["idPatologia"];
                    p.Nombre = dr["nombre"].ToString();
                    p.Descripcion = dr["descripcion"].ToString();
                    lista.Add(p);
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error SQL al obtener los gimnasios.");
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return lista;
        }

        public static Patologia obtenerPatologia(string nom)
        {
            SqlConnection cn = new SqlConnection();
            Patologia p = new Patologia();
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                string consulta = "SELECT idPatologia, nombre, descripcion FROM Patologias WHERE nombre=";
                consulta += "'" + nom + "'";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    p.IdPatologia = (int)dr["idPatologia"];
                    p.Nombre = dr["nombre"].ToString();
                    p.Descripcion = dr["descripcion"].ToString();
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error SQL al obtener los gimnasios.");
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return p;

        }
    }
}
