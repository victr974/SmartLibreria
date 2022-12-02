using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Producto
    {
        //Esto nos permite acceder a los metodos 
        private CD_Productos objCapaDato = new CD_Productos();
        
        public List<Producto> Listar()
        {
            return objCapaDato.Listar();
        }


        public int Registrar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.nombreProducto) || string.IsNullOrWhiteSpace(obj.nombreProducto))
            {
                Mensaje = "El nombre del producto no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.descripcion) || string.IsNullOrWhiteSpace(obj.descripcion))
            {
                Mensaje = "La descripcion del producto no puede ser vacio";
            }
            else if (obj.oMarca.idMarca == 0)
            {
                Mensaje = "Debe seleccionar una marca";
            }
            else if (obj.oCategoria.idCategoria == 0)
            {
                Mensaje = "Debe seleccionar una categoria";
            }
            else if (obj.precio == 0)
            {
                Mensaje = "Debe ingresar el precio del producto";
            }
            else if (obj.stock == 0)
            {
                Mensaje = "Debe ingresar el stock del producto";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);

            }

            else
            {
                return 0;
            }

        }

        public bool Editar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.nombreProducto) || string.IsNullOrWhiteSpace(obj.nombreProducto))
            {
                Mensaje = "El nombre del producto no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.descripcion) || string.IsNullOrWhiteSpace(obj.descripcion))
            {
                Mensaje = "La descripcion del producto no puede ser vacio";
            }
            else if (obj.oMarca.idMarca == 0)
            {
                Mensaje = "Debe seleccionar una marca";
            }
            else if (obj.oCategoria.idCategoria == 0)
            {
                Mensaje = "Debe seleccionar una categoria";
            }
            else if (obj.precio == 0)
            {
                Mensaje = "Debe ingresar el precio del producto";
            }
            else if (obj.stock == 0)
            {
                Mensaje = "Debe ingresar el stock del producto";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }

        }

        public bool GuardarDatosImagen(Producto obj, out string Mensaje)
        {
            return objCapaDato.GuardarDatosImagen(obj, out Mensaje);
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}
