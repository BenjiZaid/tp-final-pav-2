using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class Barrio
    {
        private int codigo;
        private string nombre;
        private Localidad localidad;

        public Barrio(int cod, string nom, Localidad loc)
        {
            codigo = cod;
            nombre = nom;
            localidad = loc;
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

        public Localidad Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }
    }

}

