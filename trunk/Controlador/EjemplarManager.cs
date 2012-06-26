using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Controlador
{
    public static class EjemplarManager
    {

        public static Boolean guardarEjemplar(Negocio.Ejemplar e)
        {
            String sql;
            Boolean b = false;
            sql = "Select max(cod_CD) from Ejemplar where cod_CD = @cod_CD";
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("@cod_CD", e.CodCD));
            int id = DAO.AccesoDatos.ultimoId(sql,p) + 1;

            sql = "Insert into Ejemplar(nro_Ejemplar, cod_CD, precioVenta, precioCompra, enStock) values(@nro_Ejemplar, @cod_CD, @precioVenta, @precioCompra, @enStock)";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nro_Ejemplar", id));
            parametros.Add(new SqlParameter("@cod_CD", e.CodCD));
            parametros.Add(new SqlParameter("@precioVenta", e.PrecioVenta));
            parametros.Add(new SqlParameter("@precioCompra", e.PrecioCompra));
            parametros.Add(new SqlParameter("@enStock", e.EnStock));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean modificarEjemplar(Negocio.Ejemplar e)
        {
            String sql;
            Boolean b = false;
            sql = "Update Ejemplar set cod_CD = @cod_CD, precioVenta = @precioVenta, precioCompra = @precioCompra, enStock = @enStock where nro_Ejemplar = @nro_Ejemplar";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nro_Ejemplar", e.NroEjemplar));
            parametros.Add(new SqlParameter("@cod_CD", e.CodCD));
            parametros.Add(new SqlParameter("@precioVenta", e.PrecioVenta));
            parametros.Add(new SqlParameter("@precioCompra", e.PrecioCompra));
            parametros.Add(new SqlParameter("@enStock", e.EnStock));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean eliminarEjemplar(int codigo)
        {
            Boolean b;
            String sql = "Delete from Ejemplar where nro_Ejemplar = @codigo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo", codigo));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Negocio.Ejemplar obtenerEjemplarPorCodigo(int codigo)
        {
            DataTable dt;
            string sql = "Select * From Ejemplar where nro_Ejemplar = @codigo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo", codigo));
            dt = DAO.AccesoDatos.consultar(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                int nro_Ejemplar = (int)dt.Rows[0]["nro_Ejemplar"];
                int cod_CD = (int)dt.Rows[0]["cod_CD"];
                float precioVenta = (float)dt.Rows[0]["precioVenta"];
                float precioCompra = (float)dt.Rows[0]["precioCompra"];
                Boolean enStock = (Boolean)dt.Rows[0]["enStock"];

                Negocio.Ejemplar e = new Negocio.Ejemplar(nro_Ejemplar, cod_CD, precioVenta, precioCompra);
                return e;
            }
            else
            {
                return null;
            }

        }

        public static List<Negocio.Ejemplar> obtenerEjemplaresEnStock(int codCD)
        {
            DataTable dt;
            string sql = "Select * From Ejemplar where cod_CD = @cod_CD enStock = 1";
            List<Negocio.Ejemplar> ejemplares = new List<Negocio.Ejemplar>();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo", codCD));
            dt = DAO.AccesoDatos.consultar(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int nro_Ejemplar = (int)dt.Rows[0]["nro_Ejemplar"];
                    int cod_CD = (int)dt.Rows[0]["cod_CD"];
                    float precioVenta = (float)dt.Rows[0]["precioVenta"];
                    float precioCompra = (float)dt.Rows[0]["precioCompra"];
                    Boolean enStock = (Boolean)dt.Rows[0]["enStock"];

                    Negocio.Ejemplar e = new Negocio.Ejemplar(nro_Ejemplar, cod_CD, precioVenta, precioCompra);
                    ejemplares.Add(e);
                }

                return ejemplares;
            }
            else
            {
                return null;
            }

        }

        public static int obtenerUltimo(int codCD)
        {
            string sql = "Select max(nro_Ejemplar) from Ejemplar where cod_CD = @codCD";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codCD", codCD));
            return DAO.AccesoDatos.ultimoId(sql, parametros);
            
        }
    }
}

