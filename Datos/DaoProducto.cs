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

        /**
         Retorna una List con todos los productos existentes en la base de datos**/
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

                    CategoriaProducto cat = new CategoriaProducto();
                    cat.Nombre = (dr["NombreCat"].ToString());

                    p.Categoria = cat;
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

        /**Permite insertar un Producto p recibido por parametro a la bd**/
        public static Boolean insert(Producto p)
        {
            Boolean inserto = true;
            SqlConnection cn = new SqlConnection();
            SqlTransaction tran = null;
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                tran = cn.BeginTransaction();
                string sql = "INSERT INTO Productos(nombre,precio,stock,fechaRegistro,codigoBarra,idCategoriaProducto,aceptaDevolucion) VALUES(@nombre,@precio,@stock,@fechaRegistro,@codigoBarra,@idCategoriaProducto,@aceptaDevolucion)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = cn;
                cmd.Transaction = tran;

                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@precio", p.Precio);
                cmd.Parameters.AddWithValue("@stock", p.Stock);
                cmd.Parameters.AddWithValue("@fechaRegistro", p.FechaRegistro);
                cmd.Parameters.AddWithValue("@codigoBarra", p.CodigoBarra);
                //QUE HAGO CON ID CAT PROD
                cmd.Parameters.AddWithValue("@aceptaDevolucion", p.AceptaDevolucion);
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException E)
            {
                throw new ApplicationException("Error sql al guardar el producto.");
                inserto = false;
                if (cn.State == ConnectionState.Open)
                    tran.Rollback();
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return inserto;
        }
    }




}






