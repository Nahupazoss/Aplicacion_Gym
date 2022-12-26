using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseGym
{
    public class Sistema
    {
        static List<Empleado> Empleado;
        static List<Cliente> Clientes;
        static AccesoDatosEmpleado baseDatosEmpleado;
        static AccesoDatosCliente baseDatosCliente;
        static Sistema()
        {
            baseDatosEmpleado = new AccesoDatosEmpleado();
            baseDatosCliente = new AccesoDatosCliente();
            Empleado = new List<Empleado>();
            Clientes = new List<Cliente>();
        }
    }
}
