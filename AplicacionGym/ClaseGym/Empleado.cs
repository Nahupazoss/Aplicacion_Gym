using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseGym
{
    public class Empleado : Persona
    {
        string usuario;
        string password;

        public Empleado(string nombre, string apellido, int dni,string usuario,string password) : base(nombre, apellido, dni)
        {
            this.usuario = usuario;
            this.password = password;
        }
    }
}
