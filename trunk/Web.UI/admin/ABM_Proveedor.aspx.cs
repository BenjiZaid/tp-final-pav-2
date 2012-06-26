using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controlador;
using Negocio;
using System.Data;
using System.Drawing;

namespace Web.UI.admin
{
    public partial class ABM_Proveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string accion = "";

                pnl_BuscarProveedor.Visible = false;
                pnl_Informacion.Visible = false;
                pnl_registroProveedor.Visible = false;

                if (Request.QueryString["accion"] != null)
                {
                    accion = Request.QueryString["accion"].ToString();

                    if (accion.Equals("agregar"))
                    {
                        pnl_registroProveedor.Visible = true;
                        btn_ModificarSubmit.Visible = false;
                        btn_Agregar.Visible = true;
                        lbl_codigoProveedor.Text = Convert.ToString(ProveedorManager.obtenerUltimo() + 1);

                    }
                    else if (accion.Equals("modificar"))
                    {
                            lbl_Info.Text = "Modificar Proveedor";
                            pnl_BuscarProveedor.Visible = true;
                            cargarCombo();    
                    }
                     if (accion.Equals("informar"))
                       {
                            if (Request.QueryString["mensaje"] != null)
                            {
                                if (Request.QueryString["mensaje"].ToString().Equals("exito"))
                                {
                                    lbl_Mensaje.Text = "Operacion exitosa";
                                    pnl_Informacion.Visible = true;
                                }
                                if (Request.QueryString["mensaje"].ToString().Equals("fracaso"))
                                {
                                    lbl_Mensaje.Text = "Error en la opracion";
                                    lbl_Mensaje.ForeColor = System.Drawing.Color.Red;
                                    pnl_Informacion.Visible = true;
                                }
                            }
                        }
                    
                }
            }
        }


        protected void btn_Modificar_Click1(object sender, EventArgs e)
        {

            if (ddl_Proveedor.SelectedValue != "0")
            {
                Proveedor p = ProveedorManager.obtenerProveedor(ddl_Proveedor.SelectedIndex + 1);
                txt_Proveedor.Text = p.Nombre;
                txt_Domicilio.Text = p.Domicilio;
                txt_Telefono.Text = Convert.ToString(p.Telefono);
                txt_Email.Text = p.Mail;
                txt_contactoNombre.Text = p.NombreContacto;
                txt_contactoTelefono.Text = Convert.ToString(p.TelefonoContacto);
                pnl_BuscarProveedor.Visible = false;
                pnl_registroProveedor.Visible = true;
                lbl_Info.Text = "Modificar Proveedor";
                btn_Agregar.Visible = false;
                lbl_codigoProveedor.Text = Convert.ToString(ddl_Proveedor.SelectedIndex + 1);
                if (ProveedorManager.esHabilitado(ddl_Proveedor.SelectedIndex + 1))
                {
                    lbl_esHabilitado.Text = "Habilitado";
                    lbl_esHabilitado.ForeColor = Color.Green;
                }
                else
                {
                    lbl_esHabilitado.Text = "Deshabilitado";
                    lbl_esHabilitado.ForeColor = Color.Red;
                }
            }

            else lbl_opcion.Text = "Seleccione una opcion";
           
        }

        protected void cargarCombo() 
        {
            DataTable dt = ProveedorManager.obtenerTodos();
            ddl_Proveedor.DataSource = dt;
            ddl_Proveedor.DataTextField = "nombre";
            ddl_Proveedor.DataValueField = "cod_Proveedor";
            ddl_Proveedor.DataBind();
            ddl_Proveedor.Items.Add(new ListItem("--Seleccione un Proveedor--", "0"));
            ddl_Proveedor.SelectedValue = "0";
        }

        protected void btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                
                pnl_BuscarProveedor.Visible = false;
                pnl_registroProveedor.Visible = true;
                lbl_Info.Text = "Modificar Proveedor";
                int codigo = Convert.ToInt32(lbl_codigoProveedor.Text);
                string nombre = txt_Proveedor.Text;
                string domicilio = txt_Domicilio.Text;
                long telefono = Convert.ToInt32(txt_Telefono.Text);
                string email = txt_Email.Text;
                string nomCont = txt_contactoNombre.Text;
                long telCont = Convert.ToInt32(txt_contactoTelefono.Text);
                Proveedor p = new Proveedor (codigo, nombre, domicilio, telefono, email, nomCont, telCont);


                if (ProveedorManager.modificarProveedor(p) == true)
                {
                    Response.Redirect("ABM_Artista.aspx?accion=informar&mensaje=exito");
                }
                else
                {
                    Response.Redirect("ABM_Artista.aspx?accion=informar&mensaje=fracaso");
                }
                
            }
        }

        protected void btn_Agregar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int codigo = Convert.ToInt32(lbl_codigoProveedor.Text);
                string nombre = txt_Proveedor.Text;
                string domicilio = txt_Domicilio.Text;
                long telefono = Convert.ToInt32(txt_Telefono.Text);
                string email = txt_Email.Text;
                string contNombre = txt_contactoNombre.Text;
                long contTel = Convert.ToInt32(txt_contactoTelefono.Text);

                Proveedor p = new Proveedor(codigo, nombre, domicilio, telefono, email, contNombre, contTel);

                if (ProveedorManager.guardarProveedor(p))
                {
                    Response.Redirect("ABM_Artista.aspx?accion=informar&mensaje=exito");
                }
                else
                {
                    Response.Redirect("ABM_Artista.aspx?accion=informar&mensaje=fracaso");
                }
            }
        }

        protected void btn_Deshabilitar_Click(object sender, EventArgs e)
        {
            if (ProveedorManager.deshabilitarProveedor(ddl_Proveedor.SelectedIndex+1))
            {
                Response.Redirect("ABM_Artista.aspx?accion=informar&mensaje=exito");
            }
            else
            {
                Response.Redirect("ABM_Artista.aspx?accion=informar&mensaje=fracaso");
            }
        }
    }
}