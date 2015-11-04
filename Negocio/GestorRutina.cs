using System;
using System.Collections.Generic;
using System.Data;
using Datos;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestorRutina
    {

        public static DataSet obtenerTipoRutinas()
        {
            DataSet ds = new DataSet();
            ds = DaoTipoRutina.select();
            return ds;

        }
    }
}
