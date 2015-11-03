using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Factura
    {
        public int idFactura { get; set; }
        public int numero { get; set; }
        public string tipo { get; set; }
        public DateTime fecha { get; set; }
        public Deportista deportista { get; set; }
        public float  montoTotal { get; set; }
    }
}
