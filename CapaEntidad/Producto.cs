using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
//    create table Producto(
//idProducto int identity(1,1) primary key,
//nombreProducto varchar(20),
//descripcion varchar(1000),
//idMarca int,
//idCategoria int,
//idProveedor char (5),
//precio decimal (10,2),
//stock int,
//RutaImagen varchar(100),
//NombreImagen varchar(100),
//activo bit default 1,
//FOREIGN KEY(idCategoria) references Categoria(idCategoria),
//FOREIGN KEY(idMarca) references Marca(idMarca),
//FOREIGN KEY(idProveedor) references Proveedor(idProveedor),
//fechaRegistro datetime default getdate()
//)

    public class Producto
    {
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public string descripcion { get; set; }
        public Marca oMarca { get; set; }
        public Categoria oCategoria { get; set; }
        public decimal precio { get; set; }

        public string precioTexto { get; set; }

        public int stock { get; set; }
        public  string RutaImagen  { get; set; }
        public  string NombreImagen { get; set; }
        public bool activo { get; set; }

        public string Base64 { get; set; }  
        public string Extesion { get; set; }    




    }
}
