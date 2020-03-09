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
        public int IdAlumno { set; get; }
        public string Identidad { set; get; }
        public string Nombres { set; get; }
        public string Apellidos { set; get; }

        public string Beca { set; get; }
        public int IdGrado { set; get; }
        public int Estado { get; set; }
        //Se define un constructor
        public Alumnos() { }
        //Se define el destructor
        ~Alumnos() { }
        //Constructor para insertar un Alumnos
        public Alumnos(string identidad, string nombres, string apellidos,int idGrado, string beca)
        {
            Identidad = identidad;
            Nombres = nombres;
            Apellidos = apellidos;
            IdGrado = idGrado;
            Beca = beca;

        }
        //Constructor para modificar un Alumnos
        public Alumnos(int idAlumno, string identidad, string nombres, string apellidos,int idGrado, string beca)
        {
            IdAlumno = idAlumno;
            Identidad = identidad;
            Nombres = nombres;
            Apellidos = apellidos;
            IdGrado = idGrado;
            Beca = beca;
        }
        //Constructor para eliminar un Alumnos
        public Alumnos(int idAlumno)
        {
            IdAlumno = idAlumno;
        }

        public Alumnos(int idAlumno, int estado)
        {
            IdAlumno = idAlumno;
            Estado = estado;
        }
        //Funcion para llamar el store Procedure y asignar los parametros que insertaremos
        public void Agregar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_AgregarAlumno", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                //Se abre la conexion
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("identidad", SqlDbType.NVarChar, 15));
                cmd.Parameters["identidad"].Value = Identidad;
                cmd.Parameters.Add(new SqlParameter("nombres", SqlDbType.NVarChar, 25));
                cmd.Parameters["nombres"].Value = Nombres;
                cmd.Parameters.Add(new SqlParameter("apellidos", SqlDbType.NVarChar, 25));
                cmd.Parameters["apellidos"].Value = Apellidos;
                cmd.Parameters.Add(new SqlParameter("idGrado", SqlDbType.Int));
                cmd.Parameters["idGrado"].Value = IdGrado;
                cmd.Parameters.Add(new SqlParameter("beca", SqlDbType.NVarChar,3));
                cmd.Parameters["beca"].Value = Beca;
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
            SqlCommand cmd = new SqlCommand("SP_ModificarAlumno", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idAlumno", SqlDbType.Int));
                cmd.Parameters["idAlumno"].Value = IdAlumno;
                cmd.Parameters.Add(new SqlParameter("identidad", SqlDbType.NVarChar, 15));
                cmd.Parameters["identidad"].Value = Identidad;
                cmd.Parameters.Add(new SqlParameter("nombres", SqlDbType.NVarChar, 25));
                cmd.Parameters["nombres"].Value = Nombres;
                cmd.Parameters.Add(new SqlParameter("apellidos", SqlDbType.NVarChar, 25));
                cmd.Parameters["apellidos"].Value = Apellidos;
                cmd.Parameters.Add(new SqlParameter("idGrado", SqlDbType.Int));
                cmd.Parameters["idGrado"].Value = IdGrado;
                cmd.Parameters.Add(new SqlParameter("beca", SqlDbType.NVarChar, 3));
                cmd.Parameters["beca"].Value = Beca;
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
            SqlCommand cmd = new SqlCommand("SP_EliminarAlumno", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idAlumno", SqlDbType.Int));
                cmd.Parameters["idAlumno"].Value = IdAlumno;
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
                cmd.Parameters.Add(new SqlParameter("idAlumno", SqlDbType.Int));
                cmd.Parameters["idAlumno"].Value = IdAlumno;
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
            string sql = @"SELECT idAlumno, identidad, nombres, apellidos, idGrado,beca FROM Cuentas.Alumno WHERE idAlumno = '" + id + "';";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            try
            {
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IdAlumno = dr.GetInt32(0);
                    Identidad = dr.GetString(1);
                    Nombres = dr.GetString(2);
                    Apellidos = dr.GetString(3);
                    IdGrado = dr.GetInt32(4);
                    Beca = dr.GetString(5);
                    
                }
            }
            catch (SqlException ex)
            {
                throw new Clases.Excepcion(
                   String.Format("{0} \n\n{1}",
                   "no podemos obtener la informacion del Alumnos", ex.Message), ex, "Clase_Alumno"); ;
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
            string sql = @"SELECT   Cuentas.Alumno.idAlumno    as Código,
                                    Cuentas.Alumno.identidad   as Identidad,
                                    Cuentas.Alumno.Nombres      as Alumnos, 
                                    Cuentas.Alumno.Apellidos    as Apellidos,
                                    Cuentas.Grado.nombreGrado   as Grado,
                                    Cuentas.Alumno.beca         as Beca
                            FROM Cuentas.Alumno INNER JOIN Cuentas.Grado 
							ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado AND
                             Cuentas.Alumno.estado=" + estado + ";";
            try
            {
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = new SqlCommand(sql, conexion.conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                data.Fill(ds, "Cuentas.Alumno");
                DataTable dt = ds.Tables["Cuentas.Alumno"];
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
            string sql = @"SELECT * FROM Cuentas.Alumno WHERE Nombres = '" + Nombres + "';";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            try
            {
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IdAlumno = dr.GetInt32(0);
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
