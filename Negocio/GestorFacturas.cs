using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class GestorFacturas
    {
        public static int getUltimoNumero()
        {
            int ultimoNumero = DaoFactura.selectUltimoNumero();
            return ultimoNumero;

        }

        public static String comprar(Factura F, List<DtoProductoVenta> lista)
        {
            return DaoFactura.comprar(F,lista);

            
        }
    }
}
