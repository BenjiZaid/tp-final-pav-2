using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Controlador
{
    public static class ArtistaManager
    {
        public static Boolean guardarArtista(Negocio.Artista a)
        {
            String sql;
            Boolean b = false;
            //int id = DAO.AccesoDatos.ultimoId("Artista") + 1;
            sql = "Insert into Artista(cod_Artista, apellido, nombre, fecha_Nacimiento, cod_Sexo, pais_Origen) values(@cod_Artista, @apellido, @nombre, @fecha_Nacimiento, @cod_Sexo, @pais_Origen)";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Artista", a.Codigo));
            parametros.Add(new SqlParameter("@apellido", a.Apellido));
            parametros.Add(new SqlParameter("@nombre", a.Nombre));
            parametros.Add(new SqlParameter("@fecha_Nacimiento", a.FechaNacimiento));
            parametros.Add(new SqlParameter("@cod_Sexo", a.Sexo.Codigo));
            parametros.Add(new SqlParameter("@pais_Origen", a.Pais.Codigo));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean modificarArtista(Negocio.Artista a)
        {
            String sql;
            Boolean b = false;
            sql = "Update Artista set apellido = @apellido, nombre = @nombre, fecha_Nacimiento = @fecha_Nacimiento, cod_Sexo = @cod_Sexo, pais_Origen = @pais_Origen where cod_Artista = @cod_Artista";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Artista", a.Codigo));
            parametros.Add(new SqlParameter("@apellido", a.Apellido));
            parametros.Add(new SqlParameter("@nombre", a.Nombre));
            parametros.Add(new SqlParameter("@fecha_Nacimiento", a.FechaNacimiento));
            parametros.Add(new SqlParameter("@cod_Sexo", a.Sexo.Codigo));
            parametros.Add(new SqlParameter("@pais_Origen", a.Pais.Codigo));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean eliminarArtista(int codigo)
        {
            Boolean b;
            String sql = "Delete from Artista where cod_Artista = @codigo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo", codigo));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Negocio.Artista obtenerArtistaPorCodigo(int codigo)
        {
            DataTable dt;
            String sql = "Select * From Artista where cod_Artista = @codigo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo", codigo));
            dt = DAO.AccesoDatos.consultar(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                int cod_Artista = (int)dt.Rows[0]["cod_Artista"];
                String nombre = (String)dt.Rows[0]["nombre"];
                String apellido = (String)dt.Rows[0]["apellido"];
                DateTime fechaNac = (DateTime)dt.Rows[0]["fecha_Nacimiento"];

                int cod_Sexo = (int)dt.Rows[0]["cod_Sexo"];
                Negocio.Sexo s = (Negocio.Sexo)SexoManager.obtenerSexo(cod_Sexo);

                int pais_Origen = (int)dt.Rows[0]["pais_Origen"];
                Negocio.Pais p = (Negocio.Pais)PaisManager.obtenerPais(pais_Origen);

                Negocio.Artista a = new Negocio.Artista(cod_Artista, nombre, apellido, fechaNac, s, p);
                return a;
            }
            else
            {
                return null;
            }
        }


        public static Negocio.Artista obtenerArtistaPorNombre(string nom)
        {
            DataTable dt;
            String sql = "Select * From Artista where nombre like '%@nombre%' or apellido like '%@nombre%'";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", nom));
            dt = DAO.AccesoDatos.consultar(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                int cod_Artista = (int)dt.Rows[0]["cod_Artista"];
                String nombre = (String)dt.Rows[0]["nombre"];
                String apellido = (String)dt.Rows[0]["apellido"];
                DateTime fechaNac = (DateTime)dt.Rows[0]["fecha_Nacimiento"];

                int cod_Sexo = (int)dt.Rows[0]["cod_Sexo"];
                Negocio.Sexo s = (Negocio.Sexo)SexoManager.obtenerSexo(cod_Sexo);

                int pais_Origen = (int)dt.Rows[0]["pais_Origen"];
                Negocio.Pais p = (Negocio.Pais)PaisManager.obtenerPais(pais_Origen);

                Negocio.Artista a = new Negocio.Artista(cod_Artista, nombre, apellido, fechaNac, s, p);
                return a;
            }
            else
            {
                return null;
            }
        }

        public static DataTable obtenerTodos()
        {
            DataTable dt = new DataTable();
            String sql = "Select * From Artista";
            dt = DAO.AccesoDatos.consultar(sql);
            return dt;
        }


        public static DataTable obtenerArtistasPorNombre(string nom)
        {
            DataTable dt;
            String sql = "Select * From Artista where nombre like '%@nombre%' or apellido like '%@nombre%'";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", nom));
            dt = DAO.AccesoDatos.consultar(sql, parametros);
                return dt;
        }
        //public static DataTable obtenerArtistasPorNombre(string nombre)
        //{
        //    DataTable dt = new DataTable();
        //    String sql = "Select * From Artista WHERE nombre LIKE '" + nombre + "'";
        //    dt = DAO.AccesoDatos.consultar(sql);
        //    return dt;
        //}

        public static DataTable obtenerArtistasPorPais(int pais)
        {
            DataTable dt = new DataTable();
            String sql = "Select * From Artista WHERE cod_Pais = " + pais;
            dt = DAO.AccesoDatos.consultar(sql);
            return dt;
        }

        public static int obtenerUltimoId()
        {
            string consulta = "Select MAX(cod_Artista) as Codigo From Artista";
            return DAO.AccesoDatos.ultimoId(consulta);
        }
    }
}
