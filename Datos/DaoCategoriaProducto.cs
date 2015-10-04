using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoCategoriaProducto
    {
        static String cadenaConex = "Data Source=GIU-PC\\SQLEXPRESS;Initial Catalog=Gimnasios;Integrated Security=True";

        public static DataSet select()
        {
            //List<CategoriaProducto> lista = new List<CategoriaProducto>();
            DataSet ds;
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                string consulta = "SELECT idCategoriaProducto, nombre FROM CategoriasProducto";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds);

                //while (dr.Read())
                //{
                //    CategoriaProducto cp = new CategoriaProducto();
                //    cp.IdCategoriaProducto = (int)dr["idCategoriaProducto"];
                //    cp.Nombre = dr["nombre"].ToString();
                    
                //}

            }

            catch (SqlException ex)
            {
                throw new ApplicationException("Error al obtener las Categorias de Producto.");

            }
            finally
            {

                    cn.Close();
            }
            return ds;
        }

        public static CategoriaProducto selectPorNombre(String nombre)
        {
            CategoriaProducto cp = new CategoriaProducto();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                string consulta = "SELECT idCategoriaProducto FROM CategoriasProducto WHERE nombre LIKE '"+nombre+"'";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cp.IdCategoriaProducto = (int)dr["idCategoriaProducto"];
                    cp.Nombre = nombre;
                }
                
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error SQL al obtener idCategoria.");
            }
            finally
            {
                    cn.Close();
            }

            return cp;

        }
    }


  
}
