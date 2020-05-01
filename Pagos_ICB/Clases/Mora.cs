using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Pagos_ICB.Clases
{
    class Mora
    {
        //Se encapsulan las variables a usar
        public int IdMora { set; get; }
        public string NombreMora { set; get; }

        public decimal Valor { set; get; }
  
        public int Estado { get; set; }
        //Se define un constructor
        public Mora() { }
        //Se define el destructor
        ~Mora() { }
        //Constructor para insertar un Mora
        public Mora(string nombreMora, decimal valor)
        {
            NombreMora = nombreMora;
            Valor = valor;

        }
        //Constructor para modificar un Mora
        public Mora(int idMora, string nombreMora, decimal valor)
        {
            IdMora = idMora;
            NombreMora = nombreMora;
            Valor = valor;
        }
        //Constructor para eliminar una Mora
        public Mora(int idMora)
        {
            IdMora = idMora;
        }

        public Mora(int idMora, int estado)
        {
            IdMora = idMora;
            Estado = estado;
        }
        //Funcion para llamar el store Procedure y asignar los parametros que insertaremos
        public void Agregar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_AgregarMora", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                //Se abre la conexion
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("nombreMora", SqlDbType.NVarChar, 20));
                cmd.Parameters["nombreMora"].Value = NombreMora;
                cmd.Parameters.Add(new SqlParameter("valor", SqlDbType.Decimal));
                cmd.Parameters["valor"].Value = Valor;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                //Cuando ocurre un error se llama la clase excepcion que dira que fue cerca de Morass donde ocurrio ese error
                throw new Clases.Excepcion(ex.Message, ex, "Clase_Moras");
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
            SqlCommand cmd = new SqlCommand("SP_ModificarMora", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idMora", SqlDbType.Int));
                cmd.Parameters["idMora"].Value = IdMora;
                cmd.Parameters.Add(new SqlParameter("nombreMora", SqlDbType.NVarChar, 20));
                cmd.Parameters["nombreMora"].Value = NombreMora;
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
        //Funcion para llamar el store Procedure para eliminar un Mora deseado
        public void Eliminar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_EliminarMora", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idMora", SqlDbType.Int));
                cmd.Parameters["idMora"].Value = IdMora;
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
            SqlCommand cmd = new SqlCommand("SP_EliminarMora1", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("idMora", SqlDbType.Int));
                cmd.Parameters["idMora"].Value = IdMora;
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
        //Funcion para Consultar los datos de un Mora determinado
        public void ObtenerMoras(int idMora)
        {
            Conexión conexion = new Conexión();
            string sql = @"SELECT idMora, nombreMora,Valor FROM Cuentas.Mora WHERE idMora = '" + idMora + "';";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            try
            {
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IdMora = dr.GetInt32(0);
                    NombreMora = dr.GetString(1);
                    Valor = dr.GetDecimal(2);
                }
            }
            catch (SqlException ex)
            {
                throw new Clases.Excepcion(
                   String.Format("{0} \n\n{1}",
                   "no podemos obtener la informacion de la Mora", ex.Message), ex, "Clase_Mora"); ;
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
            //Se traen todos los datos de la tabla Morass y los almacena la variable sql
            string sql = @"SELECT   Cuentas.Mora.idMora       as Código,
                                    Cuentas.Mora.nombreMora   as NombreMora,
                                    CONCAT('L. ',Cuentas.Mora.valor)       as Valor
                            FROM Cuentas.Mora
                            WHERE estado=" + estado + ";";
            try
            {
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = new SqlCommand(sql, conexion.conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                data.Fill(ds, "Cuentas.Mora");
                DataTable dt = ds.Tables["Cuentas.Mora"];
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

        public void ObteneMorasPorNombres(string Nombres)
        {
            Conexión conexion = new Conexión();
            string sql = @"SELECT * FROM Cuentas.Mora WHERE nombreMora = '" + Nombres + "';";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            try
            {
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IdMora = dr.GetInt32(0);
                    Nombres = dr.GetString(1);
                    Valor = dr.GetDecimal(2);
                }
            }
            catch (SqlException excepcion)
            {
                Exception ex = new Exception(
                   String.Format("{0} \n\n{1}",
                   "no podemos obtener la informacion del Mora", excepcion.Message));
                ex.Source = "Clase_Mora";
                throw ex;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
    }
}
