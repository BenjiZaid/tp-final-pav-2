using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Negocio
{
    public class Localidad
    {
        private int codigo;
        private string nombre;
        private Provincia provincia;

        public Localidad(int cod, string nom, Provincia prov)
        {
            codigo = cod;
            nombre = nom;
            provincia = prov;
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Provincia Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

    }
}
