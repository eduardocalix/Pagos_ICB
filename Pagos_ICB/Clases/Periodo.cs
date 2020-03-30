using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Pagos_ICB.Clases
{
    class Periodo
    {
        public int IdPeriodo { set; get; }
        public string NombrePeriodo { set; get; }

       

        public int Estado { get; set; }
        //Se define un constructor
        public Periodo() { }
        //Se define el destructor
        ~Periodo() { }
        //Constructor para insertar un Periodo
        public Periodo(string nombrePeriodo)
        {
            NombrePeriodo = nombrePeriodo;
         

        }
        //Constructor para modificar un Periodo
        public Periodo(int idPeriodo, string nombrePeriodo)
        {
            IdPeriodo = idPeriodo;
            NombrePeriodo = nombrePeriodo;
         
        }
        //Constructor para eliminar un Periodo
        public Periodo(int idPeriodo)
        {
            IdPeriodo = idPeriodo;
        }

        public Periodo(int idPeriodo, int estado)
        {
            IdPeriodo = idPeriodo;
            Estado = estado;
        }
        //Funcion para llamar el store Procedure y asignar los parametros que insertaremos
        public void Agregar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_AgregarPeriodo", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                //Se abre la conexion
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("nombrePeriodo", SqlDbType.NVarChar, 30));
                cmd.Parameters["nombrePeriodo"].Value = NombrePeriodo;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                //Cuando ocurre un error se llama la clase excepcion que dira que fue cerca de Periodoss donde ocurrio ese error
                throw new Clases.Excepcion(ex.Message, ex, "Clase_Periodo");
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
            SqlCommand cmd = new SqlCommand("SP_ModificarPeriodo", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idPeriodo", SqlDbType.Int));
                cmd.Parameters["idPeriodo"].Value = IdPeriodo;
                cmd.Parameters.Add(new SqlParameter("nombrePeriodo", SqlDbType.NVarChar, 30));
                cmd.Parameters["nombrePeriodo"].Value = NombrePeriodo;
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
        //Funcion para llamar el store Procedure para eliminar un Periodo deseado
        public void Eliminar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_EliminarPeriodo", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idPeriodo", SqlDbType.Int));
                cmd.Parameters["idPeriodo"].Value = IdPeriodo;
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
            SqlCommand cmd = new SqlCommand("SP_EliminarPeriodo1", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idPeriodo", SqlDbType.Int));
                cmd.Parameters["idPeriodo"].Value = IdPeriodo;
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
        //Funcion para Consultar los datos de un Periodo determinado
        public void ObtenerPeriodos(int idPeriodo)
        {
            Conexión conexion = new Conexión();
            string sql = @"SELECT idPeriodo, nombrePeriodo FROM Cuentas.Periodo WHERE idPeriodo = '" + idPeriodo + "';";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            try
            {
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IdPeriodo = dr.GetInt32(0);
                    NombrePeriodo = dr.GetString(1);
                }
            }
            catch (SqlException ex)
            {
                throw new Clases.Excepcion(
                   String.Format("{0} \n\n{1}",
                   "no podemos obtener la informacion del Periodo", ex.Message), ex, "Clase_Periodos"); ;
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
            //Se traen todos los datos de la tabla Periodoss y los almacena la variable sql
            string sql = @"SELECT   Cuentas.Periodo.idPeriodo       as Código,
                                    Cuentas.Periodo.nombrePeriodo   as NombrePeriodo
                            FROM Cuentas.Periodo
                            WHERE estado=" + estado + ";";
            try
            {
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = new SqlCommand(sql, conexion.conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                data.Fill(ds, "Cuentas.Periodo");
                DataTable dt = ds.Tables["Cuentas.Periodo"];
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

        public void ObtenerPeriodosPorNombres(string Nombres)
        {
            Conexión conexion = new Conexión();
            string sql = @"SELECT * FROM Cuentas.Periodo WHERE nombrePeriodo = '" + Nombres + "';";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            try
            {
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IdPeriodo = dr.GetInt32(0);
                    NombrePeriodo = dr.GetString(1);
                }
            }
            catch (SqlException excepcion)
            {
                Exception ex = new Exception(
                   String.Format("{0} \n\n{1}",
                   "no podemos obtener la informacion del Periodo", excepcion.Message));
                ex.Source = "Clase_Periodo";
                throw ex;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
    }
}
