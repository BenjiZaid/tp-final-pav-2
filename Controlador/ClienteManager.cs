using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Controlador
{
    public static class ClienteManager
    {

        public static Boolean guardarCliente(Negocio.Cliente c)
        {
            String sql;
            Boolean b = false;
            int activo = 1;
            if (obtenerCliente(c.Usuario) != null)
            {
                return false;
            }
            sql = "Insert into Cliente(username, password, cod_TipoDNI, nroDNI, apellido, nombre, fecha_Nacimiento, domicilio, cod_Barrio, cod_Sexo, email, telefono, celular, activo)";
            sql += "values(@username, @password, @cod_TipoDNI, @nroDNI, @apellido, @nombre, @fecha_Nacimiento, @domicilio, @cod_Barrio, @cod_Sexo, @email, @telefono, @celular, @activo)";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@username", c.Usuario));
            parametros.Add(new SqlParameter("@password", c.Password));
            parametros.Add(new SqlParameter("@cod_TipoDNI", c.TipoDNI.Codigo));
            parametros.Add(new SqlParameter("@nroDNI", c.NroDoc));
            parametros.Add(new SqlParameter("@apellido", c.Apellido));
            parametros.Add(new SqlParameter("@nombre", c.Nombre));
            parametros.Add(new SqlParameter("@fecha_Nacimiento", c.FechaNac));
            parametros.Add(new SqlParameter("@domicilio", c.Domicilio));
            parametros.Add(new SqlParameter("@cod_Barrio", c.Barrio.Codigo));
            parametros.Add(new SqlParameter("@cod_Sexo", c.Sexo.Codigo));
            parametros.Add(new SqlParameter("@email", c.Email));
            parametros.Add(new SqlParameter("@telefono", c.Telefono));
            parametros.Add(new SqlParameter("@celular", c.Celular));
            parametros.Add(new SqlParameter("@activo", activo));

            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean modificarCliente(Negocio.Cliente c)
        {
            String sql;
            Boolean b = false;
            int activo = 1;
            sql = "Update Cliente set password = @password, cod_TipoDNI = @cod_TipoDNI, nroDNI= @nroDNI, apellido = @apellido, nombre=@nombre, fecha_Nacimiento = @fecha_Nacimiento, domicilio=@domicilio, cod_Barrio=@cod_Barrio, cod_Sexo=@cod_Sexo, email=@email, telefono=@telefono, celular=@celular where username = @username ";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@username", c.Usuario));
            parametros.Add(new SqlParameter("@password", c.Password));
            parametros.Add(new SqlParameter("@cod_TipoDNI", c.TipoDNI.Codigo));
            parametros.Add(new SqlParameter("@nroDNI", c.NroDoc));
            parametros.Add(new SqlParameter("@apellido", c.Apellido));
            parametros.Add(new SqlParameter("@nombre", c.Nombre));
            parametros.Add(new SqlParameter("@fecha_Nacimiento", c.FechaNac));
            parametros.Add(new SqlParameter("@domicilio", c.Domicilio));
            parametros.Add(new SqlParameter("@cod_Barrio", c.Barrio.Codigo));
            parametros.Add(new SqlParameter("@cod_Sexo", c.Sexo.Codigo));
            parametros.Add(new SqlParameter("@email", c.Email));
            parametros.Add(new SqlParameter("@telefono", c.Telefono));
            parametros.Add(new SqlParameter("@celular", c.Celular));
            parametros.Add(new SqlParameter("@activo", activo));

            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean eliminarCliente(string username)
        {
            Boolean b;
            String sql = "Delete from CD where username = @username";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@username", username));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }

        public static Boolean bajaCliente(string username)
        {
            Boolean b;
            int activo = 0;
            String sql = "Update Cliente set activo=@activo where username = @username";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@username", username));
            parametros.Add(new SqlParameter("@activo", activo));
            b = DAO.AccesoDatos.ejecutar(sql, parametros);
            return b;
        }



        public static Negocio.Cliente obtenerCliente(string username)
        {
            DataTable dt;
            int activo = 1;
            string sql = "Select * From Cliente where username = @username and activo=@activo";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@username", username));
            parametros.Add(new SqlParameter("@activo", activo));
            dt = DAO.AccesoDatos.consultar(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                string usrname = (string)dt.Rows[0]["username"];
                string password = (string)dt.Rows[0]["password"];
                int cod_TipoDNI = (int)dt.Rows[0]["cod_TipoDNI"];
                Negocio.TipoDNI t = TipoDNIManager.obtenerTipoDNI(cod_TipoDNI);
                int nroDNI = (int)dt.Rows[0]["nroDNI"];
                string nombre = (string)dt.Rows[0]["nombre"];
                string apellido = (string)dt.Rows[0]["apellido"];
                DateTime fecha_Nacimiento = (DateTime)dt.Rows[0]["fecha_Nacimiento"];
                string domicilio = (string)dt.Rows[0]["domicilio"];

                int barrio = (int)dt.Rows[0]["cod_Barrio"];
                Negocio.Barrio b = BarrioManager.obtenerBarrio(barrio);

                int cod_Sexo = (int)dt.Rows[0]["cod_Sexo"];
                Negocio.Sexo s = SexoManager.obtenerSexo(cod_Sexo);
                string email = (string)dt.Rows[0]["email"];
                string telefono = (string)dt.Rows[0]["telefono"];
                string celular = (string)dt.Rows[0]["celular"];


                Negocio.Cliente c = new Negocio.Cliente(usrname, password, t, nroDNI, nombre, apellido, fecha_Nacimiento, domicilio, b, s, email, telefono, celular);
                return c;
            }
            else
            {
                return null;
            }


        }
    }
}

