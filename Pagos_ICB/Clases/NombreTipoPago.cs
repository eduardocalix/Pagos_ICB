using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Pagos_ICB.Clases
{
    class NombreTipoPago
    {
        //Se encapsulan las variables a usar
        
        public int IdNombreTipoPago { set; get; }
        public string NombreTipo { set; get; }
        public string FechaLimite { set; get; }
        public int Estado { get; set; }
        //Se define un constructor
        public NombreTipoPago() { }
        //Se define el destructor
        ~NombreTipoPago() { }
        //Constructor para insertar un NombreTipoPago
        public NombreTipoPago( string nombreTipo,string fechaLimite)
        {
            NombreTipo = nombreTipo;
            FechaLimite = fechaLimite;
        }
        //Constructor para modificar un NombreTipoPago
        public NombreTipoPago(int idNombreTipoPago, string nombreTipo, string fechaLimite)
        {           
            IdNombreTipoPago = idNombreTipoPago;
            NombreTipo = nombreTipo;
            FechaLimite = fechaLimite;
        }
        //Constructor para eliminar un TipoPago
        public NombreTipoPago(int idNombreTipoPago)
        {
            IdNombreTipoPago = idNombreTipoPago;
        }

        public NombreTipoPago(int idNombreTipoPago, int estado)
        {
            IdNombreTipoPago = idNombreTipoPago;
            Estado = estado;
        }
        //Funcion para llamar el store Procedure y asignar los parametros que insertaremos
        public void Agregar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_AgregarNombreTipoPago", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                //Se abre la conexion
                conexion.Abrir();                
                cmd.Parameters.Add(new SqlParameter("nombreTipoPago", SqlDbType.NVarChar,20));
                cmd.Parameters["nombreTipoPago"].Value =NombreTipo;
                cmd.Parameters.Add(new SqlParameter("fechaLimite", SqlDbType.NVarChar,15));
                cmd.Parameters["fechaLimite"].Value = FechaLimite;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                //Cuando ocurre un error se llama la clase excepcion que dira que fue cerca de NombreTipoPagoss donde ocurrio ese error
                throw new Clases.Excepcion(ex.Message, ex, "Clase_NombreTipoPago");
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
            SqlCommand cmd = new SqlCommand("SP_ModificarNombreTipoPago", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idNombreTipoPago", SqlDbType.Int));
                cmd.Parameters["idNombreTipoPago"].Value = IdNombreTipoPago;
                cmd.Parameters.Add(new SqlParameter("nombreTipoPago", SqlDbType.NVarChar, 20));
                cmd.Parameters["nombreTipoPago"].Value = NombreTipo;
                cmd.Parameters.Add(new SqlParameter("fechaLimite", SqlDbType.NVarChar, 15));
                cmd.Parameters["fechaLimite"].Value = FechaLimite;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                //Cuando ocurre un error se llama la clase excepcion que dira que fue cerca de NombreTipoPagoss donde ocurrio ese error
                throw new Clases.Excepcion(ex.Message, ex, "Clase_NombreTipoPago");
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        //Funcion para llamar el store Procedure para eliminar un NombreTipoPago deseado
        public void Eliminar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_EliminarNombreTipoPago", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idNombreTipoPago", SqlDbType.Int));
                cmd.Parameters["idNombreTipoPago"].Value = IdNombreTipoPago;
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
            SqlCommand cmd = new SqlCommand("SP_EliminarNombreTipoPago1", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idNombreTipoPago", SqlDbType.Int));
                cmd.Parameters["idNombreTipoPago"].Value = IdNombreTipoPago;
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
        //Funcion para Consultar los datos de un NombreTipoPago determinado
        public void ObtenerNombreTipoPagos(int idNombreTipoPago)
        {
            Conexión conexion = new Conexión();
            string sql = @"SELECT idNombreTipoPago, nombreTipoPago,fechaLimite FROM Cuentas.NombreTipoPago WHERE idNombreTipoPago = '" + idNombreTipoPago + "';";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            try
            {
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IdNombreTipoPago = dr.GetInt32(0);
                    NombreTipo = dr.GetString(1);
                    FechaLimite = dr.GetString(2);
                }
            }
            catch (SqlException ex)
            {
                throw new Clases.Excepcion(
                   String.Format("{0} \n\n{1}",
                   "no podemos obtener la informacion del NombreTipoPago", ex.Message), ex, "Clase_NombreTipoPago"); ;
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
            //Se traen todos los datos de la tabla NombreTipoPagoss y los almacena la variable sql
            string sql = @"SELECT   Cuentas.NombreTipoPago.idNombreTipoPago       as Código,
                                    Cuentas.NombreTipoPago.nombreTipoPago         as NombreTipoPago,
                                    Cuentas.NombreTipoPago.fechaLimite            as FechaLimite
                            FROM Cuentas.NombreTipoPago Where
                            Cuentas.NombreTipoPago.estado =" + estado + ";";
            try
            {
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = new SqlCommand(sql, conexion.conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                data.Fill(ds, "Cuentas.NombreTipoPago");
                DataTable dt = ds.Tables["Cuentas.NombreTipoPago"];
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

        public void ObteneNombreTipoPagosPorNombres(string Nombres)
        {
            Conexión conexion = new Conexión();
            string sql = @"SELECT * FROM Cuentas.NombreTipoPago WHERE nombreTipoPago = '" + Nombres + "';";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            try
            {
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IdNombreTipoPago = dr.GetInt32(0);
                    NombreTipo = dr.GetString(1);
                }
            }
            catch (SqlException excepcion)
            {
                Exception ex = new Exception(
                   String.Format("{0} \n\n{1}",
                   "no podemos obtener la informacion del NombreTipoPago", excepcion.Message));
                ex.Source = "Clase_NombreTipoPago";
                throw ex;
            }
            finally
            {
                conexion.Cerrar();
            }
        }


        
    }
}
