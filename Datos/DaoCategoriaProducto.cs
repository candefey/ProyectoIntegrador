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
        public static List<CategoriaProducto> select()
        {
            List<CategoriaProducto> lista = new List<CategoriaProducto>();
            string cadenaConex = "Data Source=GIU-PC\\SQLEXPRESS;Initial Catalog=Gimnasios;Integrated Security=True";
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                string consulta = "SELECT idCategoriaProducto, nombre FROM CategoriasProducto";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CategoriaProducto cp = new CategoriaProducto();
                    cp.IdCategoriaProducto = (int)dr["idCategoriaProducto"];
                    cp.Nombre = dr["nombre"].ToString();
                    
                }

            }

            catch (SqlException ex)
            {
                throw new ApplicationException("Error al obtener las Categorias de Producto.");

            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return lista;
        }
    }
}
