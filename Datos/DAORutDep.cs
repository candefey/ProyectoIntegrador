using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DAORutDep
    {
        private static string cadenaConex = "Data Source=GIU-PC\\SQLEXPRESS;Initial Catalog=Gimnasios;Integrated Security=True";

        public static List<DtoInformeRutina> selectInforme(int? idTipoRutina, double? tiempoTotal, string apellido)
        {
            List<DtoInformeRutina> lista = new List<DtoInformeRutina>();
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = cadenaConex;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                string select = "SELECT R.nombre, R.tiempoTotal, D.apellido, D.nombre, D.edad, TR.nombre FROM Rutinas R JOIN TiposRutina TR ON (R.idTipoRutina = TR.idTipoRutina) JOIN Deportistas D ON(R.idDeportista=D.idDeportista) ";
                string where = "";

                if (idTipoRutina != 0)
                {
                    where += "AND R.idTipoRutina = @idTipoRutina";
                    cmd.Parameters.AddWithValue("@idTipoRutina", idTipoRutina);
                }


            }
            catch
            { }







                return lista;

        }

    }
}
