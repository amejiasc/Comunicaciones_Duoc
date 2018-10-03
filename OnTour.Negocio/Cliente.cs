using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicaciones.Negocio
{
    public class Cliente : Clases.Cliente
    {
        private Cliente() { }
        /// <summary>
        /// Patron de diseño Factory
        /// </summary>
        /// <returns></returns>
        public static Cliente Factory()
        {
            return new Cliente();
        }
        public string ErrorMensaje { get; set; }

        public Clases.Cliente ListarByIdCliente()
        {
            Store.Cliente objCliente = new Store.Cliente();
            return objCliente.Leer().First(x => x.IdCliente == IdCliente);

        }
        public List<Clases.Cliente> Listar()
        {
            Store.Cliente objCliente = new Store.Cliente();
            return objCliente.Leer();

        }        

        public bool CrearCliente()
        {
            bool retorno = false;
            Store.Cliente objCliente = new Store.Cliente()
            {
                 Comuna = this.Comuna,
                 Direccion = this.Direccion,
                 Email = this.Email,
                 FechaNacimiento = this.FechaNacimiento,
                 NombreCliente = this.NombreCliente,
                 RutCliente = this.RutCliente,
                 Region = this.Region
            };            
            string error = "";            
            if (string.IsNullOrEmpty(error))
            {
                retorno = objCliente.Crear();
                if (!retorno)
                {
                    ErrorMensaje = "No fue posible guardar el Cliente en la BD";
                }
            }
            else
            {
                ErrorMensaje = error;
            }

            return retorno;
        }
        public bool ModificarCliente()
        {
            bool retorno = false;
            Store.Cliente objCliente = new Store.Cliente()
            {
                Comuna = this.Comuna,
                Direccion = this.Direccion,
                Email = this.Email,
                FechaNacimiento = this.FechaNacimiento,
                NombreCliente = this.NombreCliente,
                RutCliente = this.RutCliente,
                Region = this.Region
            };
                       
            string error = "";           
            if (string.IsNullOrEmpty(error))
            {
                retorno = objCliente.Modificar();
                if (!retorno)
                {
                    ErrorMensaje = "No fue posible guardar el Cliente en la BD";
                }
            }
            else
            {
                ErrorMensaje = error;
            }

            return retorno;
        }
    }
}
