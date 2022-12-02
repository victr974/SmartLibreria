using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
//    create table Venta(
//idVenta int primary key identity(1,1),
//idSucursal int,
//idCliente int,
//totalProducto int, 
//montoTotal decimal (10,2),
//contacto varchar(50),
//telefono varchar(50),
//direccion varchar(100),
//idTransaccion varchar(50),
//fechaVenta datetime default getdate(),
//foreign key(idCliente) references Cliente(idCliente),
//foreign key(idSucursal) references Sucursal(idSucursal)
//)

    public class Venta
    {
       public int idVenta { get; set; }
       public int idCliente { get; set; }

        public int totalProducto { get; set; }
        public decimal montoTotal { get; set; }
        public string contacto { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string FechaTexto { get; set; }
        public string idTransaccion { get; set; }
        public List<DetalleVenta> oDetalleVenta { get; set; }

    }
}
