using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class DetalleFactura
    {
        public int idDetalleFactura { get; set; }
        public int cantidad { get; set; }
        public float precio { get; set; }
        public Factura factura { get; set; }
        public Producto producto { get; set; }
    }
}
