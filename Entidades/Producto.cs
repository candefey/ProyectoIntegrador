using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        private int idProducto;
        private string nombre;
        private float precio;
        private int stock;
        private DateTime fechaRegistro;
        private int codigoBarra;
        private string categoria;
        private Boolean aceptaDevolucion;

        public Producto()
            {}

        public Producto(int idProducto, string nombre, float precio, int stock, DateTime fechaRegistro, int codigoBarra, string categoria, bool aceptaDevolucion)
        {
            this.idProducto = idProducto;
            this.nombre = nombre;
            this.precio = precio;
            this.stock = stock;
            this.fechaRegistro = fechaRegistro;
            this.codigoBarra = codigoBarra;
            this.categoria = categoria;
            this.AceptaDevolucion = aceptaDevolucion;
        }

        public int IdProducto
        {
            get
            {
                return idProducto;
            }

            set
            {
                idProducto = value;
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

        public float Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }

        public int Stock
        {
            get
            {
                return stock;
            }

            set
            {
                stock = value;
            }
        }

        public DateTime FechaRegistro
        {
            get
            {
                return fechaRegistro;
            }

            set
            {
                fechaRegistro = value;
            }
        }

        public int CodigoBarra
        {
            get
            {
                return codigoBarra;
            }

            set
            {
                codigoBarra = value;
            }
        }

        

     

        public string Categoria
        {
            get
            {
                return categoria;
            }

            set
            {
                categoria = value;
            }
        }

        public bool AceptaDevolucion
        {
            get
            {
                return aceptaDevolucion;
            }

            set
            {
                aceptaDevolucion = value;
            }
        }
    }
}
