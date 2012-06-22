using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UI
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click1(object sender, EventArgs e)
        {
            if (Login_User.UserName.ToString().Equals("admin") && Login_User.Password.ToString().Equals("admin"))
            {
                Response.Redirect("/admin/Opciones.aspx");                
            }
            
        }
    }
}