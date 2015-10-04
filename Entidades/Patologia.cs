using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Patologia
    {
        private int idPatologia;
        private String nombre;
        private String descripcion;

        public Patologia()
        {
        }

        public int IdPatologia
        {
            get
            {
                return idPatologia;
            }

            set
            {
                idPatologia = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public Patologia(int idPatologia, string nombre, string descripcion)
        {
            this.idPatologia = idPatologia;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
    }
}
