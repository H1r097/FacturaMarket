using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacturaMarket.Entidades
{
    public class Categoria
    {
        private int iDCategoria;
        private string nombreCategoria;
        private bool estado;
        public Categoria() { }

        public Categoria(int iDCategoria, string nombreCategoria, bool estado)
        {
            this.iDCategoria = iDCategoria;
            this.nombreCategoria = nombreCategoria;
            this.estado = estado;
        }

        public int IDCategoria { get => iDCategoria; set => iDCategoria = value; }
        public string NombreCategoria { get => nombreCategoria; set => nombreCategoria = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
