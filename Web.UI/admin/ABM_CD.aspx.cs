using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Controlador;
using DAO;

namespace Web.UI.admin
{
    public partial class ABM_CD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RangeValidator.MaximumValue = DateTime.Today.ToString("yyyy");
                pnl_AgregarCD.Visible = false;
                pnl_Buscar.Visible = true;
                pnl_BuscarArt.Visible = true;
                pnl_Datos.Visible = true;
                cargarCombo(ddl_Buscar_Pais);
                lbl_Accion.Text = "Buscar Artista";
            }
           
        }

        protected void btn_AgregarTema_Click(object sender, EventArgs e)
        {

          
        }

        protected void cargarCombo(DropDownList ddl) 
        {
            DataTable dt = new DataTable();
            

            if (ddl.ID.Equals("ddl_Buscar_Pais"))
            {
                ddl.Items.Add(new ListItem("--Seleccione una opcion--", Convert.ToString(0)));
                dt = PaisManager.obtenerTodos();
                ddl.DataSource = dt;
                ddl.DataTextField = "descripcion";
                ddl.DataValueField = "cod_Pais";
                ddl.DataBind();
                ddl.Items.Add(new ListItem("--Seleccione una opcion--", Convert.ToString(0)));
                ddl.SelectedValue = "--Seleccione una opcion--";
            }

            if (ddl.ID.Equals("ddl_Genero"))
            {
                
                dt = GeneroManager.obtenerTodos();
                ddl.DataSource = dt;
                ddl.DataTextField = "nombre";
                ddl.DataValueField = "cod_Genero";
                ddl.DataBind();
                ddl.Items.Add(new ListItem("--Seleccione una opcion--", Convert.ToString(0)));
                //ddl.SelectedValue = "--Seleccione una opcion--";
            }

            if (ddl.ID.Equals("ddl_Proveedor"))
            {

                dt = ProveedorManager.obtenerTodos();
                ddl.DataSource = dt;
                ddl.DataTextField = "nombre";
                ddl.DataValueField = "cod_Proveedor";
                ddl.DataBind();
                ddl.Items.Add(new ListItem("--Seleccione una opcion--", Convert.ToString(0)));
                //ddl.SelectedValue = "--Seleccione una opcion--";
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


        protected void gv_Buscar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_Buscar.PageIndex = e.NewPageIndex;
            cargarGrilla();
        }


        protected void gv_Buscar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Select":
                    pnl_Buscar.Visible = false;
                    pnl_AgregarCD.Visible = true;

                    int index = System.Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gv_Buscar.Rows[index];
                    string codigo = row.Cells[0].Text;

                    lbl_Codigo.Text = codigo;
                    if (row.Cells[2].Text.Equals(""))
                    {
                        lbl_Artista.Text = row.Cells[1].Text;
                    }
                    else 
                    {
                    string art = row.Cells[1].Text + " " + row.Cells[2].Text;
                    lbl_Artista.Text = art;
                    }
                    lbl_Accion.Text = "Agregar CD";
                    cargarCombo(ddl_Genero);
                    cargarCombo(ddl_Proveedor);
                    
                    break;
            }
        }

        protected void btn_AgregarTema_Click1(object sender, EventArgs e)
        {
            string nombre = txt_NombrePista.Text;
            string duracion = txt_Minutos.Text+":"+txt_Segundos.Text;
            string numero = Convert.ToString(gv_Temas.Rows.Count + 1);
            
            DataTable dt = new DataTable();
            dt.Columns.Add("Numero");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Duracion");

            if (gv_Temas.Rows.Count == 0)
            {
                
                gv_Temas.DataSource = agregarFila(dt, numero, nombre, duracion);
                gv_Temas.DataBind();
                clearTema();
            }
            else
            {
                for (int i = 0; i < gv_Temas.Rows.Count; i++)
                {
                    string nom = gv_Temas.Rows[i].Cells[1].Text;
                    string num = gv_Temas.Rows[i].Cells[0].Text;
                    string dur = gv_Temas.Rows[i].Cells[2].Text;
                    dt=agregarFila(dt, num, nom, dur);
                }
                dt = agregarFila(dt, numero, nombre, duracion);
                gv_Temas.DataSource = dt;
                gv_Temas.DataBind();
                clearTema();
            }
            lbl_Pista.Text = Convert.ToString(gv_Temas.Rows.Count + 1);
        }


        protected DataTable agregarFila(DataTable dt, string numero, string nombre, string duracion) 
        {
            DataRow dr = dt.NewRow();
            
            dr[0] = numero;
            dr[1] = nombre;
            dr[2] = duracion;
            dt.Rows.Add(dr);
            return dt;
        }

        protected void clearTema() 
        {
            txt_NombrePista.Text = "";
            txt_Segundos.Text = "";
            txt_Minutos.Text = "";
        }

        protected void gv_Temas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Select":
                    int index = System.Convert.ToInt32(e.CommandArgument);
                    DataTable dt = new DataTable();
                    DataRow dr;
                    dt.Columns.Add("Numero");
                    dt.Columns.Add("Nombre");
                    dt.Columns.Add("Duracion");
                    if (gv_Temas.Rows.Count  != 1)
                    {
                        for (int i = 0; i < gv_Temas.Rows.Count; i++)
                        {
                            dr = dt.NewRow();
                            if (i != gv_Temas.SelectedIndex)
                            {
                                string nombre = gv_Temas.Rows[i].Cells[1].Text;
                                int numero = Convert.ToInt32(gv_Temas.Rows[i].Cells[0].Text);
                                string duracion = gv_Temas.Rows[i].Cells[2].Text;
                                if (gv_Temas.SelectedIndex < i)
	                            {
                                    dr[0] = numero - 1;
                                    dr[1] = nombre;
                                    dr[2] = duracion;
                                    dt.Rows.Add(dr);
	                            }
                                else
                                {
                                    dr[0] = numero;
                                    dr[1] = nombre;
                                    dr[2] = duracion;
                                    dt.Rows.Add(dr);
                                }

                            }

                            
                            
                        }
                    }
                    gv_Temas.DataSource = dt;
                    gv_Temas.DataBind();
                    lbl_Pista.Text = Convert.ToString(gv_Temas.Rows.Count + 1);
                    break;
            }
        }

        protected void btn_Comprar_Click(object sender, EventArgs e)
        {
            List<Negocio.Tema> temas = new List<Negocio.Tema>();
            List<Negocio.Ejemplar> ejemplares = new List<Negocio.Ejemplar>();
            int codCD = CDManager.obtenerUltimo() + 1;

            for (int i = 0; i < gv_Temas.Rows.Count; i++)
			{
			    int nro = Convert.ToInt32(gv_Temas.Rows[i].Cells[0].Text);
                string nom = gv_Temas.Rows[i].Cells[1].Text;
                string dur = gv_Temas.Rows[i].Cells[2].Text;
                Negocio.Tema tema = new Negocio.Tema(codCD, nro, nom, dur);
                temas.Add(tema);
			}

            
            string nombre = txt_NombreCD.Text;
            int codGenero = ddl_Genero.SelectedIndex+1;
            Negocio.Genero genero = GeneroManager.obtenerGenero(codGenero);
            int codArtista = Convert.ToInt32(lbl_Codigo.Text);
            Negocio.Artista artista = ArtistaManager.obtenerArtistaPorCodigo(codArtista);
            int año = Convert.ToInt32(txt_AñoEdicion.Text);
            string discografica = txt_Discografica.Text;

            Negocio.CD cd = new Negocio.CD(codCD, nombre, temas, genero, artista, año, discografica);

            for (int i = 0; i < Convert.ToInt32(txt_ejemplares.Text); i++)
			{
			    int nroEjemplar = i+1;
                double precioCompra = Convert.ToDouble(txt_precioCompra.Text);
                double precioVenta = Convert.ToDouble(txt_precioVenta.Text);
                Negocio.Ejemplar ejemplar = new Negocio.Ejemplar(nroEjemplar, codCD, precioVenta, precioCompra);
                ejemplares.Add(ejemplar);
			}

            
            if (DAO.Transaccion.comprarCD(cd, ejemplares))
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