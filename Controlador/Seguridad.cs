using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Negocio;

namespace Controlador
{
    public class Seguridad
    {
        public static bool validarUsuario(string usuario, string password)
        {
            Cliente c;
            c = ClienteManager.obtenerCliente(usuario);
            if (c!=null)
            {
                if (c.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public static string obtenerRoles(string usuario)
        {
            string sql = "select rol from UsuarioXRol where usuario = @usuario";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@usuario", usuario));
            DataTable dt = new DataTable();
            dt = DAO.AccesoDatos.consultar(sql, parametros);
            string rol = "";
            if (dt.Rows.Count != 0)
            {
                int a = Convert.ToInt32(dt.Rows[0]["rol"]);
                sql = "select nombre from Rol where cod_Rol = " + a;
                dt = DAO.AccesoDatos.consultar(sql);
                rol = Convert.ToString(dt.Rows[0]["nombre"]);
                return rol;
            }
            
            return rol;
        }
    }

    
}
