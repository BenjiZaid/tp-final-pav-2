using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Controlador
{
    public static class ProvinciaManager
    {
        public static Boolean guardarProvincia(Negocio.Provincia p)
        {
            String sql;
            Boolean b = false;
            int id = DAO.AccesoDatos.ultimoId("Provincia") + 1;
            sql = "Insert into Provincia(cod_Provincia, nombre, cod_Pais) values(@cod_Provincia, @nombre,  @cod_Pais)";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Provincia", p.Codigo));
            parametros.Add(new SqlParameter("@nombre", p.Nombre));
            parametros.Add(new SqlParameter("@cod_Pais", p.Pais.Codigo));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean modificarProvincia(Negocio.Provincia p)
        {
            String sql;
            Boolean b = false;
            sql = "Update Provincia set nombre = @nombre, cod_Pais = @cod_Pais where cod_Provincia = @cod_Provincia";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Provincia", p.Codigo));
            parametros.Add(new SqlParameter("@nombre", p.Nombre));
            parametros.Add(new SqlParameter("@cod_Pais", p.Pais.Codigo));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean eliminarProvincia(int codigo)
        {
            Boolean b;
            String sql = "Delete from Provincia where cod_Provincia = @codigo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo", codigo));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Negocio.Provincia obtenerProvincia(int codigo)
        {
            DataTable dt;
            String sql = "Select * From Provincia where cod_Provincia = @codigo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo", codigo));
            dt = DAO.AccesoDatos.consultar(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                int cod_Provincia = (int)dt.Rows[0]["cod_Provincia"];
                String nombre = (String)dt.Rows[0]["nombre"];
                int ps = (int)dt.Rows[0]["cod_Pais"];
                Negocio.Pais p = (Negocio.Pais)PaisManager.obtenerPais(ps);
                Negocio.Provincia prov = new Negocio.Provincia(cod_Provincia, nombre, p);
                return prov;
            }
            else
            {
                return null;
            }
        }

        public static DataTable obtenerTodos(int pais)
        {
            DataTable dt = new DataTable();
            String sql = "Select * From Provincia where cod_Pais = @cod_Pais";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@cod_Pais", pais));
            dt = DAO.AccesoDatos.consultar(sql, list);
            return dt;
        }
    }
}

