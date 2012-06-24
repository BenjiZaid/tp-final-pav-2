using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Controlador;

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

        protected void btn_AgregarTemas_Click(object sender, EventArgs e)
        {
            if (!txt_Temas.Text.Equals(""))
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("numero");
                dt.Columns.Add("nombre");
                dt.Columns.Add("duracion");
                DataRow dr;
                for (int i = 0; i < Convert.ToInt32(txt_Temas.Text); i++)
                {
                    dr = dt.NewRow();
                    dr[0] = i;
                    dt.Rows.Add(dr);
                }
            }
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
                ddl.SelectedValue = "--Seleccione una opcion--";
            }

            if (ddl.ID.Equals("ddl_Genero"))
            {
                ddl.Items.Add(new ListItem("--Seleccione una opcion--", Convert.ToString(0)));
                dt = GeneroManager.obtenerTodos();
                ddl.DataSource = dt;
                ddl.DataTextField = "nombre";
                ddl.DataValueField = "cod_Genero";
                ddl.DataBind();
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
                    break;
            }
        }

    }
}