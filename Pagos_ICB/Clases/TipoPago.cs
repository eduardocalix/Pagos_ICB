using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Pagos_ICB.Clases
{
    class TipoPago
    {
        //Se encapsulan las variables a usar
        public int IdTipoPago { set; get; }
        public int IdNombreTipoPago { set; get; }
        public string NombreTipoPago { set; get; }
        public decimal Valor { set; get; }
        public int IdGrado { set; get; }
        public int Estado { get; set; }
        //Se define un constructor
        public TipoPago() { }
        //Se define el destructor
        ~TipoPago() { }
        //Constructor para insertar un TipoPago
        public TipoPago(int idNombreTipoPago, int idGrado, decimal valor)
        {
            IdNombreTipoPago = idNombreTipoPago;
            IdGrado = idGrado;
            Valor = valor;

        }
        //Constructor para modificar un TipoPago
        public TipoPago(int idTipoPago, int idNombreTipoPago, int idGrado, decimal valor)
        {
            IdTipoPago = idTipoPago;
            IdNombreTipoPago = idNombreTipoPago;
            IdGrado = idGrado;
            Valor = valor;
        }
        //Constructor para eliminar un TipoPago
        public TipoPago(int idTipoPago)
        {
            IdTipoPago = idTipoPago;
        }

        public TipoPago(int idTipoPago, int estado)
        {
            IdTipoPago = idTipoPago;
            Estado = estado;
        }
        //Funcion para llamar el store Procedure y asignar los parametros que insertaremos
        public void Agregar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_AgregarTipoPago", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                //Se abre la conexion
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idNombreTipoPago", SqlDbType.Int));
                cmd.Parameters["idNombreTipoPago"].Value = IdNombreTipoPago;
                cmd.Parameters.Add(new SqlParameter("idGrado", SqlDbType.Int));
                cmd.Parameters["idGrado"].Value = IdGrado;
                cmd.Parameters.Add(new SqlParameter("valor", SqlDbType.Decimal));
                cmd.Parameters["valor"].Value = Valor;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                //Cuando ocurre un error se llama la clase excepcion que dira que fue cerca de TipoPagoss donde ocurrio ese error
                throw new Clases.Excepcion(ex.Message, ex, "Clase_TipoPago");
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
            SqlCommand cmd = new SqlCommand("SP_ModificarTipoPago", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idTipoPago", SqlDbType.Int));
                cmd.Parameters["idTipoPago"].Value = IdTipoPago;
                cmd.Parameters.Add(new SqlParameter("idNombreTipoPago", SqlDbType.Int));
                cmd.Parameters["idNombreTipoPago"].Value = IdNombreTipoPago;
                cmd.Parameters.Add(new SqlParameter("idGrado", SqlDbType.Int));
                cmd.Parameters["idGrado"].Value = IdGrado;
                cmd.Parameters.Add(new SqlParameter("valor", SqlDbType.Decimal));
                cmd.Parameters["valor"].Value = Valor;
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
        //Funcion para llamar el store Procedure para eliminar un TipoPago deseado
        public void Eliminar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_EliminarTipoPago", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idTipoPago", SqlDbType.Int));
                cmd.Parameters["idTipoPago"].Value = IdTipoPago;
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
            SqlCommand cmd = new SqlCommand("SP_EliminarTipoPago1", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idTipoPago", SqlDbType.Int));
                cmd.Parameters["idTipoPago"].Value = IdTipoPago;
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
        //Funcion para Consultar los datos de un TipoPago determinado
        public void ObtenerTipoPagos(int idTipoPago)
        {
            Conexión conexion = new Conexión();
            string sql = @"SELECT idTipoPago, idNombreTipoPago,idGrado,Valor FROM Cuentas.TipoPago WHERE idTipoPago = '" + idTipoPago + "';";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            try
            {
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IdTipoPago = dr.GetInt32(0);
                    IdNombreTipoPago = dr.GetInt32(1);
                    IdGrado = dr.GetInt32(2);
                    Valor = dr.GetDecimal(3);
                }
            }
            catch (SqlException ex)
            {
                throw new Clases.Excepcion(
                   String.Format("{0} \n\n{1}",
                   "no podemos obtener la informacion del TipoPago", ex.Message), ex, "Clase_TipoPago"); ;
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
            //Se traen todos los datos de la tabla TipoPagoss y los almacena la variable sql
            string sql = @"SELECT   Cuentas.TipoPago.idTipoPago        as Código,
                                    Cuentas.TipoPago.idNombreTipoPago    as NombreTipoPago,
                                    Cuentas.TipoPago.idGrado           as Grado, 
                                    Cuentas.TipoPago.valor             as Valor
                            FROM Cuentas.TipoPago
                            WHERE estado=" + estado + ";";
            try
            {
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = new SqlCommand(sql, conexion.conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                data.Fill(ds, "Cuentas.TipoPago");
                DataTable dt = ds.Tables["Cuentas.TipoPago"];
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

        public void ObteneTipoPagosPorNombres(string Nombres)
        {
            Conexión conexion = new Conexión();
            string sql = @"SELECT * FROM Cuentas.TipoPago WHERE nombreTipoPago = '" + Nombres + "';";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            try
            {
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IdTipoPago = dr.GetInt32(0);
                    IdNombreTipoPago = dr.GetInt32(1);
                }
            }
            catch (SqlException excepcion)
            {
                Exception ex = new Exception(
                   String.Format("{0} \n\n{1}",
                   "no podemos obtener la informacion del TipoPago", excepcion.Message));
                ex.Source = "Clase_TipoPago";
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
                    IdTipoPago = dr.GetInt32(0);
                    NombreTipoPago = dr.GetString(1);
                }
            }
            catch (SqlException excepcion)
            {
                Exception ex = new Exception(
                   String.Format("{0} \n\n{1}",
                   "no podemos obtener la informacion del TipoPago", excepcion.Message));
                ex.Source = "Clase_TipoPago";
                throw ex;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
    }
}
