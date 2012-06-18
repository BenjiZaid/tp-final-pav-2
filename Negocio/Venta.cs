using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class Venta
    {
        private int codVenta;
        private Cliente cliente;
        private DateTime fecha;
        private List<Ejemplar> carrito;

        public Venta(int codv, Cliente cli, DateTime fec, List<Ejemplar> car)
        {
            codVenta = codv;
            cliente = cli;
            fecha = fec;
            carrito = car;
        }

        public int CodVenta
        {
            get { return codVenta; }
            set { codVenta = value; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public List<Ejemplar> Carrito
        {
            get { return carrito; }
            set { carrito = value; }
        }
    }
}

