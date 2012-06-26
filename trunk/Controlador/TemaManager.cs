using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Controlador
{
    public class TemaManager
    {
        public static Boolean guardarTema(Negocio.Tema t, int codigoCD)
        {
            String sql;
            Boolean b = false;
            int id = DAO.AccesoDatos.ultimoId("Codigo") + 1;
            sql = "Insert into CD(cod_CD, nroPista, nombre, duracion) values(@cod_CD, @nroPista, @nombre, @duracion)";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_CD", codigoCD));
            parametros.Add(new SqlParameter("@nroPista", t.NumeroPista));
            parametros.Add(new SqlParameter("@nombre", t.Nombre));
            parametros.Add(new SqlParameter("@duracion", t.Duracion));

            b = DAO.AccesoDatos.ejecutar(sql, parametros);

            return b;
        }

        public static Boolean modificarTema(Negocio.Tema t, int codigoCD)
        {
            String sql;
            Boolean b = false;
            sql = "Update Tema set nombre = @nombre, duracion = @duracion where cod_CD = @cod_CD and nroPista =@nroPista ";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_CD", codigoCD));
            parametros.Add(new SqlParameter("@nroPista", t.NumeroPista));
            parametros.Add(new SqlParameter("@nombre", t.Nombre));
            parametros.Add(new SqlParameter("@duracion", t.Duracion));

            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean eliminarTemasCD(int codigoCD)
        {
            Boolean b;
            String sql = "Delete from Tema where cod_CD = @codigo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo", codigoCD));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Negocio.Tema obtenerTema(string nombre)
        {
            DataTable dt;
            string sql = "Select * From Tema where nombre like '%'+@nombre+'%'";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", nombre));
            dt = DAO.AccesoDatos.consultar(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                int cod_CD = (int)dt.Rows[0]["cod_CD"];
                int nroPista = (int)dt.Rows[0]["nroPista"];
                string nom = (string)dt.Rows[0]["nombre"];
                string duracion = (string)dt.Rows[0]["duracion"];

                Negocio.Tema cd = new Negocio.Tema(cod_CD, nroPista, nombre, duracion);
                return cd;
            }
            else
            {
                return null;
            }


        }

        public static List<Negocio.Tema> obtenerTemas(int codigoCD)
        {
            DataTable dt;
            String sql = "Select * From Tema where cod_CD = @codigoCD";
            List<Negocio.Tema> lista = new List<Negocio.Tema>();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigoCD", codigoCD));
            dt = DAO.AccesoDatos.consultar(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int cod_CD = (int)dt.Rows[0]["cod_CD"];
                    int nroPista = (int)dt.Rows[0]["nroPista"];
                    string nom = (String)dt.Rows[0]["nombre"];
                    string duracion = (string)dt.Rows[0]["duracion"];
                    lista.Add(new Negocio.Tema(cod_CD, nroPista, nom, duracion));
                }



                return lista;
            }
            else
            {
                return null;
            }


        }
    }
}

