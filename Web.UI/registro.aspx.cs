using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Controlador;

namespace Web.UI
{
    public partial class registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RangeValidator3.MaximumValue = DateTime.Today.ToString("yyyy");
                cargarCombos();
            }
        }
        protected void btn_Enviar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string username = txt_Username.Text;
                int t = cmb_TipoDoc.SelectedIndex;
                Negocio.TipoDNI tipoDni = Controlador.TipoDNIManager.obtenerTipoDNI(t + 1);
                int nrodoc = Convert.ToInt32(txt_Documento.Text);
                string contraseña = txt_Password.Text;
                string confirmacion = txt_Pass_Confirm.Text;
                if (contraseña != confirmacion)
                {
                    lbl_ErrorContraseñas.Text = "Las contraseñas no coinciden";
                    txt_Pass_Confirm.Text = "";
                    txt_Password.Text = "";
                    txt_Password.Focus();
                    return;
                }
                string apellido = txt_Apellido.Text;
                string nombre = txt_Nombre.Text;
                DateTime fechaNac = new DateTime(Convert.ToInt32(txt_año.Text), Convert.ToInt32(txt_mes.Text), Convert.ToInt32(txt_dia.Text));
                int pais = cmb_Pais.SelectedIndex;
                Negocio.Pais pai = Controlador.PaisManager.obtenerPais(pais);
                int provincia = cmb_Provincia.SelectedIndex;
                Negocio.Provincia prov = Controlador.ProvinciaManager.obtenerProvincia(provincia + 1);
                int localidad = cmb_Localidad.SelectedIndex;
                Negocio.Localidad loc = Controlador.LocalidadManager.obtenerLocalidad(localidad + 1);
                int barrio = cmb_Barrio.SelectedIndex;
                Negocio.Barrio barr = Controlador.BarrioManager.obtenerBarrio(barrio + 1);
                string domicilio = txt_Domicilio.Text;
                int sexo = cmb_Sexo.SelectedIndex;
                Negocio.Sexo sex = Controlador.SexoManager.obtenerSexo(sexo + 1);
                string email = txt_Email.Text;
                string telefono = txt_Telefono.Text;
                string celular = txt_Celular.Text;

                Negocio.Cliente cliente = new Cliente(username, contraseña, tipoDni, nrodoc, apellido, nombre, fechaNac, domicilio, barr, sex, email, telefono, celular);
                if (!Controlador.ClienteManager.guardarCliente(cliente))
                {
                    lbl_ErrorContraseñas.Text = "El nombre de usuario seleccionado ya existe, por favor seleccione otro";
                    txt_Username.Text = "";
                    txt_Username.Focus();
                }
                else
                {
                    Controlador.ClienteManager.agregarRol(cliente);
                }
            }
        }

        protected void cargarCombos()
        {
            DataTable dt = new DataTable();

            dt = Controlador.TipoDNIManager.obtenerTodos();
            cmb_TipoDoc.DataSource = dt;
            cmb_TipoDoc.DataTextField = "descripcion";
            cmb_TipoDoc.DataValueField = "cod_TipoDNI";
            cmb_TipoDoc.DataBind();
            cmb_TipoDoc.Items.Add("Seleccione");
            cmb_TipoDoc.SelectedIndex = cmb_TipoDoc.Items.Count - 1;
            
            dt = Controlador.PaisManager.obtenerTodos();
            cmb_Pais.DataSource = dt;
            cmb_Pais.DataTextField = "descripcion";
            cmb_Pais.DataValueField = "cod_Pais";
            cmb_Pais.DataBind();
            cmb_Pais.Items.Add("Seleccione");
            cmb_Pais.SelectedIndex = cmb_Pais.Items.Count - 1;

            dt = Controlador.SexoManager.obtenerTodos();
            cmb_Sexo.DataSource = dt;
            cmb_Sexo.DataTextField = "descripcion";
            cmb_Sexo.DataValueField = "cod_Sexo";
            cmb_Sexo.DataBind();
            cmb_Sexo.Items.Add("Seleccione");
            cmb_Sexo.SelectedIndex = cmb_Sexo.Items.Count - 1;

        }
        protected void required_TipoDoc_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cmb_TipoDoc.SelectedValue == "Seleccione" || cmb_TipoDoc.Items.Count == 0) args.IsValid = false;
            else { args.IsValid = true; }
        }
        protected void required_Pais_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cmb_Pais.SelectedValue == "Seleccione") args.IsValid = false;
            else { args.IsValid = true; }
        }
        protected void required_Provincia_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cmb_Provincia.SelectedValue == "Seleccione" || cmb_Provincia.Items.Count == 0) args.IsValid = false;
            else { args.IsValid = true; }
        }
        protected void required_Localidad_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cmb_Localidad.SelectedValue == "Seleccione" || cmb_Localidad.Items.Count == 0) args.IsValid = false;
            else { args.IsValid = true; }
        }
        protected void required_Barrio_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cmb_Barrio.SelectedValue == "Seleccione" || cmb_Barrio.Items.Count == 0) args.IsValid = false;
            else { args.IsValid = true; }
        }
        protected void required_Sexo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cmb_Sexo.SelectedValue == "Seleccione") args.IsValid = false;
            else { args.IsValid = true; }
        }
        protected void cmb_Pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Controlador.ProvinciaManager.obtenerTodos(cmb_Pais.SelectedIndex + 1);
            cmb_Provincia.DataSource = dt;
            cmb_Provincia.DataTextField = "nombre";
            cmb_Provincia.DataValueField = "cod_Provincia";
            cmb_Provincia.DataBind();
            cmb_Provincia.Items.Add("Seleccione");
            cmb_Provincia.SelectedIndex = cmb_Provincia.Items.Count - 1;

        }

        protected void cmb_Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Controlador.LocalidadManager.obtenerTodos(cmb_Provincia.SelectedIndex + 1);
            cmb_Localidad.DataSource = dt;
            cmb_Localidad.DataTextField = "nombre";
            cmb_Localidad.DataValueField = "cod_Localidad";
            cmb_Localidad.DataBind();
            cmb_Localidad.Items.Add("Seleccione");
            cmb_Localidad.SelectedIndex = cmb_Localidad.Items.Count - 1;

        }

        protected void cmb_Localidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Controlador.BarrioManager.obtenerTodos(cmb_Localidad.SelectedIndex + 1);
            cmb_Barrio.DataSource = dt;
            cmb_Barrio.DataTextField = "nombre";
            cmb_Barrio.DataValueField = "cod_Barrio";
            cmb_Barrio.DataBind();
            cmb_Barrio.Items.Add("Seleccione");
            cmb_Barrio.SelectedIndex = cmb_Barrio.Items.Count - 1;


        }
    }
}