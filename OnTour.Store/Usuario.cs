using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicaciones.Store
{
    public class Usuario : Clases.Usuario, Interfaz.IRepositorio
    {
        public bool Crear()
        {
            throw new NotImplementedException();
        }

        public bool Eliminar()
        {
            throw new NotImplementedException();
        }
        
        public bool Modificar()
        {
            throw new NotImplementedException();
        }

        public List<Clases.Usuario> Leer()
        {
            List<Clases.Usuario> usuarios = new List<Clases.Usuario>();

            string vSql = "select  id, Usuarios.idTipoUsuario,	rut, nombres,	apellidos,	email,	vigente, " +
                          " tipoUsuario.nombreTipo,	tipoUsuario.codigoTipo, passowrd " +
                          " FROM Usuarios " +
                          " INNER JOIN tipoUsuario ON (tipoUsuario.idTipoUsuario = Usuarios.idTipoUsuario)";

            Conexion conexion = new Conexion();
            DataTable dt = conexion.EjecutarDT(vSql);
            foreach (DataRow item in dt.Rows)
            {
                var a = new Usuario()
                {      
                    Id = (long)item[0],
                    IdTipoUsuario = (int)item[1],
                    Rut = (string)item[2],
                    Nombres = (string)item[3],
                    Apellidos = (string)item[4],
                    Email = (string)item[5],
                    Vigente = (bool)item[6],
                    NombreTipoUsuario = (string)item[7],
                    CodigoTipoUsuario = (string)item[8],
                    Clave = (string)item[9]
                };
                usuarios.Add(a);
                

            }
            return usuarios;
        }

        public Clases.Usuario Login()
        {
            try
            {
                Clases.Usuario usuario = Leer().First(x => x.Rut == Rut && x.Clave == Clave && x.Vigente == true);
                return usuario;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
