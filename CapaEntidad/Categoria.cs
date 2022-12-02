using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{

//////    create table Categoria(
//////idCategoria int identity(1,1) primary key,
//////nombre varchar(45),
//////descripcion varchar(100)
//////)
///
    public  class Categoria
    {
        public int idCategoria { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}
