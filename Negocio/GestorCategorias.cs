using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestorCategorias
    {
        public static DataSet obtenerCategorias()
        {
            DataSet ds = new DataSet();
            ds = DaoCategoriaProducto.select();
            return ds;

        }
        public static CategoriaProducto buscarCatPorNombre(String nombre)
        {
            CategoriaProducto cp = DaoCategoriaProducto.selectPorNombre(nombre);
            return cp;
        }


    }
}
