using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DAO
{
    public static class Transaccion
    {
        static string cs = ConfigurationManager.ConnectionStrings["VentaOnlineCD"].ConnectionString.ToString();

        public static Boolean ejecutarTransaccion(String sql, List<SqlParameter> parametros)
        {
            SqlConnection cn = new SqlConnection(cs);
            cn.Open();
            SqlTransaction trans = cn.BeginTransaction();
            try
            {

                SqlCommand cm = new SqlCommand(sql, cn, trans);
                foreach (SqlParameter item in parametros)
                {
                    cm.Parameters.Add(item);
                }
                cm.ExecuteNonQuery();

                trans.Commit();
                cn.Close();
                return true;
            }
            catch (SqlException e)
            {
                try
                {
                    trans.Rollback();
                    cn.Close();
                    Console.WriteLine(e.Message);
                    return false;
                }
                catch (Exception e2)
                {
                    Console.WriteLine(e2.Message);
                    return false;
                }

            }
        }


        public static Boolean venderCD(Negocio.Venta venta)
        {
            SqlConnection cn = new SqlConnection(cs);
            cn.Open();
            SqlTransaction trans = null;
            try
            {
                //Venta
                string sql = "Insert into Venta(cod_Venta, username, fecha) values(@cod_Venta, @username, @fecha)";
                trans = cn.BeginTransaction();

                SqlCommand cm = new SqlCommand(sql, cn, trans);
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@cod_Venta", venta.CodVenta));
                parametros.Add(new SqlParameter("@username", venta.Cliente.Usuario));
                parametros.Add(new SqlParameter("@fecha", venta.Fecha));
                foreach (SqlParameter item in parametros)
                {
                    cm.Parameters.Add(item);
                }
                cm.ExecuteNonQuery();

                //Temas
                string sql2 = "Insert into DetalleVenta(cod_Venta, cod_Detalle, nro_Ejemplar, cod_CD, precioVenta) values(@cod_Venta, @cod_Detalle, @nro_Ejemplar, @cod_CD, @precioVenta)";
                
                List<Negocio.Ejemplar> ejemplares = venta.Carrito;
                int detID = 1;
                
                foreach (Negocio.Ejemplar item in ejemplares)
                {
                    SqlCommand cm2 = new SqlCommand(sql2, cn, trans);
                    List<SqlParameter> par = new List<SqlParameter>();
                    par.Add(new SqlParameter("@cod_Venta", venta.CodVenta));
                    par.Add(new SqlParameter("@cod_Detalle", detID));
                    par.Add(new SqlParameter("@nro_Ejemplar", item.NroEjemplar));
                    par.Add(new SqlParameter("@precioVenta", item.PrecioVenta));
                    par.Add(new SqlParameter("@cod_CD", item.CodCD));

                    detID++;
                    foreach (SqlParameter item2 in par)
                    {
                        cm2.Parameters.Add(item2);
                    }
                    cm2.ExecuteNonQuery();
                }

                //Ejemplares
                string sql3 = "Update Ejemplar set enStock = 0 where nro_Ejemplar = @nro_Ejemplar and cod_CD = @cod_CD and enStock = 1";
                
                
                foreach (Negocio.Ejemplar item in ejemplares)
                {
                    SqlCommand cm3 = new SqlCommand(sql3, cn, trans);
                    List<SqlParameter> p = new List<SqlParameter>();
                    p.Add(new SqlParameter("@nro_Ejemplar", item.NroEjemplar));
                    p.Add(new SqlParameter("@cod_CD", item.CodCD));
                    
                    foreach (SqlParameter item2 in p)
                    {
                        cm3.Parameters.Add(item2);
                    }
                    cm3.ExecuteNonQuery();
                }

                trans.Commit();
                cn.Close();
                return true;
            }
            catch (Exception e)
            {
                try
                {
                    trans.Rollback();
                    cn.Close();
                    Console.WriteLine(e.Message);
                    return false;
                }
                catch (Exception e2)
                {
                    Console.WriteLine(e2.Message);
                    return false;
                }

            }
        }


        public static Boolean comprarCD(Negocio.CD cd, List<Negocio.Ejemplar> ej)
        {
            SqlConnection cn = new SqlConnection(cs);
            cn.Open();
            SqlTransaction trans = null;
            try
            {
                //CD
                string sql = "Insert into CD(cod_CD, nombre, cod_Genero, cod_Artista, año_Edicion, discografica) values(@cod_CD, @nombre, @cod_Genero, @cod_Artista, @año_Edicion, @discografica)";
                trans = cn.BeginTransaction();

                SqlCommand cm = new SqlCommand(sql, cn, trans);
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@cod_CD", cd.Codigo));
                parametros.Add(new SqlParameter("@nombre", cd.Nombre));
                parametros.Add(new SqlParameter("@cod_Genero", cd.Genero.Codigo));
                parametros.Add(new SqlParameter("@cod_Artista", cd.Artista.Codigo));
                parametros.Add(new SqlParameter("@año_Edicion", cd.AñoEdicion));
                parametros.Add(new SqlParameter("@discografica", cd.Discografica));
                foreach (SqlParameter item in parametros)
                {
                    cm.Parameters.Add(item);
                }
                cm.ExecuteNonQuery();

                //Temas
                string sql2 = "Insert into Tema(cod_CD, nroPista, nombre, duracion) values(@cod_CD, @nroPista, @nombre, @duracion)";
                
                List<Negocio.Tema> l = cd.Temas;
                
                foreach (Negocio.Tema item in cd.Temas)
                {
                    SqlCommand cm2 = new SqlCommand(sql2, cn, trans);
                    List<SqlParameter> par = new List<SqlParameter>();
                    par.Add(new SqlParameter("@cod_CD", cd.Codigo));
                    par.Add(new SqlParameter("@nroPista", item.NumeroPista));
                    par.Add(new SqlParameter("@nombre", item.Nombre));
                    par.Add(new SqlParameter("@duracion", item.Duracion));


                    foreach (SqlParameter item2 in par)
                    {
                        cm2.Parameters.Add(item2);
                    }
                    cm2.ExecuteNonQuery();
                }

                //Ejemplares
                string sql3 = "Insert into Ejemplar(nro_Ejemplar, cod_CD, precioVenta, precioCompra, enStock) values(@nro_Ejemplar, @cod_CD, @precioVenta, @precioCompra, @enStock)";
                
                foreach (Negocio.Ejemplar item in ej)
                {
                    List<SqlParameter> p = new List<SqlParameter>();
                    SqlCommand cm3 = new SqlCommand(sql3, cn, trans);
                    p.Add(new SqlParameter("@nro_Ejemplar", item.NroEjemplar));
                    p.Add(new SqlParameter("@cod_CD", item.CodCD));
                    p.Add(new SqlParameter("@precioVenta", item.PrecioVenta));
                    p.Add(new SqlParameter("@precioCompra", item.PrecioCompra));
                    p.Add(new SqlParameter("@enStock", item.EnStock));


                    foreach (SqlParameter item2 in p)
                    {
                        cm3.Parameters.Add(item2);
                    }
                    cm3.ExecuteNonQuery();
                }

                trans.Commit();
                cn.Close();
                return true;
            }
            catch (Exception e)
            {
                try
                {
                    trans.Rollback();
                    cn.Close();
                    Console.WriteLine(e.Message);
                    return false;
                }
                catch (Exception e2)
                {
                    Console.WriteLine(e2.Message);
                    return false;
                }

            }
        }
    }
}

