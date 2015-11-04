using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ejercicio
    {
        private int idEjercicio;
        private string nombre;
        private string descripcion;
        private double tiempo;

        public int IdEjercicio { get; set; }
        public string Nombre{ get; set; }
        public string Descripcion { get; set; }
        public double Tiempo { get; set; }
    }
}
