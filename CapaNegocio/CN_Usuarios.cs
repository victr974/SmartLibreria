using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuarios
    {
        //Esto nos permite acceder a los metodos 
        private CD_Usuarios objCapaDato = new CD_Usuarios();

        //que nod devuelva una lista de la misma lista de nuestra capa de usuarios 
        public List<UsuarioEmpleado> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(UsuarioEmpleado obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.nombres) || string.IsNullOrWhiteSpace(obj.nombres))
            {
                Mensaje = "El nombre del usuario no puede ser vacio";

            }

            else if (string.IsNullOrEmpty(obj.apellidos) || string.IsNullOrWhiteSpace(obj.apellidos))
            {
                Mensaje = "El apellido  del usuario no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.correo) || string.IsNullOrWhiteSpace(obj.correo))
            {
                Mensaje = "El correo del usuario no puede ser vacio";

            }

            if (string.IsNullOrEmpty(Mensaje))
            {


                string clave = CN_Recursos.GenerarClave();

                string asunto = "Creacion de Cuenta SmartLibreria";
                string mensaje_correo = "<h2> Bienvenido a SmartLibreria</h2> </br><h3> Su cuenta fue creado correctamente</h3> </br> <p> Su contraseña para acceder es : ¡clave!</p>";
                mensaje_correo = mensaje_correo.Replace("¡clave!", clave);

                bool respuesta = CN_Recursos.EnviarCorreo(obj.correo, asunto, mensaje_correo);

                if (respuesta)
                {
                obj.clave = CN_Recursos.ConvertirSHA256(clave);
                return objCapaDato.Registrar(obj, out Mensaje);
                }
                else
                {
                    Mensaje = "No se puede enviar el correo";
                    return 0;
                }

            }

            else
            {
                return  0;
            }
           
        }

        public bool Editar(UsuarioEmpleado obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.nombres) || string.IsNullOrWhiteSpace(obj.nombres))
            {
                Mensaje = "El nombre del usuario no puede ser vacio";

            }

            else if (string.IsNullOrEmpty(obj.apellidos) || string.IsNullOrWhiteSpace(obj.apellidos))
            {
                Mensaje = "El apellido  del usuario no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.correo) || string.IsNullOrWhiteSpace(obj.correo))
            {
                Mensaje = "El correo del usuario no puede ser vacio";

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

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }

        public bool CambiarClave(int idusuario, string nuevaclave, out string Mensaje)
        {
            return objCapaDato.CambiarClave(idusuario, nuevaclave, out Mensaje);
        }


        public bool Reestablecer(int idusuario, string correo, out string Mensaje)
        {
            Mensaje = string.Empty;
            string nuevaclave = CN_Recursos.GenerarClave();

            bool resultado = objCapaDato.Reestablecer(idusuario, CN_Recursos.ConvertirSHA256(nuevaclave), out Mensaje);

            if (resultado)
            {
                string asunto = "Contraseña Restablecido";
                string mensaje_correo = "</br><h3> Su cuenta fue reestablecido correctamente</h3> </br> <p> Su contraseña para acceder es : ¡clave!</p>";
                mensaje_correo = mensaje_correo.Replace("¡clave!", nuevaclave);

                bool respuesta = CN_Recursos.EnviarCorreo(correo, asunto, mensaje_correo);

            if (respuesta)
                {

                    return true;
                }
                else
                {
                    Mensaje = "No se puudo enviar el correo";
                    return false;
                }

            }
            else
            {
                Mensaje = "No se puudo restablecer la contraseña";
                return false;
            }


        }

    }
}
