using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Pagos_ICB.Clases
{
    class Grado
    {
        public int IdGrado { set; get; }
        public string NombreGrado { set; get; }

       

        public int Estado { get; set; }
        //Se define un constructor
        public Grado() { }
        //Se define el destructor
        ~Grado() { }
        //Constructor para insertar un Grado
        public Grado(string nombreGrado)
        {
            NombreGrado = nombreGrado;
         

        }
        //Constructor para modificar un Grado
        public Grado(int idGrado, string nombreGrado)
        {
            IdGrado = idGrado;
            NombreGrado = nombreGrado;
         
        }
        //Constructor para eliminar un Grado
        public Grado(int idGrado)
        {
            IdGrado = idGrado;
        }

        public Grado(int idGrado, int estado)
        {
            IdGrado = idGrado;
            Estado = estado;
        }
        //Funcion para llamar el store Procedure y asignar los parametros que insertaremos
        public void Agregar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_AgregarGrado", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                //Se abre la conexion
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("nombreGrado", SqlDbType.NVarChar, 30));
                cmd.Parameters["nombreGrado"].Value = NombreGrado;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                //Cuando ocurre un error se llama la clase excepcion que dira que fue cerca de Gradoss donde ocurrio ese error
                throw new Clases.Excepcion(ex.Message, ex, "Clase_Grados");
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
            SqlCommand cmd = new SqlCommand("SP_ModificarGrado", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idGrado", SqlDbType.Int));
                cmd.Parameters["idGrado"].Value = IdGrado;
                cmd.Parameters.Add(new SqlParameter("nombreGrado", SqlDbType.NVarChar, 30));
                cmd.Parameters["nombreGrado"].Value = NombreGrado;
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
        //Funcion para llamar el store Procedure para eliminar un Grado deseado
        public void Eliminar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_EliminarGrado", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idGrado", SqlDbType.Int));
                cmd.Parameters["idGrado"].Value = IdGrado;
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
            SqlCommand cmd = new SqlCommand("SP_EliminarGrado1", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idGrado", SqlDbType.Int));
                cmd.Parameters["idGrado"].Value = IdGrado;
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
        //Funcion para Consultar los datos de un Grado determinado
        public void ObtenerGrados(int idGrado)
        {
            Conexión conexion = new Conexión();
            string sql = @"SELECT idGrado, nombreGrado FROM Cuentas.Grado WHERE idGrado = '" + idGrado + "';";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            try
            {
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IdGrado = dr.GetInt32(0);
                    NombreGrado = dr.GetString(1);
                }
            }
            catch (SqlException ex)
            {
                throw new Clases.Excepcion(
                   String.Format("{0} \n\n{1}",
                   "no podemos obtener la informacion del Grado", ex.Message), ex, "Clase_Grados"); ;
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
            //Se traen todos los datos de la tabla Gradoss y los almacena la variable sql
            string sql = @"SELECT   Cuentas.Grado.idGrado       as Código,
                                    Cuentas.Grado.nombreGrado   as NombreGrado
                            FROM Cuentas.Grado
                            WHERE estado=" + estado + ";";
            try
            {
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = new SqlCommand(sql, conexion.conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                data.Fill(ds, "Cuentas.Grado");
                DataTable dt = ds.Tables["Cuentas.Grado"];
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

        public void ObteneGradosPorNombres(string Nombres)
        {
            Conexión conexion = new Conexión();
            string sql = @"SELECT * FROM Cuentas.Grado WHERE nombreGrado = '" + Nombres + "';";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            try
            {
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IdGrado = dr.GetInt32(0);
                    NombreGrado = dr.GetString(1);
                }
            }
            catch (SqlException excepcion)
            {
                Exception ex = new Exception(
                   String.Format("{0} \n\n{1}",
                   "no podemos obtener la informacion del Grado", excepcion.Message));
                ex.Source = "Clase_Grado";
                throw ex;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
    }
}
