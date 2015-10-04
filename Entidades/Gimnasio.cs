using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gimnasio
    {
        private int idGimnasio;
        private String nombre;
        private int cuil;
        private String direccion;

        public Gimnasio()
        {
            
        }

        public int IdGimnasio
        {
            get
            {
                return idGimnasio;
            }

            set
            {
                idGimnasio = value;
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

        public int Cuil
        {
            get
            {
                return cuil;
            }

            set
            {
                cuil = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public Gimnasio(int idGimnasio, string nombre, int cuil, string direccion)
        {
            this.idGimnasio = idGimnasio;
            this.nombre = nombre;
            this.cuil = cuil;
            this.direccion = direccion;
        }

    }
}
