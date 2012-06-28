using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UI.admin
{
    public partial class Opciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"].ToString().Equals("user"))
            {
                Response.Redirect("http://localhost:49166/OpcionesUsuario.aspx");
            }
            if (Session["rol"].ToString().Equals("?"))
            {
                Response.Redirect("http://localhost:49166/login.aspx");
            }
        }
    }
}