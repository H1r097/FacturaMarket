using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacturaMarket.Entidades
{
    public class Cliente
    {
        private int iDCliente;
        private string identificacion;
        private string tipoIdentificacion;
        private string nombreCliente;
        private string apellidoCliente;
        private string direccion;
        private string telefono;
        public Cliente()
        {
        }
        public Cliente(int iDCliente, string identificacion, string tipoIdentificacion, string nombreCliente, string apellidoCliente, string direccion, string telefono)
        {
            this.iDCliente = iDCliente;
            this.identificacion = identificacion;
            this.tipoIdentificacion = tipoIdentificacion;
            this.nombreCliente = nombreCliente;
            this.apellidoCliente = apellidoCliente;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        public int IDCliente { get => iDCliente; set => iDCliente = value; }
        public string Identificacion { get => identificacion; set => identificacion = value; }
        public string TipoIdentificacion { get => tipoIdentificacion; set => tipoIdentificacion = value; }
        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string ApellidoCliente { get => apellidoCliente; set => apellidoCliente = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
