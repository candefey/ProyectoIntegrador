using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoDocumento
    {
        private int idTipoDoc;
        private String nombre;

        public TipoDocumento()
        {
        }

        public TipoDocumento(int idTipoDoc, string nombre)
        {
            this.idTipoDoc = idTipoDoc;
            this.nombre = nombre;
        }

        public int IdTipoDoc
        {
            get
            {
                return idTipoDoc;
            }

            set
            {
                idTipoDoc = value;
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
