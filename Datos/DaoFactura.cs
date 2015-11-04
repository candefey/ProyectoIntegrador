using System;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;

namespace Datos
{
    public class DaoFactura
    {
        private static string cadenaConex = "Data Source=GIU-PC\\SQLEXPRESS;Initial Catalog=Gimnasios;Integrated Security=True";

        public static int selectUltimoNumero()
        {
            int ultimoNumero = 0;
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                string consulta = "SELECT TOP 1 numero FROM Facturas ORDER BY numero DESC";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ultimoNumero = (int)dr["numero"];
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error SQL al obtener Numero de factura");
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return ultimoNumero;
        }

        public static String comprar(Factura F, List<DtoProductoVenta> lista)
        {
            SqlConnection cn = new SqlConnection();
            SqlTransaction tran = null;
            String resultado;
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                tran = cn.BeginTransaction();
                string consulta = "INSERT INTO Facturas(numero,tipo,fecha,idDeportista,montoTotal) VALUES(@numero,@tipo,@fecha,@idDeportista,@montoTotal)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.Parameters.AddWithValue("@numero", F.numero);
                cmd.Parameters.AddWithValue("@tipo", F.tipo);
                cmd.Parameters.AddWithValue("@fecha", F.fecha);
                cmd.Parameters.AddWithValue("@idDeportista", F.deportista.IdDeportista);
                cmd.Parameters.AddWithValue("@montoTotal", F.montoTotal);
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                string consulta4 ="SELECT TOP 1 idFactura FROM Facturas ORDER BY idFactura DESC";
                cmd.CommandText = consulta4;
                cmd.Connection = cn;
                int idFactura = (int)cmd.ExecuteScalar();

                foreach (DtoProductoVenta dto in lista)
                {
                    cmd.Parameters.Clear();
                    string consulta2 = "SELECT idProducto FROM Productos WHERE codigoBarra = @codigoBarra";
                    cmd.CommandText = consulta2;
                    cmd.Connection = cn;
                    cmd.Parameters.AddWithValue("@codigoBarra", dto.codigoBarra);
                    int idProducto = (int)cmd.ExecuteScalar();

                    cmd.Parameters.Clear();
                    string consulta3 = "INSERT INTO DetallesFactura(cantidad,precio,idFactura,idProducto) VALUES(@cantidad,@precio,@idFactura,@idProducto)";
                    cmd.CommandText = consulta3;
                    cmd.Connection = cn;
                    cmd.Transaction = tran;
                    cmd.Parameters.AddWithValue("@cantidad", dto.cantidad);
                    cmd.Parameters.AddWithValue("@precio", dto.precio);
                    cmd.Parameters.AddWithValue("@idFactura", idFactura );
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    string consulta5 = "UPDATE Productos SET stock= stock - @cantidad WHERE idProducto=@idProducto";
                    cmd.CommandText = consulta5;
                    cmd.Connection = cn;
                    cmd.Transaction = tran;
                    cmd.Parameters.AddWithValue("@cantidad", dto.cantidad);
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.ExecuteNonQuery();

                }
                tran.Commit();
                resultado = "Transaccion exitosa!";



            }
            catch (SqlException E)
            {
                throw new ApplicationException("Error sql al guardar la transaccion." + E.ToString());

                if (cn.State == ConnectionState.Open)
                    resultado = "Transaccion erronea!";
                    tran.Rollback();
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                
            }
            return resultado;
        }
    }
}
