using System;
using Negocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;

namespace Gimnasios
{
    public partial class RegistrarRutina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.cargarComboTipoRutinas();
            }
            grillaDeportistas.Visible = false;

        }
        private void cargarComboTipoRutinas()
        {
            System.Data.DataSet ds = GestorRutina.obtenerTipoRutinas();
            cmb_tipo_rutina.DataSource = ds;
            cmb_tipo_rutina.DataTextField = "nombre";
            cmb_tipo_rutina.DataValueField = "idTipoRutina";
            cmb_tipo_rutina.DataBind();
            
        }
        protected void cargarGrillaDeportistas()
        {

            List<Deportista> listaDeportistas = GestorDeportista.obtenerTodos();
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellido");
            dt.Columns.Add("Sexo");
            dt.Columns.Add("Tipo Doc");
            dt.Columns.Add("Nro Documento");
            dt.Columns.Add("Fecha Nacimiento");
            dt.Columns.Add("Cuit");
            dt.Columns.Add("Gimnasio");
            dt.Columns.Add("Patologia");
            dt.Columns.Add("Mail");

            foreach (Deportista d in listaDeportistas)
            {
                string[] fila = new string[10];
                fila[0] = d.Nombre;
                fila[1] = d.Apellido;
                fila[2] = d.Sexo.Nombre;
                fila[3] = d.TipoDoc.Nombre;
                fila[4] = d.NroDoc.ToString();
                fila[5] = d.FechaNacimiento.ToString().Remove(10, 8);
                fila[6] = d.Cuit.ToString();
                fila[7] = d.Gim.Nombre;
                fila[8] = d.Patologia.Nombre;
                fila[9] = d.Mail.ToString();
                dt.Rows.Add(fila);
            }

            grillaDeportistas.DataSource = dt;
            grillaDeportistas.DataBind();


        }

        protected void ListarDeportistas(object sender, EventArgs e)
        {
            cargarGrillaDeportistas();
            grillaDeportistas.Visible = true;
           
        }
    }   
}



