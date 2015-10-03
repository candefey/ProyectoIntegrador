using Negocio;
using System;
using System.Collections.Generic;
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

        grillaProductos.DataSource = GestorProducto.obtenerTodos();

        grillaProductos.DataBind();

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}