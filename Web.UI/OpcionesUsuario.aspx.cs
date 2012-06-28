using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Controlador;
using System.Drawing;

namespace Web.UI
{
    public partial class OpcionesUsuario : System.Web.UI.Page
    {
         protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["rol"].ToString().Equals("?"))
                {
                    Response.Redirect("http://localhost:49166/login.aspx");
                }
                pnl_discos.Visible = false;
                pnl_albums.Visible = false;
                pnl_temas.Visible = false;
                pnl_artistas.Visible = true;
            }
            

        }

        protected void btn_buscar_Click(object sender, ImageClickEventArgs e)
        {
            lbl_album.Text = "";
            lbl_artista.Text = "";
            pnl_discos.Visible = false;
            pnl_artistas.Visible = true;
            pnl_Cliente.Visible = true;
            DataTable tabla = ArtistaManager.obtenerArtistasPorNombres(txt_buscar.Text);
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                DateTime fecha = Convert.ToDateTime(tabla.Rows[i][2].ToString());
                string sinhora = fecha.ToShortDateString();
                tabla.Rows[i][2] = sinhora;
            }
            gv_artistas.DataSource = tabla;
            gv_artistas.DataBind();
        }

        protected void buscar(string n)
        {
            txt_buscar.Text = "";
            lbl_album.Text = "";
            lbl_artista.Text = "";
            pnl_discos.Visible = false;
            pnl_artistas.Visible = true;
            gv_artistas.DataSource = ArtistaManager.obtenerArtistasPorCaracter(n);
            gv_artistas.DataBind();
        }


         protected void gv_artistas_SelectedIndexChanged(object sender, EventArgs e)
         {
             pnl_discos.Visible = true;
             pnl_albums.Visible = true;
             pnl_artistas.Visible = false;
             pnl_temas.Visible = false;
             if (gv_artistas.SelectedRow.Cells[2].Text.Equals(""))
             {
                 lbl_artista.Text = gv_artistas.SelectedRow.Cells[1].Text;
             }
             else
             {
                 lbl_artista.Text = gv_artistas.SelectedRow.Cells[1].Text;
                 lbl_apellido.Text = gv_artistas.SelectedRow.Cells[2].Text;
             }

             int cod = Convert.ToInt32(ArtistaManager.obtenerID(gv_artistas.SelectedRow.Cells[1].Text));
             gv_albums.DataSource = CDManager.obtenerCDPorArtista(cod);
             gv_albums.DataBind();
         }

         protected void gv_albums_SelectedIndexChanged(object sender, EventArgs e)
         {
             pnl_artistas.Visible = false;
             pnl_discos.Visible = false;
             pnl_albums.Visible = false;
             pnl_temas.Visible = true;
             lbl_album.Text = gv_albums.SelectedRow.Cells[1].Text;
             int album = Convert.ToInt32(CDManager.obtenerID(gv_albums.SelectedRow.Cells[1].Text));
             int cant = EjemplarManager.enStock(album);
             double precio = Convert.ToDouble(EjemplarManager.obtenerPrecio(album));
             lbl_Precio.Text = ""+precio;
             if (cant > 0) 
             {
                 lbl_Stock.Text = "Stock: ";
                 lbl_stockn.Text = ""+cant;
                 lbl_Stock.ForeColor = Color.Green;
                 lbl_stockn.ForeColor = Color.Green;
                 btn_agregarCarrito.Enabled=true;
             }
             else
             {
                 lbl_Stock.Text = "No hay stock. Disculpe las molestias";
                 lbl_Stock.ForeColor=Color.Red;
                 btn_agregarCarrito.Enabled=false;
             }

             gv_temas.DataSource = TemaManager.obtenerTemasTabla(album);
             gv_temas.DataBind();
         }

         protected void btn_volverArtistas_Click(object sender, EventArgs e)
         {
             pnl_albums.Visible = false;
             pnl_discos.Visible = false;
             pnl_artistas.Visible = true;
             pnl_temas.Visible = false;
             lbl_artista.Text = "";
             limpiarCantidad();
         }

         protected void btn_volverCDS_Click(object sender, EventArgs e)
         {
             pnl_temas.Visible = false;
             pnl_albums.Visible = true;
             pnl_discos.Visible = true;
             pnl_artistas.Visible = false;
             lbl_album.Text = "";
             limpiarCantidad();
         }

         protected void limpiarCantidad() 
         {
             txt_cantidad.BackColor = Color.White;
             txt_cantidad.Text = "";
         }

        protected void btn_numeros_Click(object sender, EventArgs e)
        {
            buscar(btn_numeros.Text);
        }

        protected void btn_a_Click(object sender, EventArgs e)
        {
            buscar(btn_a.Text);
        }

        protected void btn_b_Click(object sender, EventArgs e)
        {
            buscar(btn_b.Text);
        }

        protected void btn_c_Click(object sender, EventArgs e)
        {
            buscar(btn_c.Text);
        }

        protected void btn_d_Click(object sender, EventArgs e)
        {
            buscar(btn_d.Text);
        }

        protected void btn_e_Click(object sender, EventArgs e)
        {
            buscar(btn_e.Text);
        }

        protected void btn_F_Click(object sender, EventArgs e)
        {
            buscar(btn_d.Text);
        }

        protected void btn_g_Click(object sender, EventArgs e)
        {
            buscar(btn_g.Text);
        }

        protected void btn_h_Click(object sender, EventArgs e)
        {
            buscar(btn_h.Text);
        }

        protected void btn_i_Click(object sender, EventArgs e)
        {
            buscar(btn_i.Text);
        }

        protected void btn_j_Click(object sender, EventArgs e)
        {
            buscar(btn_j.Text);
        }

        protected void btn_k_Click(object sender, EventArgs e)
        {
            buscar(btn_k.Text);
        }

        protected void btn_l_Click(object sender, EventArgs e)
        {
            buscar(btn_l.Text);
        }

        protected void btn_m_Click(object sender, EventArgs e)
        {
            buscar(btn_m.Text);
        }

        protected void btn_n_Click(object sender, EventArgs e)
        {
            buscar(btn_n.Text);
        }

        protected void btn_o_Click(object sender, EventArgs e)
        {
            buscar(btn_o.Text);
        }

        protected void btn_p_Click(object sender, EventArgs e)
        {
            buscar(btn_p.Text);
        }

        protected void btn_q_Click(object sender, EventArgs e)
        {
            buscar(btn_q.Text);
        }

        protected void btn_r_Click(object sender, EventArgs e)
        {
            buscar(btn_r.Text);
        }

        protected void btn_s_Click(object sender, EventArgs e)
        {
            buscar(btn_r.Text);
        }

        protected void btn_t_Click(object sender, EventArgs e)
        {
            buscar(btn_t.Text);
        }

        protected void btn_u_Click(object sender, EventArgs e)
        {
            buscar(btn_u.Text);
        }

        protected void btn_v_Click(object sender, EventArgs e)
        {
            buscar(btn_v.Text);
        }

        protected void btn_w_Click(object sender, EventArgs e)
        {
            buscar(btn_w.Text);
        }

        protected void btn_x_Click(object sender, EventArgs e)
        {
            buscar(btn_x.Text);
        }

        protected void btn_y_Click(object sender, EventArgs e)
        {
            buscar(btn_y.Text);
        }

        protected void btn_z_Click(object sender, EventArgs e)
        {
            buscar(btn_z.Text);
        }

        protected void btn_agregarCarrito_Click(object sender, EventArgs e)
        {
                if (txt_cantidad.Text.Equals("") || Convert.ToInt32(txt_cantidad.Text) > Convert.ToInt32(lbl_stockn.Text) )
                {
                    txt_cantidad.BackColor = Color.Red;
                }
                else
                {
                    txt_cantidad.BackColor=Color.White;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Nombre");
                    dt.Columns.Add("Apellido");
                    dt.Columns.Add("Album");
                    dt.Columns.Add("Precio");
                    dt.Columns.Add("Cantidad");
                    string artista = lbl_artista.Text;
                    string apellido = lbl_apellido.Text;
                    string album = lbl_album.Text;
                    int albumID = Convert.ToInt32(CDManager.obtenerID(lbl_album.Text));
               
                    string cantidad = txt_cantidad.Text;
                    string precio = EjemplarManager.obtenerPrecio(Convert.ToInt32(albumID));
                    if (gv_carrito.Rows.Count == 0)
                    {
			                DataRow dr = dt.NewRow();
                            dr["Nombre"] = artista;
                            dr["Apellido"] = apellido;
                            dr["Album"] = album;
                            dr["Precio"] = precio;
                            dr["Cantidad"] = cantidad;
                            dt.Rows.Add(dr);
                            gv_carrito.DataSource = dt;
                            gv_carrito.DataBind();
                            limpiarCantidad();
                            calcularTotal();
                    }
                    else
                    {

                        int count = gv_carrito.Rows.Count;
                        for (int i = 0; i < gv_carrito.Rows.Count; i++)
                        {
                            string art = gv_carrito.Rows[i].Cells[1].Text;
                            string ape = gv_carrito.Rows[i].Cells[2].Text;
                            string alb = gv_carrito.Rows[i].Cells[3].Text;
                            string pre = gv_carrito.Rows[i].Cells[4].Text;
                            string can = gv_carrito.Rows[i].Cells[5].Text;

                            DataRow dr = dt.NewRow();
                            dr["Nombre"] = art;
                            dr["Apellido"] = ape;
                            dr["Album"] = alb;
                            dr["Precio"] = pre;
                            dr["Cantidad"] = can;
                            dt.Rows.Add(dr);
                        }
                        
                        for (int i = 0; i < count; i++)
			            {
			                if (artista.Equals(dt.Rows[i]["Nombre"].ToString()) && apellido.Equals(dt.Rows[i]["Apellido"].ToString()))
                            {
                                if (album.Equals(dt.Rows[i]["Album"].ToString()))
                                {
                                     int cant = Convert.ToInt32(dt.Rows[i]["Cantidad"].ToString());
                                     cant = Convert.ToInt32(cantidad) + cant;
                                     cantidad = "" + cant;
                                     dt.Rows[i]["Cantidad"] = cantidad;
                                     gv_carrito.DataSource = dt;
                                     gv_carrito.DataBind();
                                     limpiarCantidad();
                                     calcularTotal();
                                     return;                                     
                                }
                            }
                            DataRow dr = dt.NewRow();
                            dr["Nombre"] = artista;
                            if (!apellido.Equals("&nbsp;"))
                            {
                                dr["Apellido"] = apellido;
                            }
                           
                            dr["Album"] = album;
                            dr["Precio"] = precio;
                            dr["Cantidad"] = cantidad;
                            dt.Rows.Add(dr);
                            
			            }

                        gv_carrito.DataSource = dt;
                        gv_carrito.DataBind();
                        limpiarCantidad();
                        calcularTotal();
                    }
                }
            }
        
            
        
        protected void gv_artistas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_artistas.PageIndex = e.NewPageIndex;
            buscar("");
        }

        protected void btn_Comprar_Click(object sender, EventArgs e)
        {
            if (gv_carrito.Rows.Count > 0)
            {
                int codVenta = VentaManager.obtenerUltimoId();
                string user = Session["user"].ToString();
                Negocio.Cliente client = ClienteManager.obtenerCliente(user);
                DateTime fecha = DateTime.Now;
                List<Negocio.Ejemplar> lista = new List<Negocio.Ejemplar>();
                for (int i = 0; i < gv_carrito.Rows.Count; i++)
			    {                                   	            
                    int album = Convert.ToInt32(CDManager.obtenerID(gv_carrito.Rows[i].Cells[3].Text));
                    for (int a = i; a < Convert.ToInt32(gv_carrito.Rows[i].Cells[5].Text); a++)
                    {
                        DataTable codEj = EjemplarManager.obtenerEjemplar(album);
                        int codEjemplar = Convert.ToInt32(codEj.Rows[a][0].ToString());
                        double precio = Convert.ToDouble(gv_carrito.Rows[i].Cells[4].Text);
                        Negocio.Ejemplar item = new Negocio.Ejemplar(codEjemplar, album, precio);
                        lista.Add(item);
                        
                    }
                    
			    }
                Negocio.Venta venta = new Negocio.Venta(codVenta, client, fecha, lista);
                
                if (VentaManager.ventaCD(venta))
                    {
                        Response.Redirect("Informacion.aspx?accion=informar&mensaje=exito");
                    }
                    else
                    {
                        Response.Redirect("Informacion.aspx?accion=informar&mensaje=fracaso");
                    } 
            }
        }

        protected void calcularTotal()
        {
            double total = 0;
            if (gv_carrito.Rows.Count > 0)
            {
                
                for (int i = 0; i < gv_carrito.Rows.Count; i++)
                {
                    double precio = Convert.ToDouble(gv_carrito.Rows[i].Cells[4].Text);
                    int cant = Convert.ToInt32(gv_carrito.Rows[i].Cells[5].Text);
                    total = total + (precio * cant);
                }
                
            }
            lbl_total.Text = "" + total;
            
        }

        protected void gv_carrito_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Artista");
            dt.Columns.Add("Album");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Cantidad");
            for (int i = 0; i < gv_carrito.Rows.Count; i++)
            {
                string art = gv_carrito.Rows[i].Cells[1].Text;
                string alb = gv_carrito.Rows[i].Cells[2].Text;
                string pre = gv_carrito.Rows[i].Cells[3].Text;
                string can = gv_carrito.Rows[i].Cells[4].Text;
                if (i != gv_carrito.SelectedIndex + 1)
                {
                    DataRow dr = dt.NewRow();
                    dr["Artista"] = art;
                    dr["Album"] = alb;
                    dr["Precio"] = pre;
                    dr["Cantidad"] = can;
                    dt.Rows.Add(dr);
                }
                
            }
            gv_carrito.DataSource = dt;
            gv_carrito.DataBind();
            calcularTotal();
        }














    }
}