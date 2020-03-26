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


        public static DataView GetDataViewFiltroPago1( int idAlumno,int estado)
        {
            Clases.Conexión conexion = new Clases.Conexión();
            string sql = @"SELECT   Cuentas.Pago.idPago         as Código,
                                    Cuentas.Grado.nombreGrado   as Grado,
                                    Cuentas.Alumno.nombres      as Nombre, 
                                    Cuentas.Alumno.apellidos    as Apellidos,
                                    Cuentas.Pago.recibo         as Recibo,
                                    Cuentas.Mora.nombreMora     as Mora,
                                    Cuentas.Pago.total          as Total
                            FROM Cuentas.Pago  INNER JOIN  Cuentas.Alumno ON 
                            Cuentas.Pago.idAlumno = Cuentas.Alumno.idAlumno INNER JOIN Cuentas.Grado 
							ON Cuentas.Alumno.idGrado = Cuentas.Grado.idGrado INNER JOIN Cuentas.Mora ON
                            Cuentas.Pago.idMora = Cuentas.Mora.idMora AND
                            Cuentas.Pago.estado=" + estado + " AND Cuentas.Pago.idAlumno =" + idAlumno + ";";
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
