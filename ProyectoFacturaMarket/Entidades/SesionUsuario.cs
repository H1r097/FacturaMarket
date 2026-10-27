using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacturaMarket.Entidades
{
    public static class SesionUsuario
    {
        private static int iDUsuario;
        private static string identificacion;
        private static string nombreUsuario;
        private static string username;
        private static string rol;
        private static DateTime fechaInicioSesion;
        public static bool EsAdmin => Rol != null && Rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
        public static bool EsCajero => Rol != null && Rol.Equals("Cajero", StringComparison.OrdinalIgnoreCase);

        public static int IDUsuario { get => iDUsuario; set => iDUsuario = value; }
        public static string Identificacion { get => identificacion; set => identificacion = value; }
        public static string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public static string Username { get => username; set => username = value; }
        public static string Rol { get => rol; set => rol = value; }
        public static DateTime FechaInicioSesion { get => fechaInicioSesion; set => fechaInicioSesion = value; }
        public static void IniciarSesion(Usuario usuario)
        {
            if (usuario != null)
            {
                IDUsuario = usuario.IDUsuario;
                Identificacion = usuario.Cedula;
                NombreUsuario = usuario.NombreUsuario;
                Username = usuario.Username;
                Rol = usuario.Rol;
                FechaInicioSesion = DateTime.Now;
            }
        }
        public static void CerrarSesion()
        {
            IDUsuario = 0;
            Identificacion = string.Empty;
            NombreUsuario = string.Empty;
            Username = string.Empty;
            Rol = string.Empty;
            FechaInicioSesion = DateTime.MinValue;
        }
    }
}
