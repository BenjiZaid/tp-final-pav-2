using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class Proveedor
    {
        int codigo;
        long telefono, telefonoContacto;
        string domicilio, mail, nombre, nombreContacto;

        public Proveedor() { }

        public Proveedor(int codigo, string nombre, string domicilio, long telefono, string mail, string nombreContacto, long telefonoContacto) 
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.domicilio = domicilio;
            this.telefono = telefono;
            this.mail = mail;
            this.nombreContacto = nombreContacto;
            this.telefonoContacto = telefonoContacto;
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

        public string Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
        }

        public long Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        public string NombreContacto
        {
            get { return nombreContacto; }
            set { nombreContacto = value; }
        }

        public long TelefonoContacto
        {
            get{ return telefonoContacto; }
            set { telefonoContacto = value; }
        }
    }
}
