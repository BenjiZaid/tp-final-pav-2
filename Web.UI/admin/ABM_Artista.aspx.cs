using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controlador;
using Negocio;

namespace Web.UI.admin
{
    public partial class ABM_Artista : System.Web.UI.Page
    {
        string accion = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["accion"] != null)
                {
                    accion = Request.QueryString["accion"].ToString();

                    if (accion.Equals("agregar"))
                    {
                        lbl_Accion.Text = "Agregar Artista/Banda";
                        lbl_Opcion.Text = "Agregar: ";
                        int ultimoId = ArtistaManager.obtenerUltimoId();
                        lbl_Nro_Codigo.Text = System.Convert.ToString(ultimoId + 1);
                        clean();
                        pnl_Datos.Visible = true;
                        pnl_Botones_Agregar.Visible = true;

                    }
                    else if (accion.Equals("modificar"))
                    {
                        if (Request.QueryString["codigo"] != null)
                        {
                            lbl_Accion.Text = "Modificar Artista/Banda";
                            lbl_Opcion.Text = "Tipo:";
                            lbl_Nombre.Text = "Nombre: ";
                            pnl_Buscar.Visible = false;
                            lbl_Nro_Codigo.Text = Request.QueryString["codigo"].ToString();

                            Artista a;
                            a = ArtistaManager.obtenerArtistaPorCodigo(Convert.ToInt32(lbl_Nro_Codigo.Text));


                            txt_Nombre.Enabled = true;
                            txt_Nombre.Text = a.Nombre;

                            txt_Apellido.Enabled = true;
                            txt_Apellido.Text = a.Apellido;

                            txt_FechaNac.Enabled = true;
                            txt_FechaNac.Text = a.FechaNacimiento.Date.ToShortDateString();

                            cargarCombo(ddl_Sexo);
                            ddl_Sexo.Enabled = true;
                            ddl_Sexo.SelectedValue = System.Convert.ToString(a.Sexo.Codigo);

                            cargarCombo(ddl_PaisOrigen);
                            ddl_PaisOrigen.Enabled = true;
                            ddl_PaisOrigen.SelectedValue = System.Convert.ToString(a.Pais.Codigo);

                            pnl_Datos.Visible = true;
                            pnl_Botones_Modificar.Visible = true;
                        }
                        else
                        {
                            lbl_Accion.Text = "Modificar Artista/Banda";
                            pnl_Buscar.Visible = true;

                        }
                    }
                    else if (accion.Equals("informar"))
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

                    else
                    {
                        lbl_Accion.Text = "Eliminar Artista/Banda";
                        pnl_Buscar.Visible = true;
                    }

                    ddl_Opcion.Items.Add(new ListItem("--Seleccione una opcion--", "0"));
                    ddl_Opcion.Items.Add(new ListItem("Artista", "1"));
                    ddl_Opcion.Items.Add(new ListItem("Banda", "2"));
                    ddl_Opcion.SelectedIndex = 0;
                }
            }
        }
        protected void gv_Buscar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Select":

                    int index = System.Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gv_Buscar.Rows[index];
                    string codigo = row.Cells[0].Text;

                    Response.Redirect("ABM_Artista.aspx?accion=modificar&codigo=" + codigo);
                    break;
                    case "Eliminar":
                    //Eliminar pidiendo confirmacion, ojo con los cd's del artista
                    // si tiene alguno tendria que eliminarse tmabien
                    //Volver a cargar la grilla
                    break;
            }
        }
        protected void ddl_Opcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Opcion.SelectedValue == "1")
            {
                lbl_Nombre.Text = "Artista: ";
                txt_Nombre.Enabled = true;
                ddl_PaisOrigen.Enabled = true;
                txt_Apellido.Enabled = true;
                txt_Apellido.CausesValidation = true;
                txt_FechaNac.Enabled = true;
                txt_FechaNac.CausesValidation = true;
                ddl_Sexo.Enabled = true;
                ddl_Sexo.CausesValidation = true;
                cargarCombo(ddl_Sexo);
            }

            if (ddl_Opcion.SelectedValue == "2")
            {
                lbl_Nombre.Text = "Banda: ";
                txt_Nombre.Enabled = true;
                ddl_PaisOrigen.Enabled = true;
                txt_Apellido.Enabled = false;
                txt_Apellido.CausesValidation = false;
                txt_FechaNac.Enabled = false;
                txt_FechaNac.CausesValidation = false;
                ddl_Sexo.Enabled = false;
                ddl_Sexo.CausesValidation = false;
            }

            cargarCombo(ddl_PaisOrigen);
        }

        private void cargarCombo(DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("--Seleccione una opcion--", Convert.ToString(0)));
            string id = ddl.ID;

            if (ddl.ID.Equals("ddl_Sexo"))
            {
                DataTable dt = new DataTable();
                dt = SexoManager.obtenerTodos();
                ddl.DataSource = dt;
                ddl.DataTextField = "descripcion";
                ddl.DataValueField = "cod_Sexo";
                ddl.DataBind();
                ddl.Items.Add(new ListItem("--Seleccione una opcion--","0"));
                ddl.SelectedValue = "0";
            }


            if (ddl.ID.Equals("ddl_PaisOrigen"))
            {
                DataTable dt = new DataTable();
                dt = PaisManager.obtenerTodos();
                ddl.DataSource = dt;
                ddl.DataTextField = "descripcion";
                ddl.DataValueField = "cod_Pais";
                ddl.DataBind();
                ddl.Items.Add(new ListItem("--Seleccione una opcion--", "0"));
                ddl.SelectedValue = "0";
            }
        }
        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            if (chk_Buscar.SelectedValue.ToString().Equals("chk_Nombre"))
            {
                dt = ArtistaManager.obtenerArtistasPorNombre(txt_Buscar_Nombre.Text);
                gv_Buscar.DataSource = dt;
                gv_Buscar.DataBind();
            }          

            //    default:
            //        dt = ArtistaManager.obtenerTodos();
            //        gv_Buscar.DataSource = dt;
            //        gv_Buscar.DataBind();
            //        break;
            //}
        }

        protected void btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int cod_Artista = System.Convert.ToInt32(lbl_Nro_Codigo.Text);
                string nombre = txt_Nombre.Text;
                string apellido = txt_Apellido.Text;
                DateTime fechaNac = System.Convert.ToDateTime(txt_FechaNac.Text).Date;

                int sexo = ddl_Sexo.SelectedIndex;
                Sexo s = Controlador.SexoManager.obtenerSexo(sexo + 1);

                int pais = ddl_PaisOrigen.SelectedIndex;
                Pais p = Controlador.PaisManager.obtenerPais(pais + 1);

                Artista a = new Artista(cod_Artista, nombre, apellido, fechaNac, s, p);

                if (ArtistaManager.modificarArtista(a) == true)
                {
                    Response.Redirect("ABM_Artista.aspx?accion=informar&mensaje=exito");
                }
                else
                {
                    Response.Redirect("ABM_Artista.aspx?accion=informar&mensaje=fracaso");
                }
            }

        }

        protected void clean()
        {
            txt_Nombre.Text = "";
            txt_Apellido.Text = "";
            txt_FechaNac.Text = "";
            ddl_PaisOrigen.SelectedIndex = 0;
            ddl_Sexo.SelectedIndex = 0;
        }

        protected void required_Sexo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddl_Sexo.SelectedValue == "0") args.IsValid = false;
            else { args.IsValid = true; }
        }

        protected void required_Pais_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddl_PaisOrigen.SelectedValue == "0") args.IsValid = false;
            else { args.IsValid = true; }

        }

        protected void btn_Agregar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int cod_Artista = System.Convert.ToInt32(lbl_Nro_Codigo.Text);
                string nombre = txt_Nombre.Text;
                string apellido = txt_Apellido.Text;
                DateTime fechaNac = System.Convert.ToDateTime(txt_FechaNac.Text).Date;

                int cod_Sexo = System.Convert.ToInt32(ddl_Sexo.SelectedValue);
                Sexo s = SexoManager.obtenerSexo(cod_Sexo);
                int cod_Pais = System.Convert.ToInt32(ddl_PaisOrigen.SelectedValue);
                Pais p = PaisManager.obtenerPais(cod_Pais);

                Artista a = new Artista(cod_Artista, nombre, apellido, fechaNac, s, p);

                if (ArtistaManager.guardarArtista(a) == true)
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
}