using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class Genero
    {
        private int codigo;
        private string nombre;

        public Genero(int cod, string nom)
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
