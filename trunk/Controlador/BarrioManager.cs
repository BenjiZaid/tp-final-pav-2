using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Controlador
{
    public static class BarrioManager
    {

        public static Boolean guardarBarrio(Negocio.Barrio bo)
        {
            String sql;
            Boolean b = false;
            int id = DAO.AccesoDatos.ultimoId("Barrio") + 1;
            sql = "Insert into Barrio(cod_Barrio, nombre, cod_Localidad) values(@cod_Barrio, @nombre,  @cod_Localidad)";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Barrio", id));
            parametros.Add(new SqlParameter("@nombre", bo.Nombre));
            parametros.Add(new SqlParameter("@cod_Localidad", bo.Localidad.Codigo));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean modificarBarrio(Negocio.Barrio bo)
        {
            String sql;
            Boolean b = false;
            sql = "Update Barrio set cod_Barrio = @cod_Barrio, nombre = @nombre, cod_Localidad = @cod_Localidad";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Barrio", bo.Codigo));
            parametros.Add(new SqlParameter("@nombre", bo.Nombre));
            parametros.Add(new SqlParameter("@cod_Localidad", bo.Localidad.Codigo));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean eliminarBarrio(int codigo)
        {
            Boolean b;
            String sql = "Delete from Barrio where cod_Barrio = @codigo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo", codigo));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Negocio.Barrio obtenerBarrio(int codigo)
        {
            DataTable dt;
            String sql = "Select * From Barrio where cod_Barrio = @codigo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo", codigo));
            dt = DAO.AccesoDatos.consultar(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                int cod_Barrio = (int)dt.Rows[0]["cod_Barrio"];
                String nombre = (String)dt.Rows[0]["nombre"];
                int loc = (int)dt.Rows[0]["cod_Localidad"];
                Negocio.Localidad l = (Negocio.Localidad)LocalidadManager.obtenerLocalidad(loc);
                Negocio.Barrio bo = new Negocio.Barrio(cod_Barrio, nombre, l);
                return bo;
            }
            else
            {
                return null;
            }
        }

        public static DataTable obtenerTodos(int localidad)
        {
            DataTable dt = new DataTable();
            String sql = "Select * From Barrio where cod_Localidad = @cod_Localidad";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@cod_Localidad", localidad));
            dt = DAO.AccesoDatos.consultar(sql, list);
            return dt;
        }
    }
}
