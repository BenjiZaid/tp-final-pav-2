using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Controlador
{
    public class SexoManager
    {
        public static Boolean guardarSexo(Negocio.Sexo s)
        {
            String sql;
            Boolean b = false;
            int id = DAO.AccesoDatos.ultimoId("Sexo") + 1;
            sql = "Insert into Sexo(cod_Sexo, descripcion) values(@cod_Sexo, @descripcion)";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Sexo", s.Codigo));
            parametros.Add(new SqlParameter("@descripcion", s.Descripcion));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean modificarSexo(Negocio.Sexo s)
        {
            String sql;
            Boolean b = false;
            sql = "Update Sexo set descripcion = @descripcion where cod_Sexo = @cod_Sexo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Sexo", s.Codigo));
            parametros.Add(new SqlParameter("@descripcion", s.Descripcion));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean eliminarSexo(int codigo)
        {
            Boolean b;
            String sql = "Delete from Sexo where cod_Sexo = @codigo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo", codigo));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Negocio.Sexo obtenerSexo(int codigo)
        {
            DataTable dt;
            String sql = "Select * From Sexo where cod_Sexo = @codigo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo", codigo));
            dt = DAO.AccesoDatos.consultar(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                int cod_Sexo = (int)dt.Rows[0]["cod_Sexo"];
                String descripcion = (String)dt.Rows[0]["descripcion"];
                Negocio.Sexo s = new Negocio.Sexo(cod_Sexo, descripcion);
                return s;
            }
            else
            {
                return null;
            }
        }

        public static DataTable obtenerTodos()
        {
            DataTable dt;
            String sql = "Select * From Sexo";
            dt = DAO.AccesoDatos.consultar(sql);
            return dt;
        }
    }
}

