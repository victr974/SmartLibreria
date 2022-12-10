using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class CN_Ubicacion
    {
        private CD_Ubicacion objCapaDato = new CD_Ubicacion();

        public List<Departamento> obtenerDepartamento()
        {
            return objCapaDato.obtenerDepartamento();
        }

        public List<Municipio> obenerMunicipio(string iddepartamento)
        {
            return objCapaDato.obenerMunicipio(iddepartamento);
        }

        public List<Zona> obtenerZona(string idmunicipio, string iddepartamento)
        {
            return objCapaDato.obtenerZona(idmunicipio, iddepartamento);
        }
    }
}
