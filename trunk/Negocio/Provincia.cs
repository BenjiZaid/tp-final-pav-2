using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class Provincia
    {
        private int codigo;
        private string nombre;
        private Pais pais;

        public Provincia(int cod, string nom, Pais ps)
        {
            codigo = cod;
            nombre = nom;
            pais = ps;
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public Pais Pais
        {
            get { return pais; }
            set { pais = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

    }
}
