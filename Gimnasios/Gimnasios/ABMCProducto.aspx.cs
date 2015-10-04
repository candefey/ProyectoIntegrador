using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

public partial class ABMCProducto : System.Web.UI.Page
{
    private bool modificar = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.cargarGrilla();
        this.txt_fechaRegistro.Text = DateTime.Today.ToString("d");
        if (!IsPostBack)
        {
            this.cargarCategorias();
        }

    }

    private void cargarCategorias()
    {
        DataSet ds = GestorCategorias.obtenerCategorias();
        cbo_categorias.DataSource = ds;
        cbo_categorias.DataTextField = "nombre";
        cbo_categorias.DataValueField = "idCategoriaProducto";
        cbo_categorias.DataBind();
        
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
            String acepta = "SI";
            if (p.AceptaDevolucion == false)
                acepta = "NO";
            fila[6] = acepta;
            dt.Rows.Add(fila);
        }

        grillaProductos.DataSource = dt;
        grillaProductos.DataBind();
        
    }

    private Boolean validarDatos()
    {
        int a;
        DateTime b;
        Boolean datosValidos = false;
        if (txt_nombre.Text == "")
            return datosValidos;
        if (txt_precio.Text == "")
            return datosValidos;
        if (txt_stock.Text == "")
            return datosValidos;
        if (txt_codigoBarra.Text == "")
            return datosValidos;
        if (txt_fechaRegistro.Text == "")
            return datosValidos;
        if (!int.TryParse(txt_precio.Text, out a))
            return datosValidos;
        if (!int.TryParse(txt_stock.Text, out a))
            return datosValidos;
        if (!int.TryParse(txt_codigoBarra.Text, out a))
            return datosValidos;
        if (!DateTime.TryParse(txt_fechaRegistro.Text, out b))
            return datosValidos;
        else
            datosValidos = true;

        return datosValidos;
    }

    private Boolean existeProducto()
    {
      return GestorProducto.existeProducto(int.Parse(txt_codigoBarra.Text));
    }

    protected void btn_guardar_Click(object sender, EventArgs e)
    {
        if (this.validarDatos() == true && existeProducto() == false)
        {
            Label7.Visible = false;
            cbo_categorias.AutoPostBack = false;
            Producto p = new Producto();
            p.Nombre = txt_nombre.Text;
            p.Precio = float.Parse(txt_precio.Text);
            p.Stock = int.Parse(txt_stock.Text);
            p.CodigoBarra = int.Parse(txt_codigoBarra.Text);
            CategoriaProducto cat = new CategoriaProducto();
            cat.IdCategoriaProducto = int.Parse(cbo_categorias.SelectedValue.ToString());
            p.Categoria = cat;
            p.AceptaDevolucion = true;
            if (check_aceptaDevolucion.Checked == false)
                p.AceptaDevolucion = false;
            p.FechaRegistro = DateTime.Parse(txt_fechaRegistro.Text);
            GestorProducto.insertarProducto(p);
            this.cargarGrilla();
            this.limpiarTodo();
        }

        else
        {
            Label7.Visible = true;
        }

    }

    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        this.limpiarTodo();
        txt_codigoBarra.ReadOnly = false;
    }

    protected void btn_actualizar_Click(object sender, EventArgs e)
    {
        if (this.validarDatos() == true)
        {
            Label7.Visible = false;
            Producto p = new Producto();
            p.Nombre = txt_nombre.Text;
            p.Precio = float.Parse(txt_precio.Text);
            p.CodigoBarra = int.Parse(txt_codigoBarra.Text);
            p.Stock = int.Parse(txt_stock.Text);
            CategoriaProducto cat = new CategoriaProducto();
            cat.IdCategoriaProducto = int.Parse(cbo_categorias.SelectedValue.ToString());
            p.Categoria = cat;
            p.AceptaDevolucion = true;
            if (check_aceptaDevolucion.Checked == false)
                p.AceptaDevolucion = false;
            GestorProducto.updatePorCodBarra(p);
            this.cargarGrilla();
            this.limpiarTodo();
            btn_guardar.Visible = true;
            btn_actualizar.Visible = false;
        }
    }

    private void limpiarTodo()
    {
        this.txt_nombre.Text = "";
        this.txt_precio.Text = "";
        this.txt_stock.Text = "";
        this.txt_codigoBarra.Text = "";
        this.cargarCategorias();
        this.check_aceptaDevolucion.Checked = false;
    }


    protected void grillaProductos_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        string x = e.CommandName;
        int index = Convert.ToInt32(e.CommandArgument);
        if (x == "Delete")
        {
           int codigoBarraBorrar = int.Parse(grillaProductos.Rows[index].Cells[6].Text);
           GestorProducto.borrarProducto(codigoBarraBorrar);
        }
        if (x == "Select")
        {
            datosGrillaATextBoxes(index);
            txt_codigoBarra.ReadOnly = true;
            btn_guardar.Visible = false;
            btn_actualizar.Visible = true;
            
        }

}

    public void grillaProductos_RowDeleting(Object sender, GridViewDeleteEventArgs e)
    {
        this.cargarGrilla();
    }

    private void datosGrillaATextBoxes(int index)
    {
        txt_nombre.Text = grillaProductos.Rows[index].Cells[2].Text.ToString();
        txt_precio.Text = grillaProductos.Rows[index].Cells[3].Text.ToString();
        txt_stock.Text = grillaProductos.Rows[index].Cells[4].Text.ToString();
        txt_fechaRegistro.Text = grillaProductos.Rows[index].Cells[5].Text.ToString();
        txt_codigoBarra.Text = grillaProductos.Rows[index].Cells[6].Text.ToString();

        String nombreCat = grillaProductos.Rows[index].Cells[7].Text;
        CategoriaProducto cp = GestorCategorias.buscarCatPorNombre(nombreCat);

        cbo_categorias.SelectedValue = cp.IdCategoriaProducto.ToString();

        if (grillaProductos.Rows[index].Cells[8].Text == "SI")
            check_aceptaDevolucion.Checked = true;

    }
}