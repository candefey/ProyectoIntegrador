using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gimnasios
{
    public partial class Venta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                //this.cargarCategorias();
                cargarGrilla();
            }

        }

        //protected void cargarGrilla(int idSelec)
        //{
        //    List<DtoProductoVenta> listaProductos = GestorProducto.obtenerProdVenta(idSelec);

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Nombre");
        //    dt.Columns.Add("Precio");
        //    dt.Columns.Add("Stock disponible");

        //    foreach (DtoProductoVenta p in listaProductos)
        //    {
        //        string[] fila = new string[3];
        //        fila[0] = p.nombre;
        //        fila[1] = p.precio.ToString();
        //        fila[2] = p.stock.ToString();
        //        dt.Rows.Add(fila);
        //    }
            
        //    grilla.DataSource = dt;
        //    grilla.DataBind();

        //}

        protected void cargarGrilla()
        {
            List<DtoProductoVenta> listaProductos = GestorProducto.obtenerProdVenta();

            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Stock disponible");
            dt.Columns.Add("Codigo de Barra");

            foreach (DtoProductoVenta p in listaProductos)
            {
                string[] fila = new string[4];
                fila[0] = p.nombre;
                fila[1] = p.precio.ToString();
                fila[2] = p.stock.ToString();
                fila[3] = p.codigoBarra.ToString();
                dt.Rows.Add(fila);
            }

            grilla.DataSource = dt;
            grilla.DataBind();

        }


        //private void cargarCategorias()
        //{
        //    DataSet ds = GestorCategorias.obtenerCategorias();
        //    cbo_categorias.DataSource = ds;
        //    cbo_categorias.DataTextField = "nombre";
        //    cbo_categorias.DataValueField = "idCategoriaProducto";
            
        //    cbo_categorias.DataBind();
        //    cbo_categorias.Items.Insert(0, "Todos los productos");
        //}

        //protected void cbo_categorias_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int idcat;
        //    if (int.TryParse(cbo_categorias.SelectedValue.ToString(), out idcat))
        //        cargarGrilla(idcat);
        //    else
        //        cargarGrilla();
        //}


        protected void grilla_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string x = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);
            if (x == "Select")
            {
                TextBox tb = grilla.Rows[index].FindControl("txt_cant") as TextBox;
                tb.ReadOnly = false;
                tb.Enabled = true;
                tb.CssClass = "active";
            }

        }

        protected void btn_confirmar_Click(object sender, EventArgs e)
        {
            

        }

        protected void txt_cant_TextChanged(object sender, EventArgs e)
        {
            if (Session["MiCarro"] == null) Session["MiCarro"] = new List<DtoProductoVenta>();
            Boolean insertar = true;
            List<DtoProductoVenta> miCarro = (List<DtoProductoVenta>)Session["MiCarro"];
            int index = grilla.SelectedRow.RowIndex;
            int codigoBarra = int.Parse(grilla.Rows[index].Cells[5].Text);
            TextBox tbo = grilla.Rows[index].FindControl("txt_cant") as TextBox;
            int A;
            if (int.TryParse((tbo.Text), out A))
            {
                if (int.Parse(grilla.Rows[index].Cells[4].Text) >= A)
                {
                    validadorServidor.Visible = false;
                    btn_confirmar.Visible = true;
                    foreach (DtoProductoVenta dto in miCarro)
                    {
                        if (dto.codigoBarra == codigoBarra)
                        {
                            tbo = grilla.Rows[index].FindControl("txt_cant") as TextBox;
                            dto.cantidad = int.Parse(tbo.Text);
                            insertar = false;
                        }
                    }
                    if (insertar == true)
                    {
                        DtoProductoVenta p = new DtoProductoVenta();
                        p.nombre = grilla.Rows[index].Cells[2].Text;
                        TextBox tb = grilla.Rows[index].FindControl("txt_cant") as TextBox;
                        p.cantidad = int.Parse(tb.Text);
                        p.codigoBarra = int.Parse(grilla.Rows[index].Cells[5].Text);
                        p.precio = int.Parse(grilla.Rows[index].Cells[3].Text);
                        miCarro.Add(p);

                    }
                }

                else
                {
                    validadorServidor.Visible = true;
                    btn_confirmar.Visible = false;
                }
            }
            else
            {
                validadorServidor.Visible = true;
                btn_confirmar.Visible = false;

            }
        }



        //protected void grilla_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (Session["MiCarro"] == null) Session["MiCarro"] = new List<DtoProductoVenta>();

        //    List<DtoProductoVenta> miCarro = (List<DtoProductoVenta>)Session["MiCarro"];

        //}
    }
}