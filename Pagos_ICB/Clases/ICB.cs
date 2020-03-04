using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pagos_ICB.Clases
{
    class ICB
    {

        //Se establece el constructor de la clase ICB
        public ICB() { }
        //Excepcion para modulo de Alumnos
        private static void ValidarAlumnos
            (
            string identidad,
            string nombre,
            string apellido
            )
        {
            if (identidad.Length != 15 || nombre.Length == 0 || apellido.Length == 0)
            {
                throw new Clases.Excepcion
                    (
                    "Error al insertar el Alumnos. \n\n" +
                    "Existen datos obligatorios que se necesitan para poder agregar a el Alumnos:\n" +
                    "Identidad: 1234-1234-12345\n" +
                    "Nombre   : Pedro\n" +
                    "Apellido : Picapiedra",
                    new Exception(),
                    "Clase_ICB"
                    );
            }
        }
        public static void AgregarAlumnos
            (
            string identidad,
            string nombre,
            string apellido,
            int idGrado,
            int beca
            )
        {
            try
            {
                ValidarAlumnos(identidad, nombre, apellido);
                Clases.Alumnos Alumnos = new Clases.Alumnos(
                    identidad,
                    nombre,
                    apellido,
                    idGrado,
                    beca
                    );
                Alumnos.Agregar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ModificarAlumnos(
            int id,
            string identidad,
            string nombre,
            string apellido,
              int idGrado,
            int beca)
        {
            try
            {
                ValidarAlumnos(identidad, nombre, apellido);
                Clases.Alumnos Alumnos = new Clases.Alumnos(
                    id,
                    identidad,
                    nombre,
                   apellido,
                   idGrado,
                    beca);
                Alumnos.Modificar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void EliminarAlumnos(int id)
        {
            try
            {
                Clases.Alumnos Alumnos = new Clases.Alumnos(id);
                Alumnos.Eliminar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void EliminarAlumnos1(int id, int estado)
        {
            try
            {
                Clases.Alumnos Alumnos = new Clases.Alumnos(id, estado);
                Alumnos.Eliminar1();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private static void ValidarUsuarios
    (
    string nombre,
    string apellido,
    string clave
    )
        {
            if (apellido.Length == 0 || nombre.Length == 0 || clave.Length == 0)
            {
                throw new Clases.Excepcion
                    (
                    "Error al insertar el usuario \n\n" +
                    "Existen datos obligatorios que se necesitan para poder agregar un usuario:\n" +
                    "Nombre   : Pedro\n" +
                    "Apellido  :  Picapiedra\n" +
                    "Clave : yabadabadu",
                    new Exception(),
                    "Clase_ICB"
                    );
            }
        }
        public static void AgregarUsuario(
            string nombre,
            string apellido,
            string clave)
        {
            try
            {
                ValidarUsuarios(nombre, apellido, clave);
                Clases.Usuarios usuario = new Clases.Usuarios(
                    nombre,
                    apellido,
                    clave
                    );
                usuario.Agregar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void ModificarUsuario(
            string usu,
            string nombre,
            string apellido,
            string clave)
        {
            try
            {
                ValidarUsuarios(nombre, apellido, clave);
                Clases.Usuarios usuario = new Clases.Usuarios(
                    usu,
                    nombre,
                    apellido,
                    clave
                    );
                usuario.Modificar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void EliminarUsuario(string usu)
        {
            try
            {
                Clases.Usuarios usuarios = new Clases.Usuarios(usu);
                usuarios.Eliminar();
            }
            catch (Exception es)
            {

                throw es;
            }
        }
        public static void EliminarUsuario1(string usu, int estado)
        {
            try
            {
                Clases.Usuarios usuarios = new Clases.Usuarios(usu, estado);
                usuarios.Eliminar1();
            }
            catch (Exception es)
            {

                throw es;
            }
        }

    }
}
