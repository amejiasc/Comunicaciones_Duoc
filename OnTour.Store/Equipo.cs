using Comunicaciones.Store;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicaciones.Store
{
    public class Equipo : Clases.Equipo
    {
        public List<Clases.Equipo> Leer()
        {
            List<Clases.Equipo> equipos = new List<Clases.Equipo>();

            string vSql = "select  * " +
                          " FROM Equipo order by nombreEquipo ";

            Conexion conexion = new Conexion();
            DataTable dt = conexion.EjecutarDT(vSql);
            foreach (DataRow item in dt.Rows)
            {
                var a = new Equipo()
                {
                    EquipoId = (int)item[0],
                    NombreEquipo = (string)item[1]
                };
                equipos.Add(a);


            }
            return equipos;
        }
    }
}
