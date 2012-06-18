using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UI.admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (login_admin.UserName.ToString().Equals("admin") && login_admin.Password.ToString().Equals("admin"))
            {
                Response.Redirect("Opciones.aspx");
            }
        }
    }
}