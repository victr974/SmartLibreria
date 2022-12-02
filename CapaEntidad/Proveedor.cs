using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
//    create table proveedor(
//idProveedor char(5) primary key,
//nombres varchar(50),
//apellidos varchar(50),
//nombreEmpresa varchar(50),
//direccion varchar(50),
//departamento varchar(50)
//)
    public class Proveedor
    {
        public int idProveedor { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string nombreEmpresa { get; set; }
        public string direccion { get; set; }
        public string departamento { get; set; }


    }
}
