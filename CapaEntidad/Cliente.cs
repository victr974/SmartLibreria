using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{

//    Create table Cliente(
//idCliente int identity(1,1) primary key,
//NITCliente char (10) ,
//nombres varchar(100)  ,
//apellidos varchar(100),
//telefono char (10) ,
//correo varchar(100) ,
//clave varchar(150) ,
//reestablecer bit default 0,
//fechaRegistro datetime default getdate()
//)

    public class Cliente
    {
        public int  idCLiente { get; set; }
        public char  NITCliente { get; set; }
        public string  nombres { get; set; }
        public string  apellidos { get; set; }
        public char  telefono { get; set; }
        public string  correo { get; set; }
        public bool  restablecer { get; set; }
    }
}
