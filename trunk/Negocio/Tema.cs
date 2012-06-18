using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class Tema
    {
        private int codigoCD, numeroPista;
        private string nombre;
        private DateTime duracion;

        public Tema() { }

        public Tema(int ccd, int np, string nom, DateTime dur)
        {
            codigoCD = ccd;
            numeroPista = np;
            nombre = nom;
            duracion = dur;
        }

        public int CodigoCD
        {
            get { return codigoCD; }
            set { codigoCD = value; }
        }

        public int NumeroPista
        {
            get { return numeroPista; }
            set { numeroPista = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public DateTime Duracion
        {
            get { return duracion; }
            set { duracion = value; }
        }
    }
}
