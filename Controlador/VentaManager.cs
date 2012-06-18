using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negocio;

namespace Controlador
{
    class VentaManager
    {
        public static Boolean ventaCD(Negocio.Venta v)
        {
            Boolean b = false;
            int id = DAO.AccesoDatos.ultimoId("Venta") + 1;
            v.CodVenta = id;
            b = DAO.Transaccion.venderCD(v);
            return b;
        }

        public static Boolean agregarEjemplar(Negocio.Venta v, Negocio.Ejemplar e)
        {
            try
            {
                v.Carrito.Add(e);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}

