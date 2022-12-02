using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
//    Create table Marca(
//idMarca int identity(1,1) primary key,
//nombreMarca varchar(35),
//descripcion varchar(100),
//)

    public class Marca
    {
        public int idMarca { get; set; }
        public string nombreMarca { get; set; }
        public string descripcion { get; set; }
    }
}
