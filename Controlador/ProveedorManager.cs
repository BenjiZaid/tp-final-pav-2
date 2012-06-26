using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace Controlador
{
    public class ProveedorManager
    {
        public static Boolean guardarProveedor(Negocio.Proveedor p)
        {
            String sql;
            Boolean b = false;
            sql = "Insert into Proveedor(cod_Proveedor, nombre, domicilio, telefono, mail, contactoNombre, contactoTel, esHabilitado)" ;
            sql += "values(@cod_Proveedor, @nombre, @domicilio, @telefono, @mail, @nombreContacto, @telefonoContacto, 1)";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Proveedor", p.Codigo));
            parametros.Add(new SqlParameter("@nombre", p.Nombre));
            parametros.Add(new SqlParameter("@domicilio", p.Domicilio));
            parametros.Add(new SqlParameter("@telefono", p.Telefono));
            parametros.Add(new SqlParameter("@mail", p.Mail));
            parametros.Add(new SqlParameter("@nombreContacto", p.NombreContacto));
            parametros.Add(new SqlParameter("@telefonoContacto", p.TelefonoContacto));

            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean modificarProveedor(Negocio.Proveedor p)
        {
            String sql;
            Boolean b = false;
            sql = "Update Proveedor set nombre = @nombre, domicilio = @domicilio, telefono = @telefono, mail = @mail, contactoNombre = @nombreContacto, contactoTel = @telefonoContacto, esHabilitado = 1 where cod_Proveedor = @cod_Proveedor";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Proveedor", p.Codigo));
            parametros.Add(new SqlParameter("@nombre", p.Nombre));
            parametros.Add(new SqlParameter("@domicilio", p.Domicilio));
            parametros.Add(new SqlParameter("@telefono", p.Telefono));
            parametros.Add(new SqlParameter("@mail", p.Mail));
            parametros.Add(new SqlParameter("@nombreContacto", p.NombreContacto));
            parametros.Add(new SqlParameter("@telefonoContacto", p.TelefonoContacto));

            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean deshabilitarProveedor(int codigo)
        {
            Boolean b;
            String sql = "Update Proveedor set esHabilitado = 0 where cod_Proveedor = @cod_Proveedor";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Proveedor", codigo));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }




        public static Negocio.Proveedor obtenerProveedorHabilitado(int codigo)
        {
            DataTable dt;
            string sql = "Select * From Proveedor where where cod_Proveedor = @cod_Proveedor and esHabilitado = 1";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Proveedor", codigo));
            dt = DAO.AccesoDatos.consultar(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                int cod_Proveedor = (int)dt.Rows[0]["cod_Proveedor"];
                string nombre = (string)dt.Rows[0]["nombre"];
                string domicilio = (string)dt.Rows[0]["domicilio"];
                long telefono = (long)dt.Rows[0]["telefono"];
                string nombreContacto= (string)dt.Rows[0]["nombreContacto"];
                long telefonoContacto= (long)dt.Rows[0]["telefonoContacto"];
                string mail = (string)dt.Rows[0]["mail"];
                
                Negocio.Proveedor p = new Negocio.Proveedor(cod_Proveedor, nombre, domicilio, telefono, mail, nombreContacto, telefonoContacto);
                return p;
            }
            else
            {
                return null;
            }


        }

        public static Negocio.Proveedor obtenerProveedor(int codigo)
        {
            DataTable dt;
            string sql = "Select * From Proveedor where cod_Proveedor = @cod_Proveedor";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_Proveedor", codigo));
            dt = DAO.AccesoDatos.consultar(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                int cod_Proveedor = (int)dt.Rows[0]["cod_Proveedor"];
                string nombre = (string)dt.Rows[0]["nombre"];
                string domicilio = (string)dt.Rows[0]["domicilio"];
                long telefono = (long)dt.Rows[0]["telefono"];
                string nombreContacto = (string)dt.Rows[0]["contactoNombre"];
                long telefonoContacto = (long)dt.Rows[0]["contactoTel"];
                string mail = (string)dt.Rows[0]["mail"];

                Negocio.Proveedor p = new Negocio.Proveedor(cod_Proveedor, nombre, domicilio, telefono, mail, nombreContacto, telefonoContacto);
                return p;
            }
            else
            {
                return null;
            }


        }

        public static Boolean esHabilitado(int codigo) 
        {
            string sql = "select esHabilitado from Proveedor where cod_Proveedor = " + codigo ;
            return DAO.AccesoDatos.ejecutarEscalar(sql);

        }

        public static int obtenerUltimo() 
        {
            string sql = "select max(cod_Proveedor) from Proveedor";
            int id = DAO.AccesoDatos.ultimoId(sql);
            return id;
        }

        public static DataTable obtenerTodos()
        {
            DataTable dt = new DataTable();
            String sql = "Select * From Proveedor";
            dt = DAO.AccesoDatos.consultar(sql);
            return dt;
        }
    }
}
