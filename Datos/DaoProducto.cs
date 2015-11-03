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
        private static string cadenaConex = "Data Source=GIU-PC\\SQLEXPRESS;Initial Catalog=Gimnasios;Integrated Security=True";

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
                cmd.Parameters.AddWithValue("@idCategoriaProducto", p.Categoria.IdCategoriaProducto);
                cmd.Parameters.AddWithValue("@aceptaDevolucion", p.AceptaDevolucion);
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException E)
            {
                throw new ApplicationException("Error sql al guardar el producto."+E.ToString());
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

        public static void borrarPorCodigoBarra(int cod)
        {

            SqlConnection cn = new SqlConnection();
            SqlTransaction tran = null;
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                tran = cn.BeginTransaction();
                string sql = "DELETE FROM Productos WHERE codigoBarra="+cod;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException E)
            {
                throw new ApplicationException("Error sql al borrar el producto." + E.ToString());
                tran.Rollback();
            }
            finally
            {

                    cn.Close();
            }



        }

        public static Boolean existeProducto(int codigo)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();

                string sql = "SELECT nombre FROM Productos WHERE codigoBarra="+codigo;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    return true;
                }
            catch (SqlException E)
            {
                throw new ApplicationException("Error sql" + E.ToString());
                cn.Close();
            }
            finally
            {

                cn.Close();
            }

            return false;
        }

        public static void updatePorCodBarra(Producto P)
        {

            SqlConnection cn = new SqlConnection();
            SqlTransaction tran = null;
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                tran = cn.BeginTransaction();
                string sql = "UPDATE Productos SET nombre= @nombre, precio=@precio, stock=@stock, idCategoriaProducto=@idCategoriaProducto, aceptaDevolucion=@aceptaDevolucion WHERE codigoBarra="+P.CodigoBarra;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = cn;
                cmd.Transaction = tran;

                cmd.Parameters.AddWithValue("@nombre", P.Nombre);
                cmd.Parameters.AddWithValue("@precio", P.Precio);
                cmd.Parameters.AddWithValue("@stock", P.Stock);
                cmd.Parameters.AddWithValue("@idCategoriaProducto", P.Categoria.IdCategoriaProducto);
                if (P.AceptaDevolucion == true)
                    cmd.Parameters.AddWithValue("@aceptaDevolucion", 1);
                else
                    cmd.Parameters.AddWithValue("@aceptaDevolucion", 0);


                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException E)
            {
                throw new ApplicationException("Error sql al modificar el producto." + E.ToString());
                tran.Rollback();
            }
            finally
            {
                cn.Close();
            }

        }

        public static List<DtoProductoVenta> selectoDtoProd()
        {
            List<DtoProductoVenta> lista = new List<DtoProductoVenta>();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                string consulta = "SELECT P.nombre as NombreProd, P.precio, P.stock FROM Productos P";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DtoProductoVenta p = new DtoProductoVenta();
                    p.nombre = dr["NombreProd"].ToString();                  
                    p.precio = float.Parse(dr["precio"].ToString());
                    p.stock = (int)dr["stock"];
                    lista.Add(p);
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error SQL al obtener los Productos Simplificados.");
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






