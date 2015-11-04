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
    public partial class InformeRutinas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.cargarCombo();

            }

        }

        private void cargarCombo()
        {
            DataSet ds = GestorRutina.obtenerTipoRutinas();
            cmb_tipo.DataSource = ds;
            cmb_tipo.DataTextField = "nombre";
            cmb_tipo.DataValueField = "idTipoRutina";
            cmb_tipo.DataBind();
            cmb_tipo.Items.Insert(0, "Seleccione un tipo de rutina");
        }

        protected void btn_busqueda_Click(object sender, EventArgs e)
        {
            int? idTipoRutina;
            string apellido;
            double? tiempoTotal;

            if (cmb_tipo.SelectedValue != "Seleccione un tipo de rutina")
            {
                if (int.Parse(cmb_tipo.SelectedValue) != 0)
                {
                    idTipoRutina = int.Parse(cmb_tipo.SelectedValue);
                }
                else
                {
                    idTipoRutina = null;
                }
            }
            else
            {
                idTipoRutina = null;
            }

            if (txt_apellido.Text == "")
            {
                apellido = null;
            }
            else
            {
                apellido = txt_apellido.Text;
            }

            if (txt_tiempo.Text == "")
            {
                tiempoTotal = null;
            }
            else
            {
                tiempoTotal = Double.Parse(txt_tiempo.Text);
            }

            List<DtoInformeRutina> lista = GestorInRutina.generarInforme(idTipoRutina, apellido, tiempoTotal);
            if (lista.Count >= 1)
            {
                this.LLenarDatos(lista);
            }
            else
            {
                mensaje.Visible = true;
            }

            
        }

        private void LLenarDatos(List<DtoInformeRutina> list)
        {
            grillaRutinas.DataSource = list;
            grillaRutinas.DataBind();
            ViewState["view"] = list;
        }

        protected void grillaRutinas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grillaRutinas.PageIndex = e.NewPageIndex;
            grillaRutinas.DataSource = ViewState["view"];
            grillaRutinas.DataBind();

        }
    }
}