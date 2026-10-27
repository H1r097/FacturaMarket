using ProyectoFacturaMarket.Controlador;
using ProyectoFacturaMarket.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoFacturaMarket.Formulario
{
    public partial class Principal : Form
    {
        private const decimal TarifaIva = 0.15m;
        private readonly ClienteBD clienteBD = new ClienteBD();
        private readonly ProductoDB productoDB = new ProductoDB();
        private readonly FacturaBD facturaBD = new FacturaBD();
        private readonly List<DetalleFactura> detalles = new List<DetalleFactura>();
        private List<Producto> productos = new List<Producto>();
        private Cliente clienteActual;
        private Producto productoSeleccionado;
        private bool actualizandoCliente;

        public Principal()
        {
            InitializeComponent();
            Load += Principal_Load;
            inicioToolStripMenuItem.Click += FacturacionToolStripMenuItem_Click;
            productosToolStripMenuItem.Click += ProductosToolStripMenuItem_Click;
            categoriasToolStripMenuItem.Click += CategoriasToolStripMenuItem_Click;
            inventarioToolStripMenuItem.Click += InventarioToolStripMenuItem_Click;
            clientesToolStripMenuItem.Click += ModuloPendienteToolStripMenuItem_Click;
            usuariosToolStripMenuItem.Click += ModuloPendienteToolStripMenuItem_Click;
            cerrarSesionToolStripMenuItem.Click += CerrarSesionToolStripMenuItem_Click;
            button1.Click += BuscarCliente_Click;
            button2.Click += BuscarProducto_Click;
            button3.Click += AgregarProducto_Click;
            button4.Click += LimpiarFactura_Click;
            button5.Click += GuardarFactura_Click;
            button7.Click += QuitarProducto_Click;
            dataGridView1.SelectionChanged += ProductoSeleccionado_Changed;
            textBox4.TextChanged += BuscarProducto_TextChanged;
            textBox7.TextChanged += Descuento_TextChanged;
            radioButton2.CheckedChanged += ConsumidorFinal_CheckedChanged;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns.Add("colProductoNombre", "Producto");
            dataGridView1.Columns[0].DataPropertyName = "NombreProducto";
            dataGridView1.Columns.Add("colProductoCategoria", "Categoría");
            dataGridView1.Columns[1].DataPropertyName = "NombreCategoria";
            dataGridView1.Columns.Add("colProductoPrecio", "Precio");
            dataGridView1.Columns[2].DataPropertyName = "PrecioVenta";
            dataGridView1.Columns.Add("colProductoStock", "Stock");
            dataGridView1.Columns[3].DataPropertyName = "StockActual";

            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.MultiSelect = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            numericUpDown1.DecimalPlaces = 3;
            numericUpDown1.Increment = 0.001m;
            numericUpDown1.Minimum = 0.001m;
            numericUpDown1.Maximum = 1000000m;
            numericUpDown1.Value = 1m;
            textBox5.ReadOnly = true;
            actualizandoCliente = true;
            radioButton2.Checked = true;
            actualizandoCliente = false;
            textBox7.Text = "0.00";
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            Text = "FacturaMarket - Punto de Venta | Usuario: " + SesionUsuario.NombreUsuario + " (" + SesionUsuario.Rol + ")";
            bool esAdministrador = SesionUsuario.EsAdmin;
            usuariosToolStripMenuItem.Visible = esAdministrador;
            categoriasToolStripMenuItem.Visible = esAdministrador;

            try
            {
                CargarConsumidorFinal();
                CargarProductos();
                CalcularTotales();
            }
            catch (Exception ex)
            {
                MostrarError("iniciar la facturación", ex);
            }
        }

        private void CargarConsumidorFinal()
        {
            actualizandoCliente = true;
            try
            {
                clienteActual = clienteBD.ObtenerConsumidorFinal();
                MostrarCliente(clienteActual);
                radioButton2.Checked = true;
            }
            finally
            {
                actualizandoCliente = false;
            }
        }

        private void MostrarCliente(Cliente cliente)
        {
            clienteActual = cliente;
            textBox1.Text = cliente == null ? string.Empty : cliente.Identificacion;
            textBox2.Text = cliente == null ? string.Empty : cliente.NombreCliente;
            textBox3.Text = cliente == null ? string.Empty : cliente.ApellidoCliente;
        }

        private void BuscarCliente_Click(object sender, EventArgs e)
        {
            string identificacion = textBox1.Text.Trim();
            if (identificacion.Length == 0)
            {
                MessageBox.Show("Ingrese la identificación del cliente.", "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            try
            {
                Cliente cliente = clienteBD.BuscarPorIdentificacion(identificacion);
                if (cliente != null)
                {
                    MostrarCliente(cliente);
                    return;
                }

                DialogResult registrar = MessageBox.Show(
                    "No existe un cliente con esa identificación. ¿Desea registrarlo con los nombres y apellidos ingresados?",
                    "Registrar cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (registrar != DialogResult.Yes)
                    return;

                if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Para registrar al cliente, complete nombres y apellidos.", "Datos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Cliente nuevo = new Cliente
                {
                    Identificacion = identificacion,
                    TipoIdentificacion = radioButton1.Checked ? "RUC" : "Identificación",
                    NombreCliente = textBox2.Text.Trim(),
                    ApellidoCliente = textBox3.Text.Trim(),
                    Direccion = string.Empty,
                    Telefono = string.Empty
                };
                nuevo.IDCliente = clienteBD.InsertarCliente(nuevo);
                MostrarCliente(nuevo);
                MessageBox.Show("El cliente fue registrado y asignado a la factura.", "Cliente registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarError("buscar o registrar el cliente", ex);
            }
        }

        private void ConsumidorFinal_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton2.Checked || actualizandoCliente)
                return;

            try
            {
                MostrarCliente(clienteBD.ObtenerConsumidorFinal());
            }
            catch (Exception ex)
            {
                MostrarError("cargar el cliente Consumidor Final", ex);
            }
        }

        private void CargarProductos()
        {
            productos = productoDB.ListarProductos();
            AplicarFiltroProductos();
        }

        private void BuscarProducto_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroProductos();
        }

        private void BuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                CargarProductos();
            }
            catch (Exception ex)
            {
                MostrarError("buscar productos", ex);
            }
        }

        private void AplicarFiltroProductos()
        {
            string texto = textBox4.Text.Trim();
            var filas = productos
                .Where(p => string.IsNullOrEmpty(texto) || p.NombreProducto.IndexOf(texto, StringComparison.CurrentCultureIgnoreCase) >= 0)
                .Select(p => new ProductoDisponible
                {
                    Producto = p,
                    NombreProducto = p.NombreProducto,
                    NombreCategoria = p.Categoria == null ? string.Empty : p.Categoria.NombreCategoria,
                    PrecioVenta = p.PrecioVenta,
                    StockActual = p.StockActual
                })
                .ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filas;
            dataGridView1.ClearSelection();
            productoSeleccionado = null;
            textBox5.Clear();
        }

        private void ProductoSeleccionado_Changed(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            ProductoDisponible fila = dataGridView1.SelectedRows[0].DataBoundItem as ProductoDisponible;
            if (fila == null)
                return;

            productoSeleccionado = fila.Producto;
            textBox5.Text = productoSeleccionado.PrecioVenta.ToString("N2", CultureInfo.CurrentCulture);
        }

        private void AgregarProducto_Click(object sender, EventArgs e)
        {
            if (productoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un producto del inventario.", "Producto requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal cantidad = numericUpDown1.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero.", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DetalleFactura existente = detalles.FirstOrDefault(d => d.IDProducto == productoSeleccionado.IDProducto);
            decimal cantidadActual = existente == null ? 0 : existente.Cantidad;
            decimal cantidadSolicitada = cantidadActual + cantidad;
            if (cantidadSolicitada > productoSeleccionado.StockActual)
            {
                decimal disponible = productoSeleccionado.StockActual - cantidadActual;
                MessageBox.Show("Stock máximo disponible para agregar: " + Math.Max(0, disponible).ToString("N3", CultureInfo.CurrentCulture),
                    "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (existente == null)
            {
                detalles.Add(new DetalleFactura(productoSeleccionado, cantidad));
            }
            else
            {
                existente.Cantidad = cantidadSolicitada;
            }

            ActualizarGrillaDetalle();
            CalcularTotales();
        }

        private void ActualizarGrillaDetalle()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = detalles.Select(d => new DetalleFila
            {
                IDProducto = d.IDProducto,
                Producto = d.Descripcion,
                Cantidad = d.Cantidad,
                PrecioUnitario = d.PrecioUnitario,
                SubtotalLinea = d.SubtotalLinea,
                Impuesto = d.AplicaIva ? "15%" : "0%"
            }).ToList();
        }

        private void QuitarProducto_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una línea de la factura para quitar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DetalleFila fila = dataGridView2.SelectedRows[0].DataBoundItem as DetalleFila;
            if (fila == null)
                return;

            detalles.RemoveAll(d => d.IDProducto == fila.IDProducto);
            ActualizarGrillaDetalle();
            CalcularTotales();
        }

        private void Descuento_TextChanged(object sender, EventArgs e)
        {
            CalcularTotales();
        }

        private void CalcularTotales()
        {
            decimal subtotal0 = detalles.Where(d => !d.AplicaIva).Sum(d => d.SubtotalLinea);
            decimal subtotal15 = detalles.Where(d => d.AplicaIva).Sum(d => d.SubtotalLinea);
            subtotal0 = Math.Round(subtotal0, 2, MidpointRounding.AwayFromZero);
            subtotal15 = Math.Round(subtotal15, 2, MidpointRounding.AwayFromZero);
            decimal iva = Math.Round(subtotal15 * TarifaIva, 2, MidpointRounding.AwayFromZero);
            decimal descuento;
            decimal totalAntesDescuento = subtotal0 + subtotal15 + iva;

            textBox6.Text = (subtotal0 + subtotal15).ToString("N2", CultureInfo.CurrentCulture);
            textBox8.Text = iva.ToString("N2", CultureInfo.CurrentCulture);
            if (string.IsNullOrWhiteSpace(textBox7.Text))
                descuento = 0;
            else if (!decimal.TryParse(textBox7.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out descuento) || descuento < 0 || descuento > totalAntesDescuento)
            {
                textBox9.Text = "--";
                return;
            }

            descuento = Math.Round(descuento, 2, MidpointRounding.AwayFromZero);
            textBox9.Text = (totalAntesDescuento - descuento).ToString("N2", CultureInfo.CurrentCulture);
        }

        private void LimpiarFactura_Click(object sender, EventArgs e)
        {
            detalles.Clear();
            ActualizarGrillaDetalle();
            textBox7.Text = "0.00";
            textBox4.Clear();
            numericUpDown1.Value = 1m;
            productoSeleccionado = null;
            textBox5.Clear();

            try
            {
                CargarConsumidorFinal();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MostrarError("preparar una nueva factura", ex);
            }

            CalcularTotales();
        }

        private void GuardarFactura_Click(object sender, EventArgs e)
        {
            if (clienteActual == null || clienteActual.IDCliente <= 0)
            {
                MessageBox.Show("Busque o seleccione un cliente antes de guardar la factura.", "Cliente requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (detalles.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto a la factura.", "Factura vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (SesionUsuario.IDUsuario <= 0)
            {
                MessageBox.Show("No hay un usuario válido en la sesión actual.", "Sesión inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal descuento;
            decimal subtotal0 = Math.Round(detalles.Where(d => !d.AplicaIva).Sum(d => d.SubtotalLinea), 2, MidpointRounding.AwayFromZero);
            decimal subtotal15 = Math.Round(detalles.Where(d => d.AplicaIva).Sum(d => d.SubtotalLinea), 2, MidpointRounding.AwayFromZero);
            decimal iva = Math.Round(subtotal15 * TarifaIva, 2, MidpointRounding.AwayFromZero);
            decimal totalAntesDescuento = subtotal0 + subtotal15 + iva;
            if (!decimal.TryParse(textBox7.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out descuento) ||
                descuento < 0 || descuento > totalAntesDescuento)
            {
                MessageBox.Show("Revise el descuento; debe ser un importe válido y no superar el total.", "Descuento inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox7.Focus();
                return;
            }
            descuento = Math.Round(descuento, 2, MidpointRounding.AwayFromZero);

            try
            {
                Factura factura = new Factura
                {
                    NumeroFactura = facturaBD.ObtenerSiguienteNumeroFactura(),
                    FechaFactura = DateTime.Now,
                    IdCliente = clienteActual.IDCliente,
                    Cliente = clienteActual,
                    IdUsuario = SesionUsuario.IDUsuario,
                    Subtotal0 = subtotal0,
                    Subtotal15 = subtotal15,
                    Descuento = descuento,
                    TotalIva = iva,
                    TotalPagar = totalAntesDescuento - descuento,
                    Detalles = new List<DetalleFactura>(detalles)
                };

                facturaBD.RegistrarFactura(factura, factura.Detalles);
                MessageBox.Show("La factura " + factura.NumeroFactura + " se registró correctamente.",
                    "Venta registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFactura_Click(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MostrarError("registrar la factura", ex);
            }
        }

        private void FacturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ya se encuentra en el módulo de facturación.", "Facturación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FrmProductos formulario = new FrmProductos())
                formulario.ShowDialog(this);
            CargarProductosSeguro();
        }

        private void CategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FrmCategorias formulario = new FrmCategorias())
                formulario.ShowDialog(this);
            CargarProductosSeguro();
        }

        private void InventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FrmInventario formulario = new FrmInventario())
                formulario.ShowDialog(this);
            CargarProductosSeguro();
        }

        private void CargarProductosSeguro()
        {
            try
            {
                CargarProductos();
            }
            catch (Exception ex)
            {
                MostrarError("actualizar el inventario", ex);
            }
        }

        private void ModuloPendienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            string nombreModulo = item == null ? "seleccionado" : item.Text;
            MessageBox.Show("El módulo " + nombreModulo + " estará disponible en una etapa posterior.", "Módulo pendiente", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SesionUsuario.CerrarSesion();
            Close();
        }

        private static void MostrarError(string operacion, Exception ex)
        {
            MessageBox.Show("No fue posible " + operacion + ":\r\n" + ex.Message,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private sealed class ProductoDisponible
        {
            public Producto Producto { get; set; }
            public string NombreProducto { get; set; }
            public string NombreCategoria { get; set; }
            public decimal PrecioVenta { get; set; }
            public decimal StockActual { get; set; }
        }

        private sealed class DetalleFila
        {
            public int IDProducto { get; set; }
            public string Producto { get; set; }
            public decimal Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
            public decimal SubtotalLinea { get; set; }
            public string Impuesto { get; set; }
        }
    }
}
