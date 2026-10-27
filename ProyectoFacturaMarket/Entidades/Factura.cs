using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacturaMarket.Entidades
{
    public class Factura
    {
        private int iDFactura;
        private string numeroFactura;
        private DateTime fechaFactura;
        private int idCliente;
        private Cliente cliente;
        private int idUsuario;
        private Usuario usuario;
        private decimal subtotal0;
        private decimal subtotal15;
        private decimal descuento;
        private decimal totalIva;
        private decimal totalPagar;
        private List<DetalleFactura> detalles;

        public Factura()
        {
            detalles = new List<DetalleFactura>();
            fechaFactura = DateTime.Now;
        }
        public Factura(int iDFactura, string numeroFactura, DateTime fechaFactura, int idCliente, Cliente cliente, int idUsuario, Usuario usuario, decimal subtotal0, decimal subtotal15, decimal descuento, decimal totalIva, decimal totalPagar)
        {
            this.iDFactura = iDFactura;
            this.numeroFactura = numeroFactura;
            this.fechaFactura = fechaFactura;
            this.idCliente = idCliente;
            this.cliente = cliente;
            this.idUsuario = idUsuario;
            this.usuario = usuario;
            this.subtotal0 = subtotal0;
            this.subtotal15 = subtotal15;
            this.descuento = descuento;
            this.totalIva = totalIva;
            this.totalPagar = totalPagar;
            this.detalles = new List<DetalleFactura>();
        }

        public int IDFactura { get => iDFactura; set => iDFactura = value; }
        public string NumeroFactura { get => numeroFactura; set => numeroFactura = value; }
        public DateTime FechaFactura { get => fechaFactura; set => fechaFactura = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public Usuario Usuario { get => usuario; set => usuario = value; }
        public decimal Subtotal0 { get => subtotal0; set => subtotal0 = value; }
        public decimal Subtotal15 { get => subtotal15; set => subtotal15 = value; }
        public decimal Descuento { get => descuento; set => descuento = value; }
        public decimal TotalIva { get => totalIva; set => totalIva = value; }
        public decimal TotalPagar { get => totalPagar; set => totalPagar = value; }
        public List<DetalleFactura> Detalles { get => detalles; set => detalles = value; }
    }
}
