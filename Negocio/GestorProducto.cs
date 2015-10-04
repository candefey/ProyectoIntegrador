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

        public static void insertarProducto(Producto P)
        {
            DaoProducto.insert(P);
        }

        public static void borrarProducto(int cod)
        {
            DaoProducto.borrarPorCodigoBarra(cod);
        }

        public static Boolean existeProducto(int cod)
        {
            return DaoProducto.existeProducto(cod);
        }

        public static void updatePorCodBarra(Producto P)
        {
            DaoProducto.updatePorCodBarra(P);
        }




    }
}
