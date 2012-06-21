using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class Artista
    {
        private int codigo;
        private string nombre, apellido;
        private DateTime fechaNacimiento;
        private Sexo sexo;
        private Pais pais;

        public Artista() { }

        public Artista(int cod, string nom, string ap, DateTime fecNac, Sexo sx, Pais p)
        {
            this.codigo = cod;
            this.nombre = nom;
            this.apellido = ap;
            this.fechaNacimiento = fecNac;
            this.sexo = sx;
            this.pais = p;
        }

        public Artista(int cod, string nom, DateTime fechaN, Pais p)
        {
            this.codigo = cod;
            this.nombre = nom;
            this.fechaNacimiento = fechaN;
            this.pais = p;
        }

        public int Codigo
        {
            get { return codigo; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public Sexo Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public Pais Pais
        {
            get { return pais; }
            set { pais = value; }
        }

    }
}

