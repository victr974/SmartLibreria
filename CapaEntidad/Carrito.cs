using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
//    Create table Carrito(
//idCarrito int identity(1,1) primary key,
//idCliente int,
//idProducto int,
//cantidad int,
    public class Carrito
    {
        public int idCarrito { get; set; }
        public Cliente oCliente  { get; set; }
        public Producto oProducto  { get; set; }
        public int  cantidad  { get; set; }
    }
}
