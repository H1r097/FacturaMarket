using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoFacturaMarket.Controlador
{
    public class Conexion
    {
        private readonly string cadenaConexion = "Data Source=.;Initial Catalog=MinisuperDB;Integrated Security=True;TrustServerCertificate=True;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
