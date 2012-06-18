using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class Pais
    {
        private int codigo;
        private string nombre;

        public Pais(int cod, string nom)
        {
            codigo = cod;
            nombre = nom;
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

    }
}
