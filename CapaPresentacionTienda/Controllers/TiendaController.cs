using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;


namespace CapaPresentacionTienda.Controllers
{
    public class TiendaController : Controller
    {
        // GET: Tienda
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DetalleProducto(int idproducto = 0)
        {
            Producto oproducto = new Producto();
            bool conversion;

            oproducto = new CN_Producto().Listar().Where(p => p.idProducto == idproducto).FirstOrDefault();

            if(oproducto != null)
            {
                oproducto.Base64 = CN_Recursos.ConvertirBase64(Path.Combine(oproducto.RutaImagen, oproducto.NombreImagen), out conversion);
                oproducto.Extension = Path.GetExtension(oproducto.NombreImagen);
            }

            return View(oproducto);
        }

        //Metodos

        [HttpGet]
        public JsonResult ListaCategorias()
        {
            List<Categoria> lista = new List<Categoria>();

            lista = new CN_Categoria().Listar();

            return Json(new { data=lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarMarcaporCategoria(int idcategoria)
        {
            List<Marca> lista = new List<Marca>();

            lista = new CN_Marca().ListarMarcaporCategoria(idcategoria);

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarProducto( int idcategoria, int idmarca)
        {
            List<Producto> lista = new List<Producto>();

            bool conversion;

            lista = new CN_Producto().Listar().Select(p => new Producto()
            {
                idProducto = p.idProducto,
                nombreProducto = p.nombreProducto,
                oMarca = p.oMarca,
                oCategoria = p.oCategoria,
                precio = p.precio,
                stock = p.stock,
                RutaImagen = p.RutaImagen,
                Base64 = CN_Recursos.ConvertirBase64(Path.Combine(p.RutaImagen, p.NombreImagen), out conversion),
                Extension = Path.GetExtension(p.NombreImagen),
                activo = p.activo
            }).Where(p =>
                    p.oCategoria.idCategoria == (idcategoria == 0 ? p.oCategoria.idCategoria : idcategoria) &&
                    p.oMarca.idMarca == (idmarca == 0 ? p.oMarca.idMarca : idmarca) &&
                    p.stock > 0 && p.activo == true

            ).ToList();

            var jsonresult = Json(new {data = lista}, JsonRequestBehavior.AllowGet);
            jsonresult.MaxJsonLength = int.MaxValue;

            return jsonresult;
        }

        [HttpPost]
        public JsonResult AgregarCarrito(int idproducto)
        {
             //De esa forma se obtien el id del cliente del cual a accedido al sistema 
            int idcliente =((Cliente) Session["Cliente"]).idCliente;

            //Validar si es que existe este producto dentro del carrito del cliente
            bool existe = new CN_Carrito().ExisteCarrito(idcliente, idproducto);

            bool respuesta = false;

            string mensaje = string.Empty;

            if (existe)
            {
                mensaje = "El producto ya existe en el carrito";
            }
            else
            {
                respuesta = new CN_Carrito().OperacionCarrito(idcliente,idproducto, true, out mensaje);

            }

            return Json(new {respuesta = respuesta, mensaje = mensaje}, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CantidadEnCarrito()
        {
            int idcliente = ((Cliente)Session["Cliente"]).idCliente;
            int cantidad = new CN_Carrito().CantidadEnCarrito(idcliente);
            return Json(new { cantidad = cantidad }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarProductoCarrito()
        {
            int idcliente = ((Cliente)Session["Cliente"]).idCliente;

            List<Carrito> olista = new List<Carrito>();

            bool conversion;

            olista = new CN_Carrito().ListarProducto(idcliente).Select(oc => new Carrito()
            {
                oProducto = new Producto()
                {
                    idProducto = oc.oProducto.idProducto,
                    nombreProducto = oc.oProducto.nombreProducto,
                    oMarca = oc.oProducto.oMarca,
                    precio = oc.oProducto.precio,
                    RutaImagen = oc.oProducto.RutaImagen,
                    Base64 = CN_Recursos.ConvertirBase64(Path.Combine(oc.oProducto.RutaImagen, oc.oProducto.NombreImagen), out conversion),
                    Extension = Path.GetExtension(oc.oProducto.NombreImagen)
                },
                cantidad = oc.cantidad
            }).ToList();

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }   


        [HttpPost]
        public JsonResult OperacionCarrito(int idproducto, bool sumar)
        {
            //De esa forma se obtien el id del cliente del cual a accedido al sistema 
            int idcliente = ((Cliente)Session["Cliente"]).idCliente;

            bool respuesta = false;

            string mensaje = string.Empty;

            respuesta = new CN_Carrito().OperacionCarrito(idcliente, idproducto, true, out mensaje);


            return Json(new { respuesta = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarCarrito(int idproducto)
        {
            int idcliente = ((Cliente)Session["Cliente"]).idCliente;

            bool respuesta = false;

            string mensaje = string.Empty;

            respuesta = new CN_Carrito().EliminarCarrito(idcliente, idproducto);

            return Json(new { respuesta = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public JsonResult ObtenerDepartamento()
        {
            List<Departamento> oLista = new List<Departamento>();

            oLista = new CN_Ubicacion().obtenerDepartamento();

            return Json( new { lista = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObetenrMunicipio( string iddepartamento)
        {
            List<Municipio> oLista = new List<Municipio>();

            oLista = new CN_Ubicacion().obenerMunicipio(iddepartamento);

            return Json(new { lista = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerZona(string idmunicipio, string iddepartamento )
        {
            List<Zona> oLista = new List<Zona>();

            oLista = new CN_Ubicacion().obtenerZona( idmunicipio,iddepartamento);

            return Json(new { lista = oLista }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Carrito()
        {
            return View();
        }

    }


}