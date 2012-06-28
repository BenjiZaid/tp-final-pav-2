using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UI
{
    public partial class Informacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion = Request.QueryString["accion"];
            string mensaje = Request.QueryString["mensaje"];
            if (mensaje.Equals("exito"))
            {
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
}