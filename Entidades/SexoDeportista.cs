using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SexoDeportista
    {
        private int idSexo;
        private String nombre;

        public SexoDeportista()
        {

        }

        public SexoDeportista(int idSexo, string nombre)
        {
            this.idSexo = idSexo;
            this.nombre = nombre;
        }

        public int IdSexo
        {
            get
            {
                return idSexo;
            }

            set
            {
                idSexo = value;
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
    }
}
