using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;

namespace Gimnasios
{
	public partial class ABMCDeportista : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                this.cargarGrilla();
                this.cargarComboSexo();
                this.cargarComboTipoDoc();
                this.cargarComboPatologias();
                this.cargarComboGimnasios();
                txt_mail_dep.Enabled = true;
                btn_actualizar.Visible = false;
            }
		}

        

        protected void cargarComboSexo()
        {
            List<SexoDeportista> listaSexos = GestorDeportista.obtenerSexos();
            foreach (SexoDeportista sexo in listaSexos)
            {
                cmb_sexo.Items.Add(sexo.Nombre);
            }
            
        }


        protected void cargarComboPatologias()
        {
            List<Patologia> listaPato = GestorDeportista.obtenerPatologias();
            foreach (Patologia item in listaPato)
            {
                cmb_patologia.Items.Add(item.Nombre);
            }
        }

        protected void cargarComboGimnasios()
        {
            List<Gimnasio> listaGim = GestorDeportista.obtenerGimnasios();

            foreach (Gimnasio item in listaGim)
            {
                cmb_gimnasio.Items.Add(item.Nombre);
            }
        }

        protected void cargarComboTipoDoc()
        {
            List<TipoDocumento> listaTDoc = GestorDeportista.obtenerTipoDocumentos();
            foreach (TipoDocumento item in listaTDoc)
            {
                cmb_tipo_doc.Items.Add(item.Nombre);
            }
        }


        protected void cargarGrilla()
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

        //protected void checkbox_mail_Click(object sender, EventArgs e)
        //{
        //     if (checkbox_mail.Checked)
        //        {
        //        txt_mail_dep.Enabled = true;
        //        }
        //        else
        //        {
        //        txt_mail_dep.Enabled = false;
        //        }
        //}

    protected void btn_guardar_Click(object sender, EventArgs e)
        {
        
            GestorDeportista.guardarDeportista(txt_nombre_dep.Text, txt_apelido_dep.Text, Int32.Parse(txt_cuit_dep.Text), checkbox_mail.Checked, txt_mail_dep.Text, txt_fechaNac_dep.Text, int.Parse(txt_documento_dep.Text), cmb_tipo_doc.SelectedValue, cmb_gimnasio.SelectedValue, cmb_patologia.SelectedValue, cmb_sexo.SelectedValue);
            cargarGrilla();
            limpiarForm();
            SetFocus(grillaDeportistas);
        }

        protected void btn_actualizar_Click(object sender, EventArgs e)
        {
            
            GestorDeportista.actualizarDeportista(txt_nombre_dep.Text, txt_apelido_dep.Text, Int32.Parse(txt_cuit_dep.Text), checkbox_mail.Checked, txt_mail_dep.Text, txt_fechaNac_dep.Text, int.Parse(txt_documento_dep.Text), cmb_tipo_doc.SelectedValue, cmb_gimnasio.SelectedValue, cmb_patologia.SelectedValue, cmb_sexo.SelectedValue);
            cargarGrilla();
            limpiarForm();
            SetFocus(grillaDeportistas);
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
           limpiarForm();
        }

        protected void grillaDeportistas_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
             string x = e.CommandName;
             int index = Convert.ToInt32(e.CommandArgument);
            if (x == "Delete")
            {

                int cuit = int.Parse(grillaDeportistas.Rows[index].Cells[8].Text);
                GestorDeportista.eliminarDeportista(cuit);
                cargarGrilla();
                SetFocus(grillaDeportistas);
            }
            if (x == "Select")
            {
                datosGrillaATextBoxes(index);
                btn_actualizar.Visible = true;
                btn_guardar.Visible = false;
                SetFocus(txt_nombre_dep);
                txt_cuit_dep.Enabled = false;
            }

        }

        public void grillaDeportistas_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {

        }

        private void datosGrillaATextBoxes(int index)
        {
            txt_nombre_dep.Text = grillaDeportistas.Rows[index].Cells[2].Text.ToString();
            txt_apelido_dep.Text = grillaDeportistas.Rows[index].Cells[3].Text.ToString();
            string sexo = grillaDeportistas.Rows[index].Cells[4].Text.ToString();
            string tipoDoc = grillaDeportistas.Rows[index].Cells[5].Text.ToString();
            txt_documento_dep.Text = grillaDeportistas.Rows[index].Cells[6].Text.ToString();
            txt_fechaNac_dep.Text = grillaDeportistas.Rows[index].Cells[7].Text.ToString();
            txt_cuit_dep.Text = grillaDeportistas.Rows[index].Cells[8].Text.ToString();
            string nomGim = grillaDeportistas.Rows[index].Cells[9].Text.ToString();
            string pato = grillaDeportistas.Rows[index].Cells[10].Text.ToString();
            txt_mail_dep.Text = grillaDeportistas.Rows[index].Cells[11].Text.ToString();

            cmb_gimnasio.SelectedValue = GestorDeportista.obtenerGim(nomGim).Nombre;
            cmb_sexo.SelectedValue = GestorDeportista.obtenerSexo(sexo).Nombre;
            cmb_patologia.SelectedValue = GestorDeportista.obtenerPatologia(pato).Nombre;
            cmb_tipo_doc.SelectedValue = GestorDeportista.obtenerTipoDoc(tipoDoc).Nombre;
            
        }


        private void limpiarForm()
        {

            txt_nombre_dep.Text = "";
            txt_apelido_dep.Text = "";
            txt_documento_dep.Text = "";
            txt_fechaNac_dep.Text = "";
            txt_cuit_dep.Text = "";
            txt_mail_dep.Text = "";
            cmb_gimnasio.SelectedIndex = 0;

            cmb_sexo.SelectedIndex= 1;
            cmb_patologia.SelectedIndex= 1;
            cmb_tipo_doc.SelectedIndex= 1;


        }

      

        protected void checkbox_mail_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_mail.Checked)
            {
                txt_mail_dep.Enabled = true;
            }
            else
            {
                txt_mail_dep.Enabled = false;
            }
        }
    }
}