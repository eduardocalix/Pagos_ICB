using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Pagos_ICB.Clases
{
    class Pago
    {
        private int idUsuario = Clases.VariablesGlobales.idUsu;
        public int IdPago{ set; get; }
        public string Recibo { set; get; }
        public int IdAlumno{ set; get; }
        public int IdTipo{ set; get; }
        public int IdDescuento{ set; get; }
        public int IdMora{ set; get; }
        public int IdUsuario{ set; get; }
        public string FechaPago{ set; get; }
        public decimal Total { set; get; }
        public string Observacion { set; get; }
        public int Estado { get; set; }
        //Se define un constructor
        public Pago() { }
        //Se define el destructor
        ~Pago() { }
        //Constructor para insertar un TipoPago
        public Pago( string recibo, int idAlumno, int idTipo, int idDescuento,int idMora,int idUsuario,decimal total,string fechaPago,string observacion)
        {
            Recibo = recibo;
            IdAlumno = idAlumno;
            IdTipo = idTipo;
            IdDescuento = idDescuento;
            IdMora = idMora;
            IdUsuario = idUsuario;
            Total = total;
            FechaPago = fechaPago;
            Observacion = observacion;
        }
        //Constructor para modificar un TipoPago
        public Pago(int idPago, string recibo, int idAlumno, int idTipo, int idDescuento, int idMora,  int idUsuario, decimal total,string fechaPago,      string observacion)
        {
            IdPago= idPago;
            Recibo = recibo;
            IdAlumno = idAlumno;
            IdTipo = idTipo;
            IdDescuento = idDescuento;
            IdMora = idMora;
            IdUsuario = idUsuario;
            Total = total;
            FechaPago = fechaPago;
            Observacion = observacion;
        }
        //Constructor para eliminar un TipoPago
        public Pago(int idPago)
        {
            IdPago= idPago;
        }

        public Pago(int idPago, int estado)
        {
            IdPago= idPago;
            Estado = estado;
        }
        //Funcion para llamar el store Procedure y asignar los parametros que insertaremos
        public void Agregar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_AgregarPago", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                //Se abre la conexion
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("recibo", SqlDbType.NVarChar,15));
                cmd.Parameters["recibo"].Value = Recibo;
                cmd.Parameters.Add(new SqlParameter("idAlumno", SqlDbType.Int));
                cmd.Parameters["idAlumno"].Value = IdAlumno;
                cmd.Parameters.Add(new SqlParameter("idTipo", SqlDbType.Int));
                cmd.Parameters["idTipo"].Value = IdTipo;
                cmd.Parameters.Add(new SqlParameter("idDescuento", SqlDbType.Int));
                cmd.Parameters["idDescuento"].Value = IdDescuento;
                cmd.Parameters.Add(new SqlParameter("idMora", SqlDbType.Int));
                cmd.Parameters["idMora"].Value = IdMora;
                cmd.Parameters.Add(new SqlParameter("idUsuario", SqlDbType.Int));
                cmd.Parameters["idUsuario"].Value = IdUsuario;
                cmd.Parameters.Add(new SqlParameter("total", SqlDbType.Decimal));
                cmd.Parameters["total"].Value = Total;
                cmd.Parameters.Add(new SqlParameter("fechaPago", SqlDbType.NVarChar, 15));
                cmd.Parameters["fechaPago"].Value = FechaPago;
                cmd.Parameters.Add(new SqlParameter("observacion", SqlDbType.NVarChar, 100));
                cmd.Parameters["observacion"].Value = Observacion;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                //Cuando ocurre un error se llama la clase excepcion que dira que fue cerca de TipoPagoss donde ocurrio ese error
                throw new Clases.Excepcion(ex.Message, ex, "Clase_Pago");
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
            SqlCommand cmd = new SqlCommand("SP_ModificarPago", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idPago", SqlDbType.Int));
                cmd.Parameters["idPago"].Value = IdPago;
                cmd.Parameters.Add(new SqlParameter("recibo", SqlDbType.NVarChar, 15));
                cmd.Parameters["recibo"].Value = Recibo;
                cmd.Parameters.Add(new SqlParameter("idAlumno", SqlDbType.Int));
                cmd.Parameters["idAlumno"].Value = IdAlumno;
                cmd.Parameters.Add(new SqlParameter("idTipo", SqlDbType.Int));
                cmd.Parameters["idTipo"].Value = IdTipo;
                cmd.Parameters.Add(new SqlParameter("idDescuento", SqlDbType.Int));
                cmd.Parameters["idDescuento"].Value = IdDescuento;
                cmd.Parameters.Add(new SqlParameter("idMora", SqlDbType.Int));
                cmd.Parameters["idMora"].Value = IdMora;
                cmd.Parameters.Add(new SqlParameter("idUsuario", SqlDbType.Int));
                cmd.Parameters["idUsuario"].Value = IdUsuario;
                cmd.Parameters.Add(new SqlParameter("total", SqlDbType.Decimal));
                cmd.Parameters["total"].Value = Total;
                cmd.Parameters.Add(new SqlParameter("fechaPago", SqlDbType.NVarChar, 15));
                cmd.Parameters["fechaPago"].Value = FechaPago;
                cmd.Parameters.Add(new SqlParameter("observacion", SqlDbType.NVarChar, 100));
                cmd.Parameters["observacion"].Value = Observacion;
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
        //Funcion para llamar el store Procedure para eliminar un Pagodeseado
        public void Eliminar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_EliminarPago", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idPago", SqlDbType.Int));
                cmd.Parameters["idPago"].Value = IdPago;
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
            SqlCommand cmd = new SqlCommand("SP_EliminarPago1", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idPago", SqlDbType.Int));
                cmd.Parameters["idPago"].Value = IdPago;
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
        //Funcion para Consultar los datos de un Pago determinado
        public void ObtenerPagos(int idPago)
        {
            Conexión conexion = new Conexión();
            string sql = @"SELECT * FROM Cuentas.Pago WHERE idPago= '" + idPago+ "';";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            try
            {
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IdPago= dr.GetInt32(0);
                    Recibo = dr.GetString(1);
                    IdAlumno= dr.GetInt32(2);
                    IdTipo= dr.GetInt32(3);
                    IdDescuento= dr.GetInt32(4);
                    IdMora = dr.GetInt32(5);
                    IdUsuario = dr.GetInt32(6);
                    Total = dr.GetDecimal(7);
                    FechaPago = dr.GetString(8);
                    Observacion = dr.GetString(9);

                }
            }
            catch (SqlException ex)
            {
                throw new Clases.Excepcion(
                   String.Format("{0} \n\n{1}",
                   "no podemos obtener la informacion del Pago", ex.Message), ex, "Clase_Pago"); ;
            }
            finally
            {
                conexion.Cerrar();
            }
        }

        //Pago para la papelera
        public void ObtenerPagos1(int idPago)
        {
            Conexión conexion = new Conexión();
            string sql = @"SELECT   Cuentas.Pago.idPago         as Código,
                                    Cuentas.Grado.nombreGrado   as Grado,
                                    Cuentas.Alumno.nombres      as Nombres, 
                                    Cuentas.Alumno.apellidos    as Apellidos,
                                    Cuentas.Pago.recibo         as Recibo,
                                    Cuentas.NombreTipoPago.nombreTipoPago   as Pago,
                                    Cuentas.Mora.nombreMora     as Mora,
                                    Cuentas.Pago.total          as Total,
                                    Cuentas.Pago.observacion    as Observación
                            FROM Cuentas.Pago  INNER JOIN  Cuentas.Alumno ON 
                            Cuentas.Pago.idAlumno = Cuentas.Alumno.idAlumno INNER JOIN Cuentas.Grado 
							ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN Cuentas.Mora ON
                            Cuentas.Pago.idMora = Cuentas.Mora.idMora INNER JOIN Cuentas.TipoPago 
							ON Cuentas.Pago.idTipo = Cuentas.TipoPago.idTipoPago
                            INNER JOIN Cuentas.NombreTipoPago 
							ON Cuentas.TipoPago.idNombreTipoPago = Cuentas.NombreTipoPago.idNombreTipoPago AND Cuentas.Pago.idPago= '" + idPago + "';";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            try
            {
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IdPago = dr.GetInt32(0);
                    Recibo = dr.GetString(1);
                    IdAlumno = dr.GetInt32(2);
                    IdTipo = dr.GetInt32(3);
                    IdDescuento = dr.GetInt32(4);
                    IdMora = dr.GetInt32(5);
                    IdUsuario = dr.GetInt32(6);
                    Total = dr.GetDecimal(7);
                    FechaPago = dr.GetString(8);
                    Observacion = dr.GetString(9);

                }
            }
            catch (SqlException ex)
            {
                throw new Clases.Excepcion(
                   String.Format("{0} \n\n{1}",
                   "no podemos obtener la informacion del Pago", ex.Message), ex, "Clase_Pago"); ;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        //Filtro de pago por alumno

        public static DataView GetDataViewFiltroPago1( int idAlumno,int estado)
        {
            Clases.Conexión conexion = new Clases.Conexión();
            string sql = @"SELECT   Cuentas.Pago.idPago         as Código,
                                    Cuentas.Grado.nombreGrado   as Grado,
                                    Cuentas.Alumno.nombres      as Nombres, 
                                    Cuentas.Alumno.apellidos    as Apellidos,
                                    Cuentas.Pago.recibo         as Recibo,
                                    Cuentas.NombreTipoPago.nombreTipoPago   as Pago,
                                    Cuentas.Mora.nombreMora     as Mora,
                                    CONCAT('L. ',Cuentas.Pago.total)   as Total,
                                    Cuentas.Pago.observacion    as Observación
                            FROM Cuentas.Pago  INNER JOIN  Cuentas.Alumno ON 
                            Cuentas.Pago.idAlumno = Cuentas.Alumno.idAlumno INNER JOIN Cuentas.Grado 
							ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN Cuentas.Mora ON
                            Cuentas.Pago.idMora = Cuentas.Mora.idMora INNER JOIN Cuentas.TipoPago 
							ON Cuentas.Pago.idTipo = Cuentas.TipoPago.idTipoPago
                            INNER JOIN Cuentas.NombreTipoPago 
							ON Cuentas.TipoPago.idNombreTipoPago = Cuentas.NombreTipoPago.idNombreTipoPago AND
                            Cuentas.Pago.estado=" + estado + " AND Cuentas.Pago.idAlumno =" + idAlumno + " ORDER BY Cuentas.Pago.idPago DESC;";
            try
            {
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = new SqlCommand(sql, conexion.conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                data.Fill(ds, "Cuentas.Pago");
                DataTable dt = ds.Tables["Cuentas.Pago"];
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


        //Filtro de pago por alumno

        public static DataView GetDataViewFiltroPago(int estado)
        {
            Clases.Conexión conexion = new Clases.Conexión();
            string sql = @"SELECT   Cuentas.Pago.idPago         as Código,
                                    Cuentas.Grado.nombreGrado   as Grado,
                                    Cuentas.Alumno.nombres      as Nombres, 
                                    Cuentas.Alumno.apellidos    as Apellidos,
                                    Cuentas.Pago.recibo         as Recibo,
                                    Cuentas.NombreTipoPago.nombreTipoPago   as Pago,
                                    Cuentas.Mora.nombreMora     as Mora,
                                    Cuentas.Pago.total          as Total,
                                    Cuentas.Pago.observacion    as Observación
                            FROM Cuentas.Pago  INNER JOIN  Cuentas.Alumno ON 
                            Cuentas.Pago.idAlumno = Cuentas.Alumno.idAlumno INNER JOIN Cuentas.Grado 
							ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN Cuentas.Mora ON
                            Cuentas.Pago.idMora = Cuentas.Mora.idMora INNER JOIN Cuentas.TipoPago 
							ON Cuentas.Pago.idTipo = Cuentas.TipoPago.idTipoPago
                            INNER JOIN Cuentas.NombreTipoPago 
							ON Cuentas.TipoPago.idNombreTipoPago = Cuentas.NombreTipoPago.idNombreTipoPago AND
                            Cuentas.Pago.estado=" + estado + " ORDER BY Cuentas.Pago.idPago DESC;";
            try
            {
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = new SqlCommand(sql, conexion.conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                data.Fill(ds, "Cuentas.Pago");
                DataTable dt = ds.Tables["Cuentas.Pago"];
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
        //Filtro de pago por grados, fecha, tipo pago o numero recibo

        public static DataView GetDataViewFiltroPagoCompleto(int tipo,int periodo,string recibo, int estado)
        {
            Clases.Conexión conexion = new Clases.Conexión();
            string sql = @"SELECT   Cuentas.Pago.idPago         as Código,
                                    Cuentas.Grado.nombreGrado   as Grado,
                                    Cuentas.Alumno.nombres      as Nombres, 
                                    Cuentas.Alumno.apellidos    as Apellidos,
                                    Cuentas.Pago.recibo         as Recibo,
                                    Cuentas.NombreTipoPago.nombreTipoPago   as Pago,
                                    Cuentas.Mora.nombreMora     as Mora,
                                    Cuentas.Pago.total          as Total,
                                    Cuentas.Pago.observacion    as Observación
                            FROM Cuentas.Pago  INNER JOIN  Cuentas.Alumno ON 
                            Cuentas.Pago.idAlumno = Cuentas.Alumno.idAlumno INNER JOIN Cuentas.Grado 
							ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN Cuentas.Mora ON
                            Cuentas.Pago.idMora = Cuentas.Mora.idMora INNER JOIN Cuentas.TipoPago 
							ON Cuentas.Pago.idTipo = Cuentas.TipoPago.idTipoPago
                            INNER JOIN Cuentas.NombreTipoPago 
							ON Cuentas.TipoPago.idNombreTipoPago = Cuentas.NombreTipoPago.idNombreTipoPago AND
                            Cuentas.Pago.estado=" + estado + " and Cuentas.Alumno.idPeriodo="+periodo+" AND Cuentas.Pago.idTipo =" + tipo + "  OR Cuentas.Pago.recibo =" + recibo +"; ";
            try
            {
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = new SqlCommand(sql, conexion.conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                data.Fill(ds, "Cuentas.Pago");
                DataTable dt = ds.Tables["Cuentas.Pago"];
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

    }
}
