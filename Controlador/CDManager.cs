using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Controlador
{
    public static class CDManager
    {
        public static Boolean comprarCD(Negocio.CD c, List<Negocio.Ejemplar> e)
        {
            Boolean b = false;
            int id = DAO.AccesoDatos.ultimoId("CD") + 1;
            c.Codigo = id;

            List<Negocio.Tema> temas = c.Temas;
            b = DAO.Transaccion.comprarCD(c, e);
            return b;
        }

        public static Boolean modificarCD(Negocio.CD c)
        {
            String sql;
            Boolean b = false;
            sql = "Update CD set nombre = @nombre, cod_Genero = @cod_Genero, cod_Artista = @cod_Artista, año_Edicion = @año_Edicion, discografica = @discografica where cod_CD = @cod_CD ";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_CD", c.Codigo));
            parametros.Add(new SqlParameter("@nombre", c.Nombre));
            parametros.Add(new SqlParameter("@cod_Genero", c.Genero.Codigo));
            parametros.Add(new SqlParameter("@cod_Artista", c.Artista.Codigo));
            parametros.Add(new SqlParameter("@año_Edicion", c.AñoEdicion));
            parametros.Add(new SqlParameter("@discografica", c.Discografica));

            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            if (b)
            {
                TemaManager.eliminarTemasCD(c.Codigo);
                List<Negocio.Tema> temas = c.Temas;
                foreach (Negocio.Tema item in temas)
                {
                    TemaManager.guardarTema(item, c.Codigo);
                }
            }
            return b;
        }

        public static Boolean eliminarCD(int codigo)
        {
            Boolean b;
            String sql = "Delete from CD where cod_CD = @codigo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo", codigo));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Negocio.CD obtenerCD(int codigoCD)
        {
            DataTable dt, ej;
            string sql = "Select * from CD where cod_CD = @codigo";
            string sql2 = "Select * from Ejemplar where cod_CD = @codigo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_CD", codigoCD));
            dt = DAO.AccesoDatos.consultar(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                int cod_CD = (int)dt.Rows[0]["cod_CD"];
                String nombre = (String)dt.Rows[0]["nombre"];
                int cod_genero = (int)dt.Rows[0]["cod_Genero"];
                Negocio.Genero g = (Negocio.Genero)GeneroManager.obtenerGenero(cod_genero);
                int cod_Artista = (int)dt.Rows[0]["cod_Artista"];
                Negocio.Artista a = (Negocio.Artista)ArtistaManager.obtenerArtistaPorCodigo(cod_Artista);
                int año_Edicion = (int)dt.Rows[0]["año_Edicion"];
                string discografica = (string)dt.Rows[0]["discografica"];
                List<Negocio.Tema> temas = TemaManager.obtenerTemas(codigoCD);
                Negocio.CD cd = new Negocio.CD(cod_CD, nombre, temas, g, a, año_Edicion, discografica);
                return cd;
            }
            else
            {
                return null;
            }


        }

        public static int obtenerUltimo() 
        {
            string sql = "Select max(cod_CD) from CD";
            return DAO.AccesoDatos.ultimoId(sql);
        }
    }
}