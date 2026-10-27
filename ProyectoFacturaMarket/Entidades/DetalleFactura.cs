using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacturaMarket.Entidades
{
    public class DetalleFactura
    {
        private int iDDetalleFactura;
        private int iDFactura;
        private int iDProducto;
        private Producto producto;
        private string descripcion;
        private decimal cantidad;
        private decimal precioUnitario;
        private bool aplicaIva;
        public DetalleFactura() { }
        public decimal SubtotalLinea => cantidad * precioUnitario;

        public int IDDetalleFactura { get => iDDetalleFactura; set => iDDetalleFactura = value; }
        public int IDFactura { get => iDFactura; set => iDFactura = value; }
        public int IDProducto { get => iDProducto; set => iDProducto = value; }
        public Producto Producto { get => producto; set => producto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Cantidad { get => cantidad; set => cantidad = value; }
        public decimal PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public bool AplicaIva { get => aplicaIva; set => aplicaIva = value; }

        public DetalleFactura( int iDProducto, string descripcion, decimal cantidad, decimal precioUnitario, bool aplicaIva)
        {
            this.iDProducto = iDProducto;
            this.descripcion = descripcion;
            this.cantidad = cantidad;
            this.precioUnitario = precioUnitario;
            this.aplicaIva = aplicaIva;
        }
        public DetalleFactura(Producto producto,decimal cantidad)
        {
            if (producto != null)
            {
                iDProducto = producto.IDProducto;
                this.producto = producto;
                descripcion = producto.NombreProducto;
                precioUnitario = producto.PrecioVenta;
                aplicaIva = producto.AplicaIva;
            }
            this.cantidad = cantidad;
        }
    }
}
