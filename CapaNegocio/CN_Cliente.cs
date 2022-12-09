using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Cliente
    {

        //Esto nos permite acceder a los metodos 
        private CD_Cliente objCapaDato = new CD_Cliente();


        public int Registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.nombres) || string.IsNullOrWhiteSpace(obj.nombres))
            {
                Mensaje = "El nombre del cliente no puede ser vacio";

            }

            else if (string.IsNullOrEmpty(obj.apellidos) || string.IsNullOrWhiteSpace(obj.apellidos))
            {
                Mensaje = "El apellido  del cliente no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.correo) || string.IsNullOrWhiteSpace(obj.correo))
            {
                Mensaje = "El correo del cliente no puede ser vacio";

            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                
                    obj.clave = CN_Recursos.ConvertirSHA256(obj.clave);
                    return objCapaDato.Registrar(obj, out Mensaje);

            }

            else
            {
                return 0;
            }

        }



        //que nod devuelva una lista de la misma lista de nuestra capa de usuarios 
        public List<Cliente> Listar()
        {
            return objCapaDato.Listar();
        }


        public bool CambiarClave(int idcliente, string nuevaclave, out string Mensaje)
        {
            return objCapaDato.CambiarClave(idcliente, nuevaclave, out Mensaje);
        }


        public bool ReestablecerClave(int idcliente, string correo, out string Mensaje)
        {
            Mensaje = string.Empty;
            string nuevaclave = CN_Recursos.GenerarClave();

            bool resultado = objCapaDato.ReestablecerClave(idcliente, CN_Recursos.ConvertirSHA256(nuevaclave), out Mensaje);

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

