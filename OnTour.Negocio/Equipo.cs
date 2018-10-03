using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicaciones.Negocio
{
    public class Equipo : Clases.Equipo
    {
        private Equipo() { }
        /// <summary>
        /// Patron de diseño Factory
        /// </summary>
        /// <returns></returns>
        public static Equipo Factory()
        {
            return new Equipo();
        }
        public string ErrorMensaje { get; set; }
        public List<Clases.Equipo> ListarEquipos()
        {           
            Store.Equipo objEquipo = new Store.Equipo();
            return objEquipo.Leer();
        }
    }
}
