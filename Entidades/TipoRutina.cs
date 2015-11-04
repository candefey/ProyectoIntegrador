using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoRutina
    {
        private int idTipoRutina ;
        private string nombre;
        private string descripcion;

        public int IdTipoRutina { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
