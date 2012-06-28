using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controlador;
using System.Drawing;

namespace Web.UI
{
    public partial class login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["accion"] == "cerrar")
            {
                Session["rol"] = "";
                Session["user"] = "";
            }
        }

        protected void btn_Ingresar_Click(object sender, EventArgs e)
        {
            if (Seguridad.validarUsuario(txt_usuario.Text, txt_contraseña.Text))
            {
                string rol = Seguridad.obtenerRoles(txt_usuario.Text);
                if (rol.Equals("admin"))
                {
                    Session["rol"] = rol;
                    Response.Redirect("admin/Opciones.aspx");
                }
                if (rol.Equals("user"))
                {
                    Session["rol"] = rol;
                    Session["user"] = txt_usuario.Text;
                    Response.Redirect("OpcionesUsuario.aspx");
                }
                
            }
            else
            {
                lbl_error.Text = "Verifique su nombre de usuario y contraseña por favor.";
                lbl_error.ForeColor = Color.Red;
                txt_contraseña.Text = "";
            }
        }
    }
}