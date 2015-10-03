using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABMCProducto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.cargarGrilla();
            }

    protected void cargarGrilla()
    {

        List<Producto> listaProductos = GestorProducto.obtenerTodos();
        DataTable dt = new DataTable();
        dt.Columns.Add("Nombre");
        dt.Columns.Add("Precio");
        dt.Columns.Add("Stock disponible");
        dt.Columns.Add("Fecha de registro");
        dt.Columns.Add("Número de Código de Barra");
        dt.Columns.Add("Categoría de Producto");
        dt.Columns.Add("Acepta devolución");

        foreach (Producto p in listaProductos)
        {
            string[] fila = new string[7];
            fila[0] = p.Nombre;
            fila[1] = p.Precio.ToString();
            fila[2] = p.Stock.ToString();
            fila[3] = p.FechaRegistro.ToShortDateString();
            fila[4] = p.CodigoBarra.ToString();
            fila[5] = p.Categoria.Nombre;
            fila[6] = p.AceptaDevolucion.ToString();
            dt.Rows.Add(fila);
        }

        grillaProductos.DataSource = dt;
        grillaProductos.DataBind();


    }

  
}