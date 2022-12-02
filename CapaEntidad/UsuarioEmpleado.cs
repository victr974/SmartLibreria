using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{

//    create table UsuarioEmpleado(
//idUsuario int primary key identity(1,1),
//nombres varchar(100),
//apellidos varchar(100),
//correo varchar(100),
//clave varchar(150),
//reestablecer bit default 1,
//activo bit default 1,
//fechaRegistro datetime default getdate(),
//idSucursal int,
//foreign key(idSucursal) references Sucursal(idSucursal)
//)

    public class UsuarioEmpleado
    {
        public int idUsuario { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public bool  reestablecer { get; set; }
        public bool activo { get; set; }
    }
}
