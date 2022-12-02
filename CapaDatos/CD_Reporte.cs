using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CapaDatos
{
    public  class CD_Reporte
    {

        public List<Reporte> Ventas(string fechainicio, string fechafin, string idtransaccion )
        {
            List<Reporte> lista = new List<Reporte>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("sp_ReporteVentas", oconexion);
                    cmd.Parameters.AddWithValue("@Fechaini", fechainicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechafin);
                    cmd.Parameters.AddWithValue("@idtransaccion", idtransaccion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            lista.Add(
                                new Reporte()
                                {
                                    FechaVenta = rdr["[fechaVenta]"].ToString(),
                                    Cliente = rdr["[cliente]"].ToString(),
                                    Producto = rdr["producto"].ToString(),
                                    Precio = Convert.ToDecimal(rdr["precio"], new CultureInfo("es-GT")),
                                    Cantidad = Convert.ToInt32( rdr["clave"].ToString()),
                                    Total = Convert.ToDecimal(rdr["precio"], new CultureInfo("es-GT")),
                                    IdTransaccion = rdr["idTransaccion"].ToString()

                                }

                                );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Reporte>();
            }

            return lista;
        }



        public DashBoard VerDashBoard()
        {

            //No va ser una lista va ser un objeto
            DashBoard objeto = new DashBoard();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                        
                    SqlCommand cmd = new SqlCommand("sp_testReporte", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            objeto = new DashBoard()
                            {
                                TotalCliente = Convert.ToInt32(rdr["TotalCliente"]),
                                TotalVenta = Convert.ToInt32(rdr["[TotalVenta]"]),
                                TotalProducto = Convert.ToInt32(rdr["TotalProducto"]),
                            };

                        }
                    }
                }
            }
            catch
            {
                objeto = new DashBoard();
            }

            return objeto;
        }
    }
}
