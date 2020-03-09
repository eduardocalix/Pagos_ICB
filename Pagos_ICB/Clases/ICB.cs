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
        //Excepcion para modulo de Alumnos 2da capa
        private static void ValidarAlumnos
            (
            string identidad,
            string nombre,
            string apellido,
            string beca
            )
        {
            if (identidad.Length != 15 || nombre.Length == 0 || apellido.Length == 0 || beca.Length == 0)
            {
                throw new Clases.Excepcion
                    (
                    "Error al insertar el Alumnos. \n\n" +
                    "Existen datos obligatorios que se necesitan para poder agregar el Alumnos:\n" +
                    "Identidad: 1234-1234-12345\n" +
                    "Nombre   : Pedro\n" +
                    "Apellido : Picapiedra"+
                    "Beca : Si/No",
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
            string beca
            )
        {
            try
            {
                ValidarAlumnos(identidad, nombre, apellido,beca);
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
            int idAlumno,
            string identidad,
            string nombre,
            string apellido,
              int idGrado,
            string beca)
        {
            try
            {
                ValidarAlumnos(identidad, nombre, apellido,beca);
                Clases.Alumnos Alumnos = new Clases.Alumnos(
                    idAlumno,
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


        public static void EliminarAlumnos(int idAlumno)
        {
            try
            {
                Clases.Alumnos Alumnos = new Clases.Alumnos(idAlumno);
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

        /*Modulo Usuario 2da Capa*/

        private static void ValidarUsuarios(
        string nombre,
        string apellido,
        string clave
        )
        {
            if (apellido.Length == 0 || nombre.Length == 0 || clave.Length == 0){
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
        /*Modulo Mora 2da capa*/
        private static void ValidarMora
            (
            string nombre,
            decimal valor
            )
        {
            if ( nombre.Length == 0 || valor < 0)
            {
                throw new Clases.Excepcion
                    (
                    "Error al insertar el Mora. \n\n" +
                    "Existen datos obligatorios que se necesitan para poder agregar la Mora:\n" +
                    "Nombre Mora   : Pedro\n" +
                    "Valor : 3%",
                    new Exception(),
                    "Clase_ICB"
                    );
            }
        }
        public static void AgregarMora
            (
            
            string nombreMora,
            decimal valor
            )
        {
            try
            {
                ValidarMora(nombreMora, valor);
                Clases.Mora Mora = new Clases.Mora(
                    nombreMora,
                    valor
                    );
                Mora.Agregar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ModificarMora(
            int idMora,
            string nombreMora,
            decimal valor)
        {
            try
            {
                ValidarMora( nombreMora, valor);
                Clases.Mora Mora = new Clases.Mora(
                    idMora,
                    nombreMora,
                   valor);
                Mora.Modificar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void EliminarMora(int idMora)
        {
            try
            {
                Clases.Mora Mora = new Clases.Mora(idMora);
                Mora.Eliminar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void EliminarMora1(int id, int estado)
        {
            try
            {
                Clases.Mora Mora = new Clases.Mora(id, estado);
                Mora.Eliminar1();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*Modulo Grado 2da capa*/
        private static void ValidarGrado
           (
           string nombre
           )
        {
            if (nombre.Length == 0 )
            {
                throw new Clases.Excepcion
                    (
                    "Error al insertar el Grado. \n\n" +
                    "Existen datos obligatorios que se necesitan para poder agregar el Grado:\n" +
                    "Nombre Grado   : Pedro\n" +
                    "Valor : 30%",
                    new Exception(),
                    "Clase_ICB"
                    );
            }
        }
        public static void AgregarGrado
            (

            string nombreGrado
            )
        {
            try
            {
                ValidarGrado(nombreGrado);
                Clases.Grado Grado = new Clases.Grado(
                    nombreGrado
                    );
                Grado.Agregar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ModificarGrado(
            int idGrado,
            string nombreGrado)
        {
            try
            {
                ValidarGrado(nombreGrado);
                Clases.Grado Grado = new Clases.Grado(
                    idGrado,
                    nombreGrado
                    );
                Grado.Modificar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void EliminarGrado(int idGrado)
        {
            try
            {
                Clases.Grado Grado = new Clases.Grado(idGrado);
                Grado.Eliminar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void EliminarGrado1(int id, int estado)
        {
            try
            {
                Clases.Grado Grado = new Clases.Grado(id, estado);
                Grado.Eliminar1();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*Modulo descuento 2da capa*/
        private static void ValidarDescuento
           (
           string nombre,
           decimal valor
           )
        {
            if (nombre.Length == 0 || valor < 0)
            {
                throw new Clases.Excepcion
                    (
                    "Error al insertar el Descuento. \n\n" +
                    "Existen datos obligatorios que se necesitan para poder agregar el Descuento:\n" +
                    "Nombre Descuento   : 30 PORCIENTO\n" +
                    "Valor : 30%",
                    new Exception(),
                    "Clase_ICB"
                    );
            }
        }
        public static void AgregarDescuento
            (

            string nombreDescuento,
            decimal valor
            )
        {
            try
            {
                ValidarDescuento(nombreDescuento, valor);
                Clases.Descuento Descuento = new Clases.Descuento(
                    nombreDescuento,
                    valor
                    );
                Descuento.Agregar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ModificarDescuento(
            int idDescuento,
            string nombreDescuento,
            decimal valor)
        {
            try
            {
                ValidarDescuento(nombreDescuento, valor);
                Clases.Descuento Descuento = new Clases.Descuento(
                    idDescuento,
                    nombreDescuento,
                   valor);
                Descuento.Modificar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void EliminarDescuento(int idDescuento)
        {
            try
            {
                Clases.Descuento Descuento = new Clases.Descuento(idDescuento);
                Descuento.Eliminar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void EliminarDescuento1(int id, int estado)
        {
            try
            {
                Clases.Descuento Descuento = new Clases.Descuento(id, estado);
                Descuento.Eliminar1();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*Modulo TipoPago 2da capa*/
        private static void ValidarTipoPago
           (
           int nombre,
           int idGrado,
           decimal valor
           )
        {
            if (nombre < 0 || valor < 0|| idGrado < 0)
            {
                throw new Clases.Excepcion
                    (
                    "Error al insertar el TipoPago. \n\n" +
                    "Existen datos obligatorios que se necesitan para poder agregar el TipoPago:\n" +
                    "Nombre TipoPago   : Matricula\n" +
                    "Grado : Primero\n"+
                    "Valor : L.1000.00",
                    new Exception(),
                    "Clase_ICB"
                    );
            }
        }
        public static void AgregarTipoPago
            (

            int nombreTipoPago,
            int idGrado,
            decimal valor
            )
        {
            try
            {
                ValidarTipoPago(nombreTipoPago,idGrado, valor);
                Clases.TipoPago TipoPago = new Clases.TipoPago(
                    nombreTipoPago,
                    idGrado,
                    valor
                    );
                TipoPago.Agregar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ModificarTipoPago(
            int idTipoPago,
            int nombreTipoPago,
            int idGrado,
            decimal valor)
        {
            try
            {
                ValidarTipoPago(nombreTipoPago,idGrado, valor);
                Clases.TipoPago TipoPago = new Clases.TipoPago(
                    idTipoPago,
                    nombreTipoPago,
                    idGrado,
                   valor);
                TipoPago.Modificar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void EliminarTipoPago(int idTipoPago)
        {
            try
            {
                Clases.TipoPago TipoPago = new Clases.TipoPago(idTipoPago);
                TipoPago.Eliminar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void EliminarTipoPago1(int id, int estado)
        {
            try
            {
                Clases.TipoPago TipoPago = new Clases.TipoPago(id, estado);
                TipoPago.Eliminar1();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
