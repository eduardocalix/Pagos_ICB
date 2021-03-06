﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Pagos_ICB.Clases
{
    class Usuarios
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public int Estado { get; set; }


        public Usuarios() { }

        public Usuarios(string usuario)
        {
            this.usuario = usuario;
        }
        public Usuarios(string usuario, int estado)
        {
            this.usuario = usuario;
            this.Estado = estado;
        }
        public Usuarios(string nombre, string apellido, string clave)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.clave = clave;
        }

        public Usuarios(string usuario, string nombre, string apellido, string clave)
        {
            this.usuario = usuario;
            this.nombre = nombre;
            this.apellido = apellido;
            this.clave = clave;
        }


        public void ObtenerUsuario(string usuarioRe)
        {
            Conexión conexion = new Conexión();
            string sql = @"SELECT idUsuario, nombre, apellido, usuario, clave FROM Acceso.Usuario WHERE usuario = '" + usuarioRe + "' AND estado=1;";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            try
            {
                conexion.Abrir();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.idUsuario = dr.GetInt32(0);
                    this.nombre = dr.GetString(1);
                    this.apellido = dr.GetString(2);
                    this.usuario = dr.GetString(3);
                    this.clave = dr.GetString(4);
                }
            }
            catch (SqlException excepcion)
            {
                Exception ex = new Exception(
                   String.Format("{0} \n\n{1}",
                   "no podemos obtener la informacion del usuario", excepcion.Message));
                ex.HelpLink = "eduardocalix11xtra@gmail.com";
                ex.Source = "Clase_Usuario";
                throw ex;
            }
            finally
            {
                conexion.Cerrar();
            }
        }

        public static int id1;

        public static int ObtenerUsuarioId(string usuarioRe)
        {

            Conexión conexion = new Conexión();
            string sql = @"SELECT idUsuario FROM Acceso.Usuario WHERE usuario = '" + usuarioRe + "';";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            try
            {
                conexion.Abrir();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    id1 = dr.GetInt32(0);
                }
                return id1;
            }
            catch (SqlException excepcion)
            {
                id1 = 1;
                Exception ex = new Exception(
                   String.Format("{0} \n\n{1}",
                   "no podemos obtener la informacion del usuario", excepcion.Message));
                ex.HelpLink = "eduardocalix11xtra@gmail.com";
                ex.Source = "Clase_Usuario";

                return id1;
                throw ex;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public void Agregar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_InsertarUsuario", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("nombre", SqlDbType.NVarChar, 25));
                cmd.Parameters["nombre"].Value = this.nombre;
                cmd.Parameters.Add(new SqlParameter("apellido", SqlDbType.NVarChar, 25));
                cmd.Parameters["apellido"].Value = this.apellido;
                cmd.Parameters.Add(new SqlParameter("clave", SqlDbType.NVarChar, 20));
                cmd.Parameters["clave"].Value = this.clave;
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

        public void Modificar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_ModificarUsuario", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("usuarioAnterior", SqlDbType.VarChar, 26));
                cmd.Parameters["usuarioAnterior"].Value = this.usuario;
                cmd.Parameters.Add(new SqlParameter("nombre", SqlDbType.NVarChar, 25));
                cmd.Parameters["nombre"].Value = this.nombre;
                cmd.Parameters.Add(new SqlParameter("apellido", SqlDbType.NVarChar, 25));
                cmd.Parameters["apellido"].Value = this.apellido;
                cmd.Parameters.Add(new SqlParameter("clave", SqlDbType.NVarChar, 20));
                cmd.Parameters["clave"].Value = this.clave;
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
            SqlCommand cmd = new SqlCommand("SP_EliminarUsuario1", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("usuario", SqlDbType.VarChar, 26));
                cmd.Parameters["usuario"].Value = this.usuario;
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
        public void Eliminar()
        {
            Clases.Conexión conexion = new Clases.Conexión();
            SqlCommand cmd = new SqlCommand("SP_EliminarUsuario", conexion.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.Abrir();
                cmd.Parameters.Add(new SqlParameter("usuario", SqlDbType.VarChar, 26));
                cmd.Parameters["usuario"].Value = this.usuario;
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

        public static DataView GetDataView(int estado)
        {
            Clases.Conexión conexion = new Clases.Conexión();
            string sql = @"SELECT   Acceso.Usuario.idUsuario   as Código,
                                    Acceso.Usuario.nombre      as Nombre, 
                                    Acceso.Usuario.apellido    as Apellido, 
                                    Acceso.Usuario.usuario     as Usuario
                            FROM Acceso.Usuario
                            WHERE estado=" + estado + ";";
            try
            {
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = new SqlCommand(sql, conexion.conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                data.Fill(ds, "Acceso.Usuario");
                DataTable dt = ds.Tables["Acceso.Usuario"];
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
        public static DataTable GetDataTableUsuarios()
        {
            DataTable dt = new DataTable();
            Clases.Conexión conexion = new Clases.Conexión();
            string sql = "select usuario FROM Acceso.Usuario";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}
