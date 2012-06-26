using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DAO
{
    public static class AccesoDatos
    {
        public static SqlConnection conexion()
        {
            string cs = ConfigurationManager.ConnectionStrings["VentaOnlineCD"].ConnectionString.ToString();
            SqlConnection cn = new SqlConnection(cs);
            cn.Open();
            return cn;
        }

        public static Boolean ejecutar(String sql, List<SqlParameter> parametros)
        {

            SqlConnection cn = conexion();
            try
            {
                SqlCommand cm = new SqlCommand(sql, cn);
                foreach (SqlParameter item in parametros)
                {
                    cm.Parameters.Add(item);
                }
                cm.ExecuteNonQuery();
                cn.Close();
                return true;
            }
            catch (SqlException e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static DataTable consultar(String sql)
        {

            SqlConnection cn = conexion();
            DataTable dta = new DataTable();
            try
            {
                SqlCommand cm = new SqlCommand(sql, cn);
                dta.Load(cm.ExecuteReader());
                cn.Close();
            }
            catch (SqlException e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
            }
            return dta;
        }

        public static DataTable consultar(String sql, List<SqlParameter> parametros)
        {

            
            DataTable dt = new DataTable();
            SqlConnection cn = conexion();
            try
            {
                
                SqlCommand cm = new SqlCommand(sql, cn);
                foreach (SqlParameter item in parametros)
                {
                    cm.Parameters.Add(item);
                }
                dt.Load(cm.ExecuteReader());
                cn.Close();
            }
            catch (SqlException e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
            }
            return dt;
        }

        public static int ultimoId(String sql)
        {

            int id;
            SqlConnection cn = conexion();
            try
            {
                SqlCommand cm = new SqlCommand(sql, cn);
                id = Convert.ToInt32(cm.ExecuteScalar());
            }
            catch (Exception e)
            {
                cn.Close();
                id = 0;
                Console.WriteLine(e.Message);
            }
            return id;
        }

        public static int ultimoId(String sql, List<SqlParameter> param)
        {

            int id;
            SqlConnection cn = conexion();
            try
            {
                SqlCommand cm = new SqlCommand(sql, cn);
                foreach (SqlParameter item in param)
                {
                    cm.Parameters.Add(item);
                }
                id = Convert.ToInt32(cm.ExecuteScalar());
            }
            catch (Exception e)
            {
                cn.Close();
                id = 0;
                Console.WriteLine(e.Message);
            }
            return id;
        }


    }
}

