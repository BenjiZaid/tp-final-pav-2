using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class TipoDNI
    {
        private int codigo;
        private string descripcion;

        public TipoDNI(int cod, string desc)
        {
            codigo = cod;
            descripcion = desc;
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}

