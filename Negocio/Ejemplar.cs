using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class Ejemplar
    {
        private int nroEjemplar, codCD;
        private float precioVenta, precioCompra;
        private Boolean enStock;

        public Ejemplar(int ne, int cd, float pv, float pc)
        {
            nroEjemplar = ne;
            codCD = cd;
            precioCompra = pc;
            precioVenta = pv;
            enStock = true;
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

        public float PrecioVenta
        {
            get { return precioVenta; }
            set { precioVenta = value; }
        }

        public float PrecioCompra
        {
            get { return precioCompra; }
            set { precioCompra = value; }
        }

        public Boolean EnStock
        {
            get { return enStock; }
            set { enStock = value; }
        }
    }
}

