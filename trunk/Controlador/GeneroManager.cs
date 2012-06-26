using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Controlador
{
    public static class GeneroManager
    {

        public static Boolean guardarGenero(Negocio.Genero g)
        {
            String sql;
            Boolean b = false;
            int id = DAO.AccesoDatos.ultimoId("Genero") + 1;
            sql = "Insert into Genero(cod_Barrio, nombre) values(@cod_Genero, @nombre)";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Genero", g.Codigo));
            parametros.Add(new SqlParameter("@nombre", g.Nombre));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean modificarGenero(Negocio.Genero g)
        {
            String sql;
            Boolean b = false;
            sql = "Update Genero set cod_Genero = @cod_Genero , nombre = @nombre";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Genero", g.Codigo));
            parametros.Add(new SqlParameter("@nombre", g.Nombre));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean eliminarGenero(int codigo)
        {
            Boolean b;
            String sql = "Delete from Genero where cod_Genero = @codigo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo", codigo));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Negocio.Genero obtenerGenero(int codigo)
        {
            DataTable dt;
            String sql = "Select * From Genero where cod_Genero = @cod_Genero";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Genero", codigo));
            dt = DAO.AccesoDatos.consultar(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                int cod_Genero = (int)dt.Rows[0]["cod_Genero"];
                String nombre = (String)dt.Rows[0]["nombre"];
                Negocio.Genero bo = new Negocio.Genero(cod_Genero, nombre);
                return bo;
            }
            else
            {
                return null;
            }
        }

        public static DataTable obtenerTodos()
        {
            DataTable dt = new DataTable();
            String sql = "Select * From Genero";
            dt = DAO.AccesoDatos.consultar(sql);
            return dt;
        }
    }
}

