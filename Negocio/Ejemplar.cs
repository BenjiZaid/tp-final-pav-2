using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class Ejemplar
    {
        private int nroEjemplar, codCD;
        private double precioVenta, precioCompra;
        private Boolean enStock;

        public Ejemplar(int ne, int cd, double pv, double pc)
        {
            nroEjemplar = ne;
            codCD = cd;
            precioCompra = pc;
            precioVenta = pv;
            enStock = true;
        }

        public Ejemplar(int ne, int cd, double pv)
        {
            nroEjemplar = ne;
            codCD = cd;
            precioVenta = pv;
        }

        public int NroEjemplar
        {
            get { return nroEjemplar; }
            set { nroEjemplar = value; }
        }

        public int CodCD
        {
            get { return codCD; }
            set { codCD = value; }
        }

        public double PrecioVenta
        {
            get { return precioVenta; }
            set { precioVenta = value; }
        }

        public double PrecioCompra
        {
            get { return precioCompra; }
            set { precioCompra = value; }
        }

        public int EnStock
        {
            get
            {
                if (enStock == true) return 1;
                else return 0;
            }
            set
            {
                if (value == 1) enStock = true;
                else enStock = false;
            }
        }
    }
}

