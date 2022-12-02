using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{

//    create table detalleVenta(
//idDetalleVenta int primary key identity(1,1),
//idVenta int,
//idProducto int,
//cantidad int ,
//total decimal (10,2),
//foreign key(idVenta) references Venta(idVenta),
//foreign key(idProducto) references Producto(idProducto)
//)

    public class DetalleVenta
    {
        public int idDetalleVenta { get; set; }
        public int idVenta { get; set; }
        public Producto oProducto { get; set; }
        public int cantidad { get; set; }
        public decimal total { get; set; }

        public string idTransaccion { get; set; }
    }
}
