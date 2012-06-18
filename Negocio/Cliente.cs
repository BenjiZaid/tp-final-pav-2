using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class Cliente
    {
        private string usuario, password, apellido, nombre, domicilio, email, telefono, celular;
        private int nroDoc, provincia, localidad;
        private DateTime fechaNac;
        private TipoDNI tipoDNI;
        private Barrio barrio;
        private Sexo sexo;

        public Cliente(string usr, string pass, TipoDNI tdoc, int ndoc, string ap, string nom, DateTime fnac, string dom, Barrio bar, Sexo sx, string em, string tel, string cel)
        {
            usuario = usr;
            password = pass;
            tipoDNI = tdoc;
            nroDoc = ndoc;
            apellido = ap;
            nombre = nom;
            fechaNac = fnac;
            domicilio = dom;
            barrio = bar;
            sexo = sx;
            email = em;
            telefono = tel;
            celular = cel;
        }

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public TipoDNI TipoDNI
        {
            get { return tipoDNI; }
            set { tipoDNI = value; }
        }

        public int NroDoc
        {
            get { return nroDoc; }
            set { nroDoc = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public DateTime FechaNac
        {
            get { return fechaNac; }
            set { fechaNac = value; }
        }

        public string Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
        }

        public Barrio Barrio
        {
            get { return barrio; }
            set { barrio = value; }
        }

        public Sexo Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }

    }
}

