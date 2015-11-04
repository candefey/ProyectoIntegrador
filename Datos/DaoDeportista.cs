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
    public class DaoDeportista
    {
        private static string cadenaConex = "Data Source=ASUS-FEY;Initial Catalog=Gimnasios;Integrated Security=True";

        /**
         Retorna una List con todos los productos existentes en la base de datos**/
        public static List<Deportista> select()
        {
            List<Deportista> lista = new List<Deportista>();

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                string consulta = "SELECT D.idDeportista, D.nombre, D.apellido, D.fechaNacimiento, D.nroDoc, D.cuit, D.fechaNacimiento, D.edad, T.idTipoDocumento, T.nombre as TipoDocum, P.nombre as nombrePatologia, P.idPatologia, P.descripcion as patoDescrip, G.idGimnasio, G.nombre as NomGim, G.cuil, G.direccion as direGim, S.nombre as NomSexo, S.idSexo, D.tieneMail, D.mail FROM Deportistas D JOIN Gimnasios G ON D.idGimnasio= G.idGimnasio INNER JOIN TiposDocumento T ON T.idTipoDocumento= D.idTipoDocumento INNER JOIN Patologias P ON P.idPatologia = D.idPatologia INNER JOIN Sexos S ON S.IdSexo = D.idSexo";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Deportista dep = new Deportista();
                    dep.IdDeportista = (int) dr["idDeportista"];
                    dep.Apellido = dr["apellido"].ToString();
                    dep.Nombre = dr["nombre"].ToString();
                    dep.Mail = dr["mail"].ToString();
                    dep.NroDoc = (int)dr["nroDoc"];
                    dep.FechaNacimiento = dr["fechaNacimiento"].ToString();
                    dep.Edad = (int)dr["edad"];
                    dep.Cuit = (int)dr["cuit"];

                    TipoDocumento td = new TipoDocumento();
                    td.IdTipoDoc = (int)dr["idTipoDocumento"];
                    td.Nombre = dr["TipoDocum"].ToString();

                    SexoDeportista sexo = new SexoDeportista();
                    sexo.Nombre = dr["nomSexo"].ToString();
                    sexo.IdSexo = (int)dr["idSexo"];

                    Patologia patologia = new Patologia();
                    patologia.IdPatologia =(int) dr["idPatologia"];
                    patologia.Nombre = dr["nombrePatologia"].ToString();
                    patologia.Descripcion =dr["patoDescrip"].ToString();

                    Gimnasio g = new Gimnasio();
                    g.Nombre = dr["nomGim"].ToString();
                    g.IdGimnasio = (int)dr["idGimnasio"];
                    g.Cuil = (int)dr["cuil"];
                    g.Direccion = dr["direGim"].ToString();

                    dep.Sexo = sexo;
                    dep.TipoDoc = td;
                    dep.Gim = g;
                    dep.Patologia = patologia;                  



                    // completar
                    lista.Add(dep);
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

        public static List<Deportista> filtrar(string filtro)
        {
            List<Deportista> lista = new List<Deportista>();

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                string consulta = "SELECT D.idDeportista, D.nombre, D.apellido, D.fechaNacimiento, D.nroDoc, D.cuit, D.fechaNacimiento, D.edad, T.idTipoDocumento, T.nombre as TipoDocum, P.nombre as nombrePatologia, P.idPatologia, P.descripcion as patoDescrip, G.idGimnasio, G.nombre as NomGim, G.cuil, G.direccion as direGim, S.nombre as NomSexo, S.idSexo, D.tieneMail, D.mail FROM Deportistas D JOIN Gimnasios G ON D.idGimnasio= G.idGimnasio INNER JOIN TiposDocumento T ON T.idTipoDocumento= D.idTipoDocumento INNER JOIN Patologias P ON P.idPatologia = D.idPatologia INNER JOIN Sexos S ON S.IdSexo = D.idSexo WHERE D.apellido LIKE '%" + filtro +"%'";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Deportista dep = new Deportista();
                    dep.IdDeportista = (int)dr["idDeportista"];
                    dep.Apellido = dr["apellido"].ToString();
                    dep.Nombre = dr["nombre"].ToString();
                    dep.Mail = dr["mail"].ToString();
                    dep.NroDoc = (int)dr["nroDoc"];
                    dep.FechaNacimiento = dr["fechaNacimiento"].ToString();
                    dep.Edad = (int)dr["edad"];
                    dep.Cuit = (int)dr["cuit"];

                    TipoDocumento td = new TipoDocumento();
                    td.IdTipoDoc = (int)dr["idTipoDocumento"];
                    td.Nombre = dr["TipoDocum"].ToString();

                    SexoDeportista sexo = new SexoDeportista();
                    sexo.Nombre = dr["nomSexo"].ToString();
                    sexo.IdSexo = (int)dr["idSexo"];

                    Patologia patologia = new Patologia();
                    patologia.IdPatologia = (int)dr["idPatologia"];
                    patologia.Nombre = dr["nombrePatologia"].ToString();
                    patologia.Descripcion = dr["patoDescrip"].ToString();

                    Gimnasio g = new Gimnasio();
                    g.Nombre = dr["nomGim"].ToString();
                    g.IdGimnasio = (int)dr["idGimnasio"];
                    g.Cuil = (int)dr["cuil"];
                    g.Direccion = dr["direGim"].ToString();

                    dep.Sexo = sexo;
                    dep.TipoDoc = td;
                    dep.Gim = g;
                    dep.Patologia = patologia;



                    // completar
                    lista.Add(dep);
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

        public static Deportista buscarPorDocumento(int nroDoc, int idTipoDoc)
        {
            Deportista d = new Deportista();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                string consulta = "SELECT idDeportista, nombre, apellido, cuit, idTipoDocumento, nroDoc FROM Deportistas WHERE idTipoDocumento = @idTipoDocumento AND nroDoc = @nroDoc";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@idTipoDocumento", idTipoDoc);
                cmd.Parameters.AddWithValue("@nroDoc", nroDoc);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    d.Apellido = dr["apellido"].ToString();
                    TipoDocumento td = new TipoDocumento();
                    td.IdTipoDoc = (int)dr["idTipoDocumento"];
                    d.TipoDoc = td;
                    d.NroDoc = (int)dr["nroDoc"];
                    d.Nombre = dr["nombre"].ToString();
                    d.IdDeportista = (int)dr["idDeportista"];
                    d.Cuit = (int)dr["cuit"];
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error SQL al obtener deportista a facturar");
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return d;

        }


        public static void insertarDeportista(Deportista d)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                String nombre = d.Nombre;
                String apellido = d.Apellido;
                int nroDoc = d.NroDoc;
                int cuit = d.Cuit;
                int idTipoDoc = d.TipoDoc.IdTipoDoc;
                int idSexo = d.Sexo.IdSexo;
                int idGim = d.Gim.IdGimnasio;
                int idPat = d.Patologia.IdPatologia;
                String fechaNac = d.FechaNacimiento;
                int edad = d.Edad;
                String mail = d.Mail;


                string consulta = "INSERT INTO Deportistas(tieneMail,nombre,apellido,cuit,idTipoDocumento,nroDoc,mail,fechaNacimiento,idPatologia, idGimnasio, edad, idSexo) VALUES (@tieneMail,@nombre,@apellido,@cuit,@idTipoDocumento,@nroDoc,@mail,@fechaNacimiento,@idPatologia,@idGimnasio,@edad,@idSexo)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@tieneMail", 1);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);               
                cmd.Parameters.AddWithValue("@cuit", cuit);
                cmd.Parameters.AddWithValue("@idTipoDocumento", idTipoDoc);
                cmd.Parameters.AddWithValue("@nroDoc", nroDoc);
                cmd.Parameters.AddWithValue("@fechaNacimiento", fechaNac);
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@idPatologia", idPat);
                cmd.Parameters.AddWithValue("@idGimnasio", idGim);
                cmd.Parameters.AddWithValue("@edad", edad);
                cmd.Parameters.AddWithValue("@idSexo", idSexo);
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error al insertar el deportista a la BD");
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }


        public static void delete(int cuit)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();
                string consulta = "DELETE FROM Deportistas WHERE cuit = ";
                consulta += "" + cuit + "";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();               
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error SQL al eliminar el deportista");
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }

        public static void update(Deportista d)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = cadenaConex;
                cn.Open();

                String nombre = d.Nombre;
                String apellido = d.Apellido;
                int nroDoc = d.NroDoc;
                int cuit = d.Cuit;
                int idTipoDoc = d.TipoDoc.IdTipoDoc;
                int idSexo = d.Sexo.IdSexo;
                int idGim = d.Gim.IdGimnasio;
                int idPat = d.Patologia.IdPatologia;
                String fechaNac = d.FechaNacimiento;
                int edad = d.Edad;
                String mail = d.Mail;

                string consulta = "UPDATE Deportistas SET tieneMail = @tieneMail, nombre=@nombre, apellido=@apellido, idTipoDocumento=@idTipoDoc, nroDoc=@nroDoc,mail=@mail,fechaNacimiento=@fechaNac, idPatologia=@idPat, idGimnasio=@idGim, edad=@edad, idSexo=@idSexo, cuit=@cuit WHERE cuit =" + d.Cuit;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@nombre", nombre);               
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@idTipoDoc", idTipoDoc);
                cmd.Parameters.AddWithValue("@nroDoc", nroDoc);
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@tieneMail", 1);
                cmd.Parameters.AddWithValue("@cuit", cuit);                
                cmd.Parameters.AddWithValue("@fechaNac", fechaNac);
                cmd.Parameters.AddWithValue("@idPat", idPat);
                cmd.Parameters.AddWithValue("@idGim", idGim);
                cmd.Parameters.AddWithValue("@edad", edad);
                cmd.Parameters.AddWithValue("@idSexo", idSexo);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error SQL al modificar el deportista");
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }


    }
    
}
