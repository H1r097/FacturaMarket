using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacturaMarket.Entidades
{
    public class Usuario
    {
        private int iDUsuario;
        private string nombreUsuario;
        private string cedula;
        private string username;
        private string contrasena;
        private string rol;
        private bool estado;

        public Usuario() { }
        public Usuario(int iDUsuario, string nombreUsuario, string cedula, string username, string contrasena, string rol, bool estado)
        {
            this.iDUsuario = iDUsuario;
            this.nombreUsuario = nombreUsuario;
            this.cedula = cedula;
            this.username = username;
            this.contrasena = contrasena;
            this.rol = rol;
            this.estado = estado;
        }

        public int IDUsuario { get => iDUsuario; set => iDUsuario = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Username { get => username; set => username = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public string Rol { get => rol; set => rol = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
