using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagos_ICB.Clases
{
    class VariablesGlobales
    {
        //Estas variables estan funcionando. Si se eliminan, tener en cuenta el crearlas.
        public static int controlPagoSalida;
        public static string user;
        public static int idapertura;
        public static int idUsu = Usuarios.ObtenerUsuarioId(user);
    }
}
