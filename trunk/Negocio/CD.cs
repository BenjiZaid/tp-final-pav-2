using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class CD
    {
        private int codigo;
        private string nombre;
        private int añoEdicion;
        private Artista artista;
        private Genero genero;
        private List<Tema> temas;


        public CD(int cod, string nom, List<Tema> tem, Genero gen, Artista art, int fedi)
        {
            codigo = cod;
            nombre = nom;
            temas = tem;
            genero = gen;
            artista = art;
            añoEdicion = fedi;
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public List<Tema> Temas
        {
            get { return temas; }
            set { temas = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Genero Genero
        {
            get { return genero; }
            set { genero = value; }
        }

        public Artista Artista
        {
            get { return artista; }
            set { artista = value; }
        }

        public int AñoEdicion
        {
            get { return añoEdicion; }
            set { añoEdicion = value; }
        }

    }
}
