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
               
                ddl_Sexo.Visible = false;
                txt_Apellido.Visible = false;
                lbl_Apellido.Visible = false;
                lbl_Sexo.Visible = false;
                lbl_Nombre.Visible = false;
                txt_Nombre.Visible = false;
                lbl_FechaNac.Visible = false;
                txt_dia.Visible = false;
                txt_mes.Visible = false;
                txt_año.Visible = false;
                lbl_dia.Visible = false;
                lbl_mes.Visible = false;
                lbl_año.Visible = false;
                ddl_PaisOrigen.Visible = false;
                lbl_PaisOrigen.Visible = false;
                btn_Agregar.Visible = false;



                if (Request.QueryString["accion"] != null)
                {
                    accion = Request.QueryString["accion"].ToString();

                    ddl_Opcion.Items.Add(new ListItem("--Seleccione una opcion--", "0"));
                    ddl_Opcion.Items.Add(new ListItem("Artista", "1"));
                    ddl_Opcion.Items.Add(new ListItem("Banda", "2"));
                    ddl_Opcion.SelectedIndex = 0;

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

                            if (a.Sexo != null)
                            { ddl_Opcion.SelectedIndex = 1;
                            ddl_Sexo.Visible = true;
                            txt_Apellido.Visible = true;
                            lbl_Apellido.Visible = true;
                            lbl_Sexo.Visible = true;
                            lbl_Nombre.Visible = true;
                            txt_Nombre.Visible = true;
                            lbl_FechaNac.Visible = true;
                            txt_dia.Visible = true;
                            txt_mes.Visible = true;
                            txt_año.Visible = true;
                            lbl_dia.Visible = true;
                            lbl_mes.Visible = true;
                            lbl_año.Visible = true;
                            ddl_PaisOrigen.Visible = true;
                            lbl_PaisOrigen.Visible = true;
                           
                            }
                            else 
                            { 
                                ddl_Opcion.SelectedIndex = 2;
                                lbl_Nombre.Visible = true;
                                txt_Nombre.Visible = true;
                                lbl_FechaNac.Visible = true;
                                txt_dia.Visible = true;
                                txt_mes.Visible = true;
                                txt_año.Visible = true;
                                lbl_dia.Visible = true;
                                lbl_mes.Visible = true;
                                lbl_año.Visible = true;
                                ddl_PaisOrigen.Visible = true;
                                lbl_PaisOrigen.Visible = true;
                            }
                            txt_Nombre.Enabled = true;
                            txt_Nombre.Text = a.Nombre;                                                      

                            txt_dia.Enabled = true;
                            txt_dia.Text = a.FechaNacimiento.Date.Day.ToString();
                            txt_mes.Enabled = true;
                            txt_mes.Text=a.FechaNacimiento.Date.Month.ToString();
                            txt_año.Enabled = true;
                            txt_año.Text=a.FechaNacimiento.Date.Year.ToString();

                            if (a.Apellido == null & a.Sexo == null)
                            {
                                ddl_Sexo.Enabled = false;
                                ddl_Sexo.Visible = false;
                                txt_Apellido.Enabled = false;
                                txt_Apellido.Visible = false;
                                lbl_Apellido.Visible = false;
                                lbl_Sexo.Visible = false;
                            }
                            else 
                            {
                                cargarCombo(ddl_Sexo);
                                ddl_Sexo.Enabled = true;
                                ddl_Sexo.SelectedValue = System.Convert.ToString(a.Sexo.Codigo);
                                txt_Apellido.Enabled = true;
                                txt_Apellido.Text = a.Apellido;
                            }
                            

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
                            cargarCombo(ddl_Buscar_Pais);
                            
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
                    // si tiene alguno tendria que eliminarse tambien
                    //Volver a cargar la grilla
                    break;
            }
        }
        protected void ddl_Opcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Opcion.SelectedItem.Text == "Artista")
            {
                lbl_Nombre.Visible = true;
                lbl_Nombre.Text = "Artista: ";
                txt_Nombre.Visible = true;
                txt_Nombre.Enabled = true;

                ddl_PaisOrigen.Visible = true;
                ddl_PaisOrigen.Enabled = true;

                lbl_Apellido.Visible = true;
                txt_Apellido.Visible = true;
                txt_Apellido.Enabled = true;
                txt_Apellido.CausesValidation = true;


                lbl_FechaNac.Visible = true;
                txt_dia.Visible = true;
                txt_mes.Visible = true;
                txt_año.Visible = true;
                txt_dia.Enabled = true;
                txt_mes.Enabled = true;
                txt_año.Enabled = true;
                lbl_dia.Visible = true;
                lbl_mes.Visible = true;
                lbl_año.Visible = true;
                

                txt_dia.CausesValidation = true;
                txt_mes.CausesValidation = true;
                txt_año.CausesValidation = true;

                lbl_Sexo.Visible = true;
                ddl_Sexo.Visible = true;
                ddl_Sexo.Enabled = true;
                ddl_Sexo.CausesValidation = true;
                                
                
                
                ddl_PaisOrigen.Visible = true;
                lbl_PaisOrigen.Visible = true;
                ddl_PaisOrigen.Enabled = true;
                btn_Agregar.Visible = true;

                cargarCombo(ddl_Sexo);
                
            }

            if (ddl_Opcion.SelectedItem.Text == "Banda")
            {
                lbl_Nombre.Visible = true;
                lbl_Nombre.Text = "Banda: ";
                txt_Nombre.Visible = true;
                txt_Nombre.Enabled = true;

                lbl_FechaNac.Visible = true;
                lbl_dia.Visible = true;
                lbl_mes.Visible = true;
                lbl_año.Visible = true;
                txt_dia.Visible = true;
                txt_mes.Visible = true;
                txt_año.Visible = true;
                txt_dia.Enabled = true;
                txt_mes.Enabled = true;
                txt_año.Enabled = true;
                txt_dia.CausesValidation = true;
                txt_mes.CausesValidation = true;
                txt_año.CausesValidation = true;

                ddl_Sexo.Visible = false;
                lbl_Sexo.Visible = false;

                ddl_PaisOrigen.Visible = true;
                ddl_PaisOrigen.Enabled = true;
                lbl_PaisOrigen.Visible = true;
                btn_Agregar.Enabled = true;

                lbl_Apellido.Visible = false;
                txt_Apellido.Visible = false;
                btn_Agregar.Visible = true;

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
                ddl.Items.Add("--Seleccione una opcion--");
                ddl.SelectedValue = "--Seleccione una opcion--";
            }
            

            if (ddl.ID.Equals("ddl_PaisOrigen") || ddl.ID.Equals("ddl_Buscar_Pais"))
            {
                DataTable dt = new DataTable();
                dt = PaisManager.obtenerTodos();

                
                ddl.DataSource = dt;
                ddl.DataTextField = "descripcion";
                ddl.DataValueField = "cod_Pais";
                ddl.DataBind();
                ddl.Items.Add("--Seleccione una opcion--");
                ddl.SelectedValue = "--Seleccione una opcion--";
            }


        }
        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        protected void cargarGrilla()
        {
            DataTable dt = new DataTable();


            if (txt_Buscar_Nombre.Text != "" && ddl_Buscar_Pais.SelectedItem.Text != "--Seleccione una opcion--")
            {
                dt = ArtistaManager.obtenerArtistasPorNombreYPais(txt_Buscar_Nombre.Text, ddl_Buscar_Pais.SelectedIndex + 1);
                gv_Buscar.DataSource = dt;
                gv_Buscar.DataBind();
            }

            if (txt_Buscar_Nombre.Text != "")
            {
                dt = ArtistaManager.obtenerArtistasPorNombre(txt_Buscar_Nombre.Text);
                gv_Buscar.DataSource = dt;
                gv_Buscar.DataBind();
            }



            if (ddl_Buscar_Pais.SelectedItem.Text != "--Seleccione una opcion--")
            {
                dt = ArtistaManager.obtenerArtistasPorPais(ddl_Buscar_Pais.SelectedIndex + 1);
                gv_Buscar.DataSource = dt;
                gv_Buscar.DataBind();
            }

            if (txt_Buscar_Nombre.Text == "" && ddl_Buscar_Pais.SelectedItem.Text == "--Seleccione una opcion--")
            {
                dt = ArtistaManager.obtenerTodos();
                gv_Buscar.DataSource = dt;
                gv_Buscar.DataBind();
            }
        }

        protected void btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int cod_Artista = System.Convert.ToInt32(lbl_Nro_Codigo.Text);
                string nombre = txt_Nombre.Text;
                string apellido = txt_Apellido.Text;
                DateTime fechaNac = new DateTime(Convert.ToInt32(txt_año.Text), Convert.ToInt32(txt_mes.Text), Convert.ToInt32(txt_dia.Text));


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
            txt_año.Text = "";
            txt_mes.Text = "";
            txt_dia.Text = "";
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
                if (ddl_Opcion.SelectedItem.Text == "Artista")
                {

                    int cod_Artista = System.Convert.ToInt32(lbl_Nro_Codigo.Text);
                    string nombre = txt_Nombre.Text;                    
                    DateTime fechaNac = new DateTime(Convert.ToInt32(txt_año.Text), Convert.ToInt32(txt_mes.Text), Convert.ToInt32(txt_dia.Text));
                    int cod_Sexo = System.Convert.ToInt32(ddl_Sexo.SelectedValue);
                    Sexo s = SexoManager.obtenerSexo(cod_Sexo);
                    int cod_Pais = System.Convert.ToInt32(ddl_PaisOrigen.SelectedValue);
                    Pais p = PaisManager.obtenerPais(cod_Pais);

                    Artista a = new Artista();

                    if (txt_Apellido.Text == "")
                    {
                        a = new Artista(cod_Artista, nombre, fechaNac, s, p);
                    }
                    else
                    {
                        string apellido = txt_Apellido.Text;
                        a = new Artista(cod_Artista, nombre, apellido, fechaNac, s, p);
                    }

                    

                    if (ArtistaManager.guardarArtista(a) == true)
                    {
                        Response.Redirect("ABM_Artista.aspx?accion=informar&mensaje=exito");
                    }
                    else
                    {
                        Response.Redirect("ABM_Artista.aspx?accion=informar&mensaje=fracaso");
                    }
                }

                if (ddl_Opcion.SelectedItem.Text == "Banda")
                {
                    int cod_Artista = System.Convert.ToInt32(lbl_Nro_Codigo.Text);
                    string nombre = txt_Nombre.Text;
                    int cod_Pais = System.Convert.ToInt32(ddl_PaisOrigen.SelectedValue);
                    DateTime fechaNac = new DateTime(Convert.ToInt32(txt_año.Text), Convert.ToInt32(txt_mes.Text), Convert.ToInt32(txt_dia.Text));
                    Pais p = PaisManager.obtenerPais(cod_Pais);

                    Artista a = new Artista(cod_Artista, nombre, fechaNac, p);

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

        protected void gv_Buscar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_Buscar.PageIndex = e.NewPageIndex;
            cargarGrilla();
                        
        }

    }
}