using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Pagos_ICB.Clases
{
    class Alumnos
    {
        //Se encapsulan las variables a usar
        public int Id { set; get; }
        public string Identidad { set; get; }
        public string Nombres { set; get; }
        public string Apellidos { set; get; }

        public int Beca { set; get; }
        public int IdGrado { set; get; }
        public int Estado { get; set; }
        //Se define un constructor
        public Alumnos() { }
        //Se define el destructor
        ~Alumnos() { }
        //Constructor para insertar un Alumnos
        public Alumnos(string identidad, string nombres, string apellidos,int idGrado, int beca)
        {
            Identidad = identidad;
            Nombres = nombres;
            Apellidos = apellidos;
            IdGrado = idGrado;
            Beca = beca;

        }
        //Constructor para modificar un Alumnos
        public Alumnos(int id, string identidad, string nombres, string apellidos,int idGrado, int beca)
        {
            Id = id;
            Identidad = identidad;
            Nombres = nombres;
            Apellidos = apellidos;
            IdGrado = idGrado;
            Beca = beca;
        }
        //Constructor para eliminar un Alumnos
        public Alumnos(int id)
        {
            Id = id;
        }

        public Alumnos(int id, int estado)
        {
            Id = id;
            Estado = estado;
        }
        //Funcion para llamar el store Procedure y asignar los parametros que insertaremos
        public void Agregar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_AgregarAlumnos", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                //Se abre la conexion
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("identidad", SqlDbType.NVarChar, 15));
                cmd.Parameters["identidad"].Value = Identidad;
                cmd.Parameters.Add(new SqlParameter("Nombres", SqlDbType.NVarChar, 25));
                cmd.Parameters["Nombres"].Value = Nombres;
                cmd.Parameters.Add(new SqlParameter("Apellidos", SqlDbType.NVarChar, 25));
                cmd.Parameters["Apellidos"].Value = Apellidos;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                //Cuando ocurre un error se llama la clase excepcion que dira que fue cerca de Alumnoss donde ocurrio ese error
                throw new Clases.Excepcion(ex.Message, ex, "Clase_Alumnos");
            }
            finally
            {
                //Se cierra la conexion
                conexion.Cerrar();
            }
        }
        //Funcion para llamar el store Procedure y asignar los parametros que desean modificar
        public void Modificar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_ModificarAlumnos", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("id", SqlDbType.Int));
                cmd.Parameters["id"].Value = Id;
                cmd.Parameters.Add(new SqlParameter("identidad", SqlDbType.NVarChar, 15));
                cmd.Parameters["identidad"].Value = Identidad;
                cmd.Parameters.Add(new SqlParameter("Nombres", SqlDbType.NVarChar, 25));
                cmd.Parameters["Nombres"].Value = Nombres;
                cmd.Parameters.Add(new SqlParameter("Apellidos", SqlDbType.NVarChar, 25));
                cmd.Parameters["Apellidos"].Value = Apellidos;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        //Funcion para llamar el store Procedure para eliminar un Alumnos deseado
        public void Eliminar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_EliminarAlumnos", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("id", SqlDbType.Int));
                cmd.Parameters["id"].Value = Id;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Cerrar();
            }
        }

        public void Eliminar1()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_EliminarAlumnos1", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("id", SqlDbType.Int));
                cmd.Parameters["id"].Value = Id;
                cmd.Parameters.Add(new SqlParameter("estado", SqlDbType.Int));
                cmd.Parameters["estado"].Value = Estado;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        //Funcion para Consultar los datos de un Alumnos determinado
        public void ObtenerAlumnos(int id)
        {
            Conexión conexion = new Conexión();
            string sql = @"SELECT id, identidad, Nombres, Apellidos FROM Restaurante.Alumnoss WHERE id = '" + id + "';";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            try
            {
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Id = dr.GetInt32(0);
                    Identidad = dr.GetString(1);
                    Nombres = dr.GetString(2);
                    Apellidos = dr.GetString(3);
                }
            }
            catch (SqlException ex)
            {
                throw new Clases.Excepcion(
                   String.Format("{0} \n\n{1}",
                   "no podemos obtener la informacion del Alumnos", ex.Message), ex, "Clase_Alumnoss"); ;
            }
            finally
            {
                conexion.Cerrar();
            }

        }
        //Se aplican las funciones de ADO.NET donde usamos un dataAdapter
        public static DataView GetDataView(int estado)
        {
            Clases.Conexión conexion = new Clases.Conexión();
            //Se traen todos los datos de la tabla Alumnoss y los almacena la variable sql
            string sql = @"SELECT   Restaurante.Alumnoss.id          as Código,
                                    Restaurante.Alumnoss.identidad   as Identidad,
                                    Restaurante.Alumnoss.Nombres      as Alumnos, 
                                    Restaurante.Alumnoss.Apellidos    as Apellidos
                            FROM Restaurante.Alumnoss
                            WHERE estado=" + estado + ";";
            try
            {
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = new SqlCommand(sql, conexion.conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                data.Fill(ds, "Restaurante.Alumnoss");
                DataTable dt = ds.Tables["Restaurante.Alumnoss"];
                DataView dv = new DataView(dt,
                    "",
                    "Código",
                    DataViewRowState.Unchanged);
                return dv;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Cerrar();
            }

        }

        public void ObteneAlumnosPorNombres(string Nombres)
        {
            Conexión conexion = new Conexión();
            string sql = @"SELECT * FROM Restaurante.Alumnoss WHERE Nombres = '" + Nombres + "';";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            try
            {
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Id = dr.GetInt32(0);
                    Nombres = dr.GetString(2);
                }
            }
            catch (SqlException excepcion)
            {
                Exception ex = new Exception(
                   String.Format("{0} \n\n{1}",
                   "no podemos obtener la informacion del Alumnos", excepcion.Message));
                ex.Source = "Clase_Alumnos";
                throw ex;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
    }
}
