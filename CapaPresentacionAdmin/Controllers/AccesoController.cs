using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CambiarClave()
        {
            return View();
        }

        public ActionResult Reestablecer()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index( string correo, string clave)
        {
            UsuarioEmpleado oUsuario = new UsuarioEmpleado();

            oUsuario = new CN_Usuarios().Listar().Where(u => u.correo == correo && u.clave == CN_Recursos.ConvertirSHA256(clave)).FirstOrDefault();

            if(oUsuario == null)
            {
                ViewBag.Error = "Correo o contraseña no es correcto";
            }
            else
            {
                ViewBag.Error = null;

                return RedirectToAction("Index", "Home");
            }




            return View();
        }

    }
}