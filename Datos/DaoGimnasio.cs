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
    public class DaoGimnasio
    {
        private static string cadenaConex = "Data Source=ASUS-FEY;Initial Catalog=Gimnasios;Integrated Security=True";

        /**
         Retorna una List con todos los productos existentes en la base de datos**/
        public static List<Gimnasio> select()
        {
            List<Gimnasio> lista = new List<Gimnasio>();

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                string consulta = "SELECT idGimnasio, nombre, cuil, direccion FROM Gimnasios";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Gimnasio g = new Gimnasio();
                    g.IdGimnasio = (int)dr["idGimnasio"];
                    g.Nombre = dr["nombre"].ToString();
                    g.Cuil = (int)dr["cuil"];
                    g.Direccion = dr["direccion"].ToString();
                    lista.Add(g);
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


        public static Gimnasio obtenerGim(string nom)
        {
            SqlConnection cn = new SqlConnection();
            Gimnasio g = new Gimnasio();
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                string consulta = "SELECT idGimnasio, nombre, cuil, direccion FROM Gimnasios WHERE nombre= ";
                consulta += "'" + nom + "'";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    g.IdGimnasio = (int)dr["idGimnasio"];
                    g.Nombre = dr["nombre"].ToString();
                    g.Cuil = (int)dr["cuil"];
                    g.Direccion = dr["direccion"].ToString();
                    
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
            return g;

        }
    }
}
