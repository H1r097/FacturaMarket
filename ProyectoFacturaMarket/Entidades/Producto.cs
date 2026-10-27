using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacturaMarket.Entidades
{
   public class Producto
    {
        private int iDProducto;
        private string nombreProducto;
        private int iDCategoria;
        private Categoria categoria;
        private decimal precioCosto;
        private decimal precioVenta;
        private decimal stockMinimo;
        private decimal stockActual;
        private bool aplicaIva;
        private bool estado;
        public Producto() { }

        public Producto(int iDProducto, string nombreProducto, int iDCategoria, Categoria categoria, decimal precioCosto, decimal precioVenta, decimal stockMinimo, decimal stockActual, bool aplicaIva, bool estado)
        {
            this.iDProducto = iDProducto;
            this.nombreProducto = nombreProducto;
            this.iDCategoria = iDCategoria;
            this.categoria = categoria;
            this.precioCosto = precioCosto;
            this.precioVenta = precioVenta;
            this.stockMinimo = stockMinimo;
            this.stockActual = stockActual;
            this.aplicaIva = aplicaIva;
            this.estado = estado;
        }

        public int IDProducto { get => iDProducto; set => iDProducto = value; }
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }
        public int IDCategoria { get => iDCategoria; set => iDCategoria = value; }
        public Categoria Categoria { get => categoria; set => categoria = value; }
        public decimal PrecioCosto { get => precioCosto; set => precioCosto = value; }
        public decimal PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public decimal StockMinimo { get => stockMinimo; set => stockMinimo = value; }
        public decimal StockActual { get => stockActual; set => stockActual = value; }
        public bool AplicaIva { get => aplicaIva; set => aplicaIva = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
