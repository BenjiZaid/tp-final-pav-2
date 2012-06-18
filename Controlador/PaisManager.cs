using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Controlador
{
    public static class PaisManager
    {

        public static Boolean guardarPais(Negocio.Pais p)
        {
            String sql;
            Boolean b = false;
            int id = DAO.AccesoDatos.ultimoId("Pais") + 1;
            sql = "Insert into Pais(cod_Pais, nombre) values(@cod_Pais, @nombre)";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Pais", p.Codigo));
            parametros.Add(new SqlParameter("@nombre", p.Nombre));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean modificarPais(Negocio.Pais p)
        {
            String sql;
            Boolean b = false;
            sql = "Update Pais set nombre = @nombre where cod_Pais = @cod_Pais";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Pais", p.Codigo));
            parametros.Add(new SqlParameter("@nombre", p.Nombre));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean eliminarPais(int codigo)
        {
            Boolean b;
            String sql = "Delete from Pais where cod_Pais = @codigo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo", codigo));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Negocio.Pais obtenerPais(int codigo)
        {
            DataTable dt;
            String sql = "Select * From Pais where cod_Pais = @cod_Pais";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Pais", codigo));
            dt = DAO.AccesoDatos.consultar(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                int cod_Pais = (int)dt.Rows[0]["cod_Pais"];
                String nombre = (String)dt.Rows[0]["descripcion"];
                Negocio.Pais p = new Negocio.Pais(cod_Pais, nombre);
                return p;
            }
            else
            {
                return null;
            }
        }

        public static DataTable obtenerTodos()
        {
            DataTable dt = new DataTable();
            String sql = "Select * From Pais";
            dt = DAO.AccesoDatos.consultar(sql);
            return dt;
        }
    }
}
