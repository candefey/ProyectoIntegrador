using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Rutina
    {
        public int idRutina { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double tiempoTotal { get; set; }
        public Deportista deportista { get; set; }
        public TipoRutina tipoRutina { get; set; }
    }
}
