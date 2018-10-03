using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicaciones.Negocio
{
    public class Usuario : Clases.Usuario
    {
        private Usuario() { }
        /// <summary>
        /// Patron de diseño Factory
        /// </summary>
        /// <returns></returns>
        public static Usuario Factory() {
            return new Usuario();
        }
        public string ErrorMensaje { get; set; }
        public Clases.Usuario Login(string rut, string clave) {

            Clases.Usuario retorno = null;
            if (Funciones.validarRut(rut))
            {
                Store.Usuario objUsuario = new Store.Usuario();
                objUsuario.Clave = clave;
                objUsuario.Rut = rut;
                retorno = objUsuario.Login();
                if (retorno == null) ErrorMensaje = "Usuario no existe en la BD";

                return retorno;
            }
            else {
                ErrorMensaje = "Rut es invalido";
                return retorno;
            }


        }
    }
}
