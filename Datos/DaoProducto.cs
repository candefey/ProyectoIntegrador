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
    public class DaoProducto
    {
        private static string cadenaConex = "Data Source=ASUS-FEY;Initial Catalog=Gimnasios;Integrated Security=True";

        public static List<Producto> select()
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                string consulta = "SELECT P.nombre as NombreProd, P.precio, P.stock, P.fechaRegistro, P.codigoBarra, CP.nombre as NombreCat, P.aceptaDevolucion FROM Productos P INNER JOIN CategoriasProducto CP ON (P.idCategoriaProducto = CP.idCategoriaProducto)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto p = new Producto();
                    p.Nombre = dr["NombreProd"].ToString();
                    p.Categoria = dr["NombreCat"].ToString();
                    int aceptaDev = (int)dr["aceptaDevolucion"];
                    Boolean acepta = false;
                    if (aceptaDev == 1)
                    {
                        acepta = true;
                    }
                    p.AceptaDevolucion = acepta;
                    p.CodigoBarra = (int)dr["codigoBarra"];
                    p.FechaRegistro = (DateTime)dr["fechaRegistro"];
                    p.Precio = float.Parse(dr["precio"].ToString());
                    p.Stock = (int)dr["stock"];
                    lista.Add(p);

                }

            }

            catch (SqlException ex)
            {
                throw new ApplicationException("Error SQL al obtener los Productos.");

            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return lista;
        }

        public static Boolean insert(Producto p)
        {
            //SqlConnection cn= new SqlConnection();
            //SqlTransaction tran = null;
            //try
            //{
            //    cn.ConnectionString = cadenaConex;
            //    cn.Open();
            //    tran = cn.BeginTransaction();
            //    string sql = "";
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.CommandText = sql;
            //    cmd.Connection = cn;
            //}
            


                return true;
        }



    }




}

