using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicaciones.Store
{
    public class Cliente : Clases.Cliente, Interfaz.IRepositorio
    {
        public bool Crear()
        {
            string vSql = "INSERT INTO Cliente (nombrecliente, rutCliente, fechaNacimiento, region, comuna, direccion, email) VALUES " +
                          "('" + NombreCliente + "', '" + RutCliente + "', '" + FechaNacimiento.ToString("yyyy-MM-dd")  + "', " + Region + ", '"+ Comuna +"', " +
                          " '" + Direccion + "', '" + Email + "' ) ";
            Conexion conexion = new Conexion();
            return conexion.Ejecutar(vSql);
        }

        public bool Eliminar()
        {
            string vSql = "DELETE FROM Cliente clienteId=" + IdCliente;
            Conexion conexion = new Conexion();
            return conexion.Ejecutar(vSql);
        }


        public bool Modificar()
        {
            string vSql = "UPDATE Cliente SET nombrecliente='" + NombreCliente + "', rutCliente='"+ RutCliente + "', fechaNacimiento='" + FechaNacimiento.ToString("yyyy-MM-dd") + "', " + 
                         " region="+ Region +", comuna='"+ Comuna +"', direccion='"+ Direccion +"', email='"+Email +"' " +
                         " WHERE clienteId=" + IdCliente;

            Conexion conexion = new Conexion();
            return conexion.Ejecutar(vSql);
        }

        public List<Clases.Cliente> Leer()
        {
            List<Clases.Cliente> clientes = new List<Clases.Cliente>();

            string vSql = "select  * " +
                          " FROM Cliente ";

            Conexion conexion = new Conexion();
            DataTable dt = conexion.EjecutarDT(vSql);
            foreach (DataRow item in dt.Rows)
            {
                var a = new Cliente()
                {
                    IdCliente = (int)item[0],
                    NombreCliente = (string)item[1],
                    RutCliente = (string)item[2],
                    FechaNacimiento = (DateTime)item[3],
                    Region = (int)item[4],
                    Comuna = (string)item[5],
                    Direccion = (string)item[6],
                    Email = (string)item[7]
                };
                clientes.Add(a);
            }
            return clientes;
        }
    }
}
