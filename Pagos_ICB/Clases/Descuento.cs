using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Pagos_ICB.Clases
{
    class Descuento
    {
        //Se encapsulan las variables a usar
        public int IdDescuento { set; get; }
        public string NombreDescuento { set; get; }

        public decimal Valor { set; get; }

        public int Estado { get; set; }
        //Se define un constructor
        public Descuento() { }
        //Se define el destructor
        ~Descuento() { }
        //Constructor para insertar un Descuento
        public Descuento(string nombreDescuento, decimal valor)
        {
            NombreDescuento = nombreDescuento;
            Valor = valor;

        }
        //Constructor para modificar un Descuento
        public Descuento(int idDescuento, string nombreDescuento, decimal valor)
        {
            IdDescuento = idDescuento;
            NombreDescuento = nombreDescuento;
            Valor = valor;
        }
        //Constructor para eliminar un Descuento
        public Descuento(int idDescuento)
        {
            IdDescuento = idDescuento;
        }

        public Descuento(int idDescuento, int estado)
        {
            IdDescuento = idDescuento;
            Estado = estado;
        }
        //Funcion para llamar el store Procedure y asignar los parametros que insertaremos
        public void Agregar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_AgregarDescuento", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                //Se abre la conexion
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("nombreDescuento", SqlDbType.NVarChar, 30));
                cmd.Parameters["nombreDescuento"].Value = NombreDescuento;
                cmd.Parameters.Add(new SqlParameter("valor", SqlDbType.Decimal,6));
                cmd.Parameters["valor"].Value = Valor;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                //Cuando ocurre un error se llama la clase excepcion que dira que fue cerca de Descuentoss donde ocurrio ese error
                throw new Clases.Excepcion(ex.Message, ex, "Clase_Descuentos");
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
            SqlCommand cmd = new SqlCommand("SP_ModificarDescuento", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idDescuento", SqlDbType.Int));
                cmd.Parameters["idDescuento"].Value = IdDescuento;
                cmd.Parameters.Add(new SqlParameter("nombreDescuento", SqlDbType.NVarChar, 30));
                cmd.Parameters["nombreDescuento"].Value = NombreDescuento;
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
        //Funcion para llamar el store Procedure para eliminar un Descuento deseado
        public void Eliminar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_EliminarDescuento", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idDescuento", SqlDbType.Int));
                cmd.Parameters["idDescuento"].Value = IdDescuento;
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
            SqlCommand cmd = new SqlCommand("SP_EliminarDescuento1", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idDescuento", SqlDbType.Int));
                cmd.Parameters["idDescuento"].Value = IdDescuento;
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
        //Funcion para Consultar los datos de un Descuento determinado
        public void ObtenerDescuentos(int idDescuento)
        {
            Conexión conexion = new Conexión();
            string sql = @"SELECT idDescuento, nombreDescuento,Valor FROM Cuentas.Descuento WHERE idDescuento = '" + idDescuento + "';";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            try
            {
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IdDescuento = dr.GetInt32(0);
                    NombreDescuento = dr.GetString(1);
                    Valor = dr.GetDecimal(2);
                }
            }
            catch (SqlException ex)
            {
                throw new Clases.Excepcion(
                   String.Format("{0} \n\n{1}",
                   "no podemos obtener la informacion del Descuento", ex.Message), ex, "Clase_Descuentos"); ;
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
            //Se traen todos los datos de la tabla Descuentoss y los almacena la variable sql
            string sql = @"SELECT   Cuentas.Descuento.idDescuento       as Código,
                                    Cuentas.Descuento.nombreDescuento   as NombreDescuento,
                                    Cuentas.Descuento.valor             as Valor
                            FROM Cuentas.Descuento
                            WHERE estado=" + estado + ";";
            try
            {
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = new SqlCommand(sql, conexion.conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                data.Fill(ds, "Cuentas.Descuento");
                DataTable dt = ds.Tables["Cuentas.Descuento"];
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

        public void ObteneDescuentosPorNombres(string Nombres)
        {
            Conexión conexion = new Conexión();
            string sql = @"SELECT * FROM Cuentas.Descuento WHERE nombreDescuento = '" + Nombres + "';";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            try
            {
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IdDescuento = dr.GetInt32(0);
                    Nombres = dr.GetString(2);
                }
            }
            catch (SqlException excepcion)
            {
                Exception ex = new Exception(
                   String.Format("{0} \n\n{1}",
                   "no podemos obtener la informacion del Descuento", excepcion.Message));
                ex.Source = "Clase_Descuento";
                throw ex;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
    }
}
