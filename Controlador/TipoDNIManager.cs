using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace Controlador
{
    public static class TipoDNIManager
    {

        public static Boolean guardarTipoDNI(Negocio.TipoDNI t)
        {
            String sql;
            Boolean b = false;
            int id = DAO.AccesoDatos.ultimoId("TipoDNI") + 1;
            sql = "Insert into TipoDNI(cod_TipoDNI, descripcion) values(@cod_TipoDNI, @descripcion)";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_TipoDNI", t.Codigo));
            parametros.Add(new SqlParameter("@descripcion", t.Descripcion));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean modificarTipoDNI(Negocio.TipoDNI t)
        {
            String sql;
            Boolean b = false;
            sql = "Update TipoDNI set descripcion = @descripcion where cod_TipoDNI = @cod_TipoDNI";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_TipoDNI", t.Codigo));
            parametros.Add(new SqlParameter("@descripcion", t.Descripcion));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean eliminarTipoDNI(int codigo)
        {
            Boolean b;
            String sql = "Delete from TipoDNI where cod_TipoDNI = @codigo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo", codigo));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Negocio.TipoDNI obtenerTipoDNI(int codigo)
        {
            DataTable dt;
            String sql = "Select * From TipoDNI where cod_TipoDNI = @codigo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo", codigo));
            dt = DAO.AccesoDatos.consultar(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                int cod_TipoDNI = (int)dt.Rows[0]["cod_TipoDNI"];
                String descripcion = (String)dt.Rows[0]["descripcion"];
                Negocio.TipoDNI tip = new Negocio.TipoDNI(cod_TipoDNI, descripcion);
                return tip;
            }
            else
            {
                return null;
            }
        }

        public static DataTable obtenerTodos()
        {
            DataTable dt = new DataTable();
            String sql = "Select * From TipoDNI";
            dt = DAO.AccesoDatos.consultar(sql);
            return dt;
        }
    }
}
