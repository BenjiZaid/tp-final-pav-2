using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Controlador
{
    public static class LocalidadManager
    {
        public static Boolean guardarLocalidad(Negocio.Localidad l)
        {
            String sql;
            Boolean b = false;
            int id = DAO.AccesoDatos.ultimoId("Localidad") + 1;
            sql = "Insert into Localidad(cod_Localidad, nombre, cod_Provincia) values(@cod_Localidad, @nombre,  @cod_Provincia)";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Localidad", l.Codigo));
            parametros.Add(new SqlParameter("@nombre", l.Nombre));
            parametros.Add(new SqlParameter("@cod_Localidad", l.Provincia.Codigo));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean modificarLocalidad(Negocio.Localidad l)
        {
            String sql;
            Boolean b = false;
            sql = "Update Localidad set nombre = @nombre, cod_Provincia = @cod_Provincia where cod_Localidad = @cod_Localidad";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Localidad", l.Codigo));
            parametros.Add(new SqlParameter("@nombre", l.Nombre));
            parametros.Add(new SqlParameter("@cod_Provincia", l.Provincia.Codigo));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean eliminarLocalidad(int codigo)
        {
            Boolean b;
            String sql = "Delete from Localidad where cod_Localidad = @codigo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo", codigo));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Negocio.Localidad obtenerLocalidad(int codigo)
        {
            DataTable dt;
            String sql = "Select * From Localidad where cod_Localidad = @codigo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo", codigo));
            dt = DAO.AccesoDatos.consultar(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                int cod_Localidad = (int)dt.Rows[0]["cod_Localidad"];
                String nombre = (String)dt.Rows[0]["nombre"];
                int prov = (int)dt.Rows[0]["cod_Provincia"];
                Negocio.Provincia p = ProvinciaManager.obtenerProvincia(prov);
                Negocio.Localidad l = new Negocio.Localidad(cod_Localidad, nombre, p);
                return l;
            }
            else
            {
                return null;
            }
        }

        public static DataTable obtenerTodos(int provincia)
        {
            DataTable dt = new DataTable();
            String sql = "Select * From Localidad where cod_Provincia = @cod_Provincia";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@cod_Provincia", provincia));
            dt = DAO.AccesoDatos.consultar(sql, list);
            return dt;
        }
    }
}

