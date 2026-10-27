using ProyectoFacturaMarket.Controlador;
using ProyectoFacturaMarket.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoFacturaMarket.Formulario
{
    public partial class FrmInventario : Form
    {
        private readonly ProductoDB productoDB = new ProductoDB();
        private readonly CategoriaBD categoriaBD = new CategoriaBD();
        private List<Producto> productos = new List<Producto>();

        public FrmInventario()
        {
            InitializeComponent();
            Load += FrmInventario_Load;
            txtBuscar.TextChanged += Filtros_Changed;
            cmbFiltroCategoria.SelectedIndexChanged += Filtros_Changed;
            btnBuscar.Click += BtnBuscar_Click;
            btnRefrescar.Click += BtnRefrescar_Click;
            dgvInventario.CellFormatting += DgvInventario_CellFormatting;
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                List<Categoria> categorias = categoriaBD.ListarCategorias();
                categorias.Insert(0, new Categoria { IDCategoria = 0, NombreCategoria = "Todas las categorías", Estado = true });
                cmbFiltroCategoria.DataSource = null;
                cmbFiltroCategoria.DisplayMember = "NombreCategoria";
                cmbFiltroCategoria.ValueMember = "IDCategoria";
                cmbFiltroCategoria.DataSource = categorias;
                cmbFiltroCategoria.SelectedValue = 0;

                productos = productoDB.ListarProductos();
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible cargar el inventario:\r\n" + ex.Message,
                    "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Filtros_Changed(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void AplicarFiltros()
        {
            string texto = txtBuscar.Text.Trim();
            int idCategoria = 0;
            if (cmbFiltroCategoria.SelectedValue != null && !(cmbFiltroCategoria.SelectedValue is Categoria))
                int.TryParse(Convert.ToString(cmbFiltroCategoria.SelectedValue), out idCategoria);

            List<ProductoFila> filas = productos
                .Where(p => string.IsNullOrEmpty(texto) || p.NombreProducto.IndexOf(texto, StringComparison.CurrentCultureIgnoreCase) >= 0)
                .Where(p => idCategoria == 0 || p.IDCategoria == idCategoria)
                .Select(p => new ProductoFila
                {
                    IDProducto = p.IDProducto,
                    IDCategoria = p.IDCategoria,
                    NombreProducto = p.NombreProducto,
                    NombreCategoria = p.Categoria == null ? string.Empty : p.Categoria.NombreCategoria,
                    PrecioVenta = p.PrecioVenta,
                    StockActual = p.StockActual,
                    StockMinimo = p.StockMinimo,
                    EstadoStock = ObtenerEstadoStock(p.StockActual, p.StockMinimo),
                    TarifaIva = p.AplicaIva ? "15%" : "0%"
                })
                .ToList();

            dgvInventario.DataSource = null;
            dgvInventario.DataSource = filas;
            lblTotalProductosValor.Text = filas.Count.ToString();
            lblStockCriticoValor.Text = filas.Count(p => p.StockActual <= p.StockMinimo).ToString();
        }

        private void DgvInventario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvInventario.Rows.Count)
                return;

            ProductoFila fila = dgvInventario.Rows[e.RowIndex].DataBoundItem as ProductoFila;
            if (fila == null)
                return;

            DataGridViewRow row = dgvInventario.Rows[e.RowIndex];
            if (fila.StockActual == 0)
            {
                row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
                row.DefaultCellStyle.ForeColor = System.Drawing.Color.DarkRed;
            }
            else if (fila.StockActual <= fila.StockMinimo)
            {
                row.DefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon;
                row.DefaultCellStyle.ForeColor = System.Drawing.Color.DarkGoldenrod;
            }
            else
            {
                row.DefaultCellStyle.BackColor = dgvInventario.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.ForeColor = dgvInventario.DefaultCellStyle.ForeColor;
            }
        }

        private static string ObtenerEstadoStock(decimal stockActual, decimal stockMinimo)
        {
            if (stockActual == 0)
                return "AGOTADO";
            if (stockActual <= stockMinimo)
                return "STOCK BAJO";
            return "NORMAL";
        }

        private sealed class ProductoFila
        {
            public int IDProducto { get; set; }
            public int IDCategoria { get; set; }
            public string NombreProducto { get; set; }
            public string NombreCategoria { get; set; }
            public decimal PrecioVenta { get; set; }
            public decimal StockActual { get; set; }
            public decimal StockMinimo { get; set; }
            public string EstadoStock { get; set; }
            public string TarifaIva { get; set; }
        }
    }
}
