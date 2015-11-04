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
    public partial class Venta2 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                this.cargarGrilla();
                this.cargarComboTipoDoc();
                int nroFactura = ((GestorFacturas.getUltimoNumero()) + 1);
                this.txt_nroFactura.Text = nroFactura.ToString();
                this.txt_fecha.Text = DateTime.Today.ToString("d");
                
            }
        }

        protected void cargarComboTipoDoc()
        {
            DataSet ds = GestorProducto.obtenerTipoDoc();
            cmb_tipoDoc.DataSource = ds;
            cmb_tipoDoc.DataTextField = "nombre";
            cmb_tipoDoc.DataValueField = "idTipoDocumento";
            cmb_tipoDoc.DataBind();
        }


        private void cargarGrilla()
        {
            float totalPagar=0;
            List<DtoProductoVenta> lista = (List<DtoProductoVenta>)Session["MiCarro"];

            //grillaDetalles.DataSource = lista;
            //grillaDetalles.DataBind();
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre del Producto");
            dt.Columns.Add("Precio Unitario");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Totales");
            
            foreach (DtoProductoVenta dto in lista)
            {
                string[] fila = new string[4];
                fila[0] = dto.nombre;
                float precio = dto.precio;
                int cantidad = dto.cantidad;
                float total = precio * cantidad;
                totalPagar += total;
                fila[1] = precio.ToString();
                fila[2] = cantidad.ToString();
                fila[3] = total.ToString();
                dt.Rows.Add(fila);
            }
            grillaDetalles.DataSource = dt;
            grillaDetalles.DataBind();
            txt_total.Text = totalPagar.ToString();

        }

        protected void txt_nroDoc_TextChanged(object sender, EventArgs e)
        {
            int numeroDoc = int.Parse(txt_nroDoc.Text);
            int idTipoDoc = int.Parse(cmb_tipoDoc.SelectedValue.ToString());
            Deportista d = GestorDeportista.buscarDeportistaPorDocumento(numeroDoc, idTipoDoc);
            txt_nombreDeportista.Text = d.Nombre;
            txt_apellidoDeportista.Text = d.Apellido;
        }

        protected void btn_confirmar_Click(object sender, EventArgs e)
        {
            Factura f = new Factura();
            f.deportista = GestorDeportista.getDeportistaBuscado();

            f.fecha = DateTime.Parse(txt_fecha.Text);

            f.montoTotal = int.Parse(txt_total.Text);
            f.numero = int.Parse(txt_nroFactura.Text);
            f.tipo = txt_tipoFactura.Text;
            List<DtoProductoVenta> lista = (List<DtoProductoVenta>)Session["MiCarro"];
            String resultado = GestorFacturas.comprar(f, lista);
            this.resultad.Visible = true;
            this.resultad.Text = resultado;

            txt_tipoFactura.Enabled = false;
            cmb_tipoDoc.Enabled = false;
            txt_nroDoc.Enabled = false;
            btn_confirmar.Enabled = false;

            Session["MiCarro"] = new List<DtoProductoVenta>();

        }
    }
}