using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controlador;

namespace Web.UI
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            }
        }

        protected void LoginButton_Click1(object sender, EventArgs e)
        {
            if (Seguridad.obtenerRoles(Login_User.UserName.ToString()).Equals("admin"))
            {
                Response.Redirect("/admin/Opciones.aspx");                
            }
            if (Seguridad.obtenerRoles(Login_User.UserName.ToString()).Equals("user"))
            {
                Response.Redirect("OpcionesUsuario.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            
        }
    }
}