using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CategoriaProducto
    {
        private int idCategoriaProducto;
        private string nombre;
        private string descripcion;

        public CategoriaProducto()
        { }

        public CategoriaProducto(int idCategoriaProducto, string nombre, string descripcion)
        {
            this.idCategoriaProducto = idCategoriaProducto;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

        public int IdCategoriaProducto
        {
            get
            {
                return idCategoriaProducto;
            }

            set
            {
                idCategoriaProducto = value;
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
    }
}
