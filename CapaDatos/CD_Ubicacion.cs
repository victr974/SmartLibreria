using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data.SqlClient;
using System.Data;


namespace CapaDatos
{
    public class CD_Ubicacion
    {
        public List<Departamento> obtenerDepartamento()
        {
            List<Departamento> lista =  new List<Departamento>();

            try
            {
                SqlConnection oconexion = new SqlConnection(Conexion.cn);
                string query = "select *from Departamento";

                SqlCommand cmd = new SqlCommand( query, oconexion);
                cmd.CommandType = CommandType.Text;

                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(
                        new Departamento()
                        {
                            idDepartamento = dr["idDepartamento"].ToString(),
                            nombre = dr["nombre"].ToString(),

                        });

                    }

                }
            }
            catch(Exception ex)
            {
                lista = new List<Departamento>();
            }
            return lista;
        }


        public List<Municipio> obenerMunicipio( string iddepartamento)
        {
            List<Municipio> lista = new List<Municipio>();

            try
            {
                SqlConnection oconexion = new SqlConnection(Conexion.cn);
                string query = "select *from Municipio where idDepartamento = @iddepartamento";

                SqlCommand cmd = new SqlCommand(query, oconexion);
                cmd.Parameters.AddWithValue("@iddepartamento", iddepartamento);
                cmd.CommandType = CommandType.Text;

                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(
                        new Municipio()
                        {
                            idMunicipio = dr["idMunicipio"].ToString(),
                            nombre = dr["nombre"].ToString(),

                        });

                    }

                }
            }
            catch (Exception ex)
            {
                lista = new List<Municipio>();
            }
            return lista;
        }


        public List<Zona> obtenerZona(string idmunicipio, string iddepartamento)
        {
            List<Zona> lista = new List<Zona>();

            try
            {
                SqlConnection oconexion = new SqlConnection(Conexion.cn);
                string query = "select * from Zona where IdMunicipio = @idmunicipio and idDepartamento = @iddepartamento";

                SqlCommand cmd = new SqlCommand(query, oconexion);
                cmd.Parameters.AddWithValue("@idmunicipio", idmunicipio);
                cmd.Parameters.AddWithValue("@iddepartamento", iddepartamento);
                cmd.CommandType = CommandType.Text;

                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(
                        new Zona()
                        {
                            idZona = dr["idZona"].ToString(),
                            nombre = dr["nombre"].ToString(),

                        });

                    }

                }
            }
            catch (Exception ex)
            {
                lista = new List<Zona>();
            }
            return lista;
        }



    }
}
