using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClaseGym;

namespace ClaseGym
{
    public class AccesoDatosEmpleado
    {
        #region Atributos

        private static string cadena_conexion;
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        #endregion

        #region Constructores

        static AccesoDatosEmpleado()
        {
            AccesoDatosEmpleado.cadena_conexion = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=dtbase_generala;Data Source=DESKTOP-45ITKTF";
        }

        public AccesoDatosEmpleado()
        {
            // CREO UN OBJETO SQLCONECTION
            this.conexion = new SqlConnection(AccesoDatosEmpleado.cadena_conexion);
        }

        #endregion

        #region Métodos

        #region Probar conexión

        public bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                this.conexion.Open();
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        #endregion

        #region Select

        public List<Empleado> ObtenerListaDato()
        {
            List<Empleado> lista = new List<Empleado>();

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT * FROM dbo.historialPartidas";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();
                 
                while (lector.Read())
                {
                    Empleado item = new Empleado();

                    // ACCEDO POR NOMBRE, POR INDICE O POR GETTER (SEGUN TIPO DE DATO)
                    item.id = lector.GetInt32(0);
                    item.Nombre = lector["nombre"].ToString();
                    item.Apellido = lector["apellido"].ToString();
                    item.Usuario = lector["usuario"].ToString();
                    item.Password = lector["password"].ToString();
                    item.Dni = int.Parse(lector["dni"].ToString());

                    lista.Add(item);
                }

                lector.Close();

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return lista;
        }


        public List<Empleado> ObtenerEmpleado(string nombreJugador)
        {
            List<Empleado> lista = new List<Empleado>();
            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT * FROM dbo.historialPartidas WHERE jugador1 = @nombreJugador";
                this.comando.Connection = this.conexion;

                this.comando.Parameters.AddWithValue("@nombreJugador", nombreJugador);

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Empleado item = new Empleado();

                    // ACCEDO POR NOMBRE, POR INDICE O POR GETTER (SEGUN TIPO DE DATO)
                    item.id = lector.GetInt32(0);
                    item.Nombre = lector["nombre"].ToString();
                    item.Apellido = lector["apellido"].ToString();
                    item.Usuario = lector["usuario"].ToString();
                    item.Password = lector["password"].ToString();
                    item.Dni = int.Parse(lector["dni"].ToString());

                    lista.Add(item);
                }

                lector.Close();

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return lista;
        }
        #endregion

        #region Insert

        public bool AgregarDato(Empleado param)
        {
            bool rta = true;

            try
            {
                string sql = "INSERT INTO dbo.empleados (nombre, apellido, usuario, password, dni ) VALUES(";
                sql = sql + "'" + param.Nombre + "','" + param.Apellido + "'," + param.Usuario + "," + param.Password + ",'" +
                param.Dni.ToString() + "')";

                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        #endregion

        #endregion
    }
}
