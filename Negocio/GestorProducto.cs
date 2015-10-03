using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class GestorProducto
    {

        public static List<Producto> obtenerTodos()
        {
            List<Producto> lista = new List<Producto>();
            lista = DaoProducto.select();
            return lista;
        }
        



    }
}
