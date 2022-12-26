using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseGym
{
    public class Empleado 
    {
        public int id;
        string usuario;
        string password;
        string nombre;
        string apellido;
        int dni;

        public Empleado(int id,string nombre, string apellido, int dni,string usuario,string password)
        {
            this.id = 0;
            this.nombre = nombre;
            this.apellido = apellido;
            this.usuario = usuario;
            this.password = password;
        }

        public Empleado()
        {
            this.nombre = "";
            this.apellido = "";
            this.dni = 0;
            this.usuario = "";
            this.password = "";
        }

        public Empleado(int id, string nombre, string apellido, string usuario, string password)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.usuario = usuario;
            this.password = password;  
        }

        public string Usuario
        {
            get
            {
                return this.usuario;
            }
            set
            {
                this.usuario = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }

        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = value;
            }
        }

        public bool CheckearPassword(string password)
        {
            return password == this.password;
        }

        public override string ToString()
        {
            return this.usuario;
        }

    }
}
