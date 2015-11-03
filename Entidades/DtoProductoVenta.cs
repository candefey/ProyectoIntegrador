using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DtoProductoVenta
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public float precio { get; set; }
        public int stock { get; set; }
    }
}
