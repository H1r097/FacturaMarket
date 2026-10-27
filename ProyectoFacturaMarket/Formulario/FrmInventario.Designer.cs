namespace ProyectoFacturaMarket.Formulario
{
    partial class FrmInventario
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cmbFiltroCategoria;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.Label lblTotalProductos;
        private System.Windows.Forms.Label lblTotalProductosValor;
        private System.Windows.Forms.Label lblStockCritico;
        private System.Windows.Forms.Label lblStockCriticoValor;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cmbFiltroCategoria = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.colIDProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstadoStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTarifaIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalProductos = new System.Windows.Forms.Label();
            this.lblTotalProductosValor = new System.Windows.Forms.Label();
            this.lblStockCritico = new System.Windows.Forms.Label();
            this.lblStockCriticoValor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(24, 26);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(144, 20);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar producto";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(174, 23);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(260, 26);
            this.txtBuscar.TabIndex = 1;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(464, 26);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(73, 20);
            this.lblCategoria.TabIndex = 2;
            this.lblCategoria.Text = "Categoría";
            // 
            // cmbFiltroCategoria
            // 
            this.cmbFiltroCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroCategoria.FormattingEnabled = true;
            this.cmbFiltroCategoria.Location = new System.Drawing.Point(553, 23);
            this.cmbFiltroCategoria.Name = "cmbFiltroCategoria";
            this.cmbFiltroCategoria.Size = new System.Drawing.Size(250, 28);
            this.cmbFiltroCategoria.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(823, 20);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(105, 35);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(943, 20);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(105, 35);
            this.btnRefrescar.TabIndex = 5;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            // 
            // dgvInventario
            // 
            this.dgvInventario.AllowUserToAddRows = false;
            this.dgvInventario.AllowUserToDeleteRows = false;
            this.dgvInventario.AutoGenerateColumns = false;
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIDProducto,
            this.colNombreProducto,
            this.colNombreCategoria,
            this.colPrecioVenta,
            this.colStockActual,
            this.colStockMinimo,
            this.colEstadoStock,
            this.colTarifaIva});
            this.dgvInventario.Location = new System.Drawing.Point(24, 79);
            this.dgvInventario.MultiSelect = false;
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.ReadOnly = true;
            this.dgvInventario.RowHeadersWidth = 62;
            this.dgvInventario.RowTemplate.Height = 28;
            this.dgvInventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventario.Size = new System.Drawing.Size(1024, 420);
            this.dgvInventario.TabIndex = 6;
            // 
            // colIDProducto
            // 
            this.colIDProducto.DataPropertyName = "IDProducto";
            this.colIDProducto.HeaderText = "ID";
            this.colIDProducto.MinimumWidth = 8;
            this.colIDProducto.Name = "colIDProducto";
            this.colIDProducto.ReadOnly = true;
            this.colIDProducto.Width = 60;
            // 
            // colNombreProducto
            // 
            this.colNombreProducto.DataPropertyName = "NombreProducto";
            this.colNombreProducto.HeaderText = "Producto";
            this.colNombreProducto.MinimumWidth = 8;
            this.colNombreProducto.Name = "colNombreProducto";
            this.colNombreProducto.ReadOnly = true;
            this.colNombreProducto.Width = 190;
            // 
            // colNombreCategoria
            // 
            this.colNombreCategoria.DataPropertyName = "NombreCategoria";
            this.colNombreCategoria.HeaderText = "Categoría";
            this.colNombreCategoria.MinimumWidth = 8;
            this.colNombreCategoria.Name = "colNombreCategoria";
            this.colNombreCategoria.ReadOnly = true;
            this.colNombreCategoria.Width = 150;
            // 
            // colPrecioVenta
            // 
            this.colPrecioVenta.DataPropertyName = "PrecioVenta";
            this.colPrecioVenta.HeaderText = "Precio Venta";
            this.colPrecioVenta.MinimumWidth = 8;
            this.colPrecioVenta.Name = "colPrecioVenta";
            this.colPrecioVenta.ReadOnly = true;
            this.colPrecioVenta.Width = 110;
            // 
            // colStockActual
            // 
            this.colStockActual.DataPropertyName = "StockActual";
            this.colStockActual.HeaderText = "Stock Actual";
            this.colStockActual.MinimumWidth = 8;
            this.colStockActual.Name = "colStockActual";
            this.colStockActual.ReadOnly = true;
            this.colStockActual.Width = 110;
            // 
            // colStockMinimo
            // 
            this.colStockMinimo.DataPropertyName = "StockMinimo";
            this.colStockMinimo.HeaderText = "Stock Mínimo";
            this.colStockMinimo.MinimumWidth = 8;
            this.colStockMinimo.Name = "colStockMinimo";
            this.colStockMinimo.ReadOnly = true;
            this.colStockMinimo.Width = 110;
            // 
            // colEstadoStock
            // 
            this.colEstadoStock.DataPropertyName = "EstadoStock";
            this.colEstadoStock.HeaderText = "Estado de Stock";
            this.colEstadoStock.MinimumWidth = 8;
            this.colEstadoStock.Name = "colEstadoStock";
            this.colEstadoStock.ReadOnly = true;
            this.colEstadoStock.Width = 140;
            // 
            // colTarifaIva
            // 
            this.colTarifaIva.DataPropertyName = "TarifaIva";
            this.colTarifaIva.HeaderText = "Tarifa IVA";
            this.colTarifaIva.MinimumWidth = 8;
            this.colTarifaIva.Name = "colTarifaIva";
            this.colTarifaIva.ReadOnly = true;
            this.colTarifaIva.Width = 100;
            // 
            // lblTotalProductos
            // 
            this.lblTotalProductos.AutoSize = true;
            this.lblTotalProductos.Location = new System.Drawing.Point(24, 523);
            this.lblTotalProductos.Name = "lblTotalProductos";
            this.lblTotalProductos.Size = new System.Drawing.Size(217, 20);
            this.lblTotalProductos.TabIndex = 7;
            this.lblTotalProductos.Text = "Productos en inventario:";
            // 
            // lblTotalProductosValor
            // 
            this.lblTotalProductosValor.AutoSize = true;
            this.lblTotalProductosValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProductosValor.Location = new System.Drawing.Point(254, 523);
            this.lblTotalProductosValor.Name = "lblTotalProductosValor";
            this.lblTotalProductosValor.Size = new System.Drawing.Size(17, 18);
            this.lblTotalProductosValor.TabIndex = 8;
            this.lblTotalProductosValor.Text = "0";
            // 
            // lblStockCritico
            // 
            this.lblStockCritico.AutoSize = true;
            this.lblStockCritico.Location = new System.Drawing.Point(407, 523);
            this.lblStockCritico.Name = "lblStockCritico";
            this.lblStockCritico.Size = new System.Drawing.Size(228, 20);
            this.lblStockCritico.TabIndex = 9;
            this.lblStockCritico.Text = "Productos con stock crítico:";
            // 
            // lblStockCriticoValor
            // 
            this.lblStockCriticoValor.AutoSize = true;
            this.lblStockCriticoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockCriticoValor.Location = new System.Drawing.Point(650, 523);
            this.lblStockCriticoValor.Name = "lblStockCriticoValor";
            this.lblStockCriticoValor.Size = new System.Drawing.Size(17, 18);
            this.lblStockCriticoValor.TabIndex = 10;
            this.lblStockCriticoValor.Text = "0";
            // 
            // FrmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 570);
            this.Controls.Add(this.lblStockCriticoValor);
            this.Controls.Add(this.lblStockCritico);
            this.Controls.Add(this.lblTotalProductosValor);
            this.Controls.Add(this.lblTotalProductos);
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cmbFiltroCategoria);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Name = "FrmInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Consulta de inventario";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn colIDProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstadoStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTarifaIva;
    }
}
