namespace ProyectoFacturaMarket.Formulario
{
    partial class FrmProductos
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblPrecioCosto;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.Label lblStockActual;
        private System.Windows.Forms.Label lblStockMinimo;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.TextBox txtPrecioCosto;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.TextBox txtStockActual;
        private System.Windows.Forms.TextBox txtStockMinimo;
        private System.Windows.Forms.CheckBox chkAplicaIva;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblPrecioCosto = new System.Windows.Forms.Label();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.lblStockActual = new System.Windows.Forms.Label();
            this.lblStockMinimo = new System.Windows.Forms.Label();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.txtPrecioCosto = new System.Windows.Forms.TextBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.txtStockActual = new System.Windows.Forms.TextBox();
            this.txtStockMinimo = new System.Windows.Forms.TextBox();
            this.chkAplicaIva = new System.Windows.Forms.CheckBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.colIDProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAplicaIva = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.Location = new System.Drawing.Point(24, 22);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(135, 20);
            this.lblNombreProducto.TabIndex = 0;
            this.lblNombreProducto.Text = "Nombre producto";
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(172, 19);
            this.txtNombreProducto.MaxLength = 150;
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(300, 26);
            this.txtNombreProducto.TabIndex = 1;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(511, 22);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(73, 20);
            this.lblCategoria.TabIndex = 2;
            this.lblCategoria.Text = "Categoría";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(600, 19);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(330, 28);
            this.cmbCategoria.TabIndex = 3;
            // 
            // lblPrecioCosto
            // 
            this.lblPrecioCosto.AutoSize = true;
            this.lblPrecioCosto.Location = new System.Drawing.Point(24, 68);
            this.lblPrecioCosto.Name = "lblPrecioCosto";
            this.lblPrecioCosto.Size = new System.Drawing.Size(89, 20);
            this.lblPrecioCosto.TabIndex = 4;
            this.lblPrecioCosto.Text = "Precio costo";
            // 
            // txtPrecioCosto
            // 
            this.txtPrecioCosto.Location = new System.Drawing.Point(172, 65);
            this.txtPrecioCosto.Name = "txtPrecioCosto";
            this.txtPrecioCosto.Size = new System.Drawing.Size(120, 26);
            this.txtPrecioCosto.TabIndex = 5;
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Location = new System.Drawing.Point(321, 68);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(91, 20);
            this.lblPrecioVenta.TabIndex = 6;
            this.lblPrecioVenta.Text = "Precio venta";
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(430, 65);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(120, 26);
            this.txtPrecioVenta.TabIndex = 7;
            // 
            // lblStockActual
            // 
            this.lblStockActual.AutoSize = true;
            this.lblStockActual.Location = new System.Drawing.Point(575, 68);
            this.lblStockActual.Name = "lblStockActual";
            this.lblStockActual.Size = new System.Drawing.Size(89, 20);
            this.lblStockActual.TabIndex = 8;
            this.lblStockActual.Text = "Stock actual";
            // 
            // txtStockActual
            // 
            this.txtStockActual.Location = new System.Drawing.Point(680, 65);
            this.txtStockActual.Name = "txtStockActual";
            this.txtStockActual.Size = new System.Drawing.Size(100, 26);
            this.txtStockActual.TabIndex = 9;
            // 
            // lblStockMinimo
            // 
            this.lblStockMinimo.AutoSize = true;
            this.lblStockMinimo.Location = new System.Drawing.Point(799, 68);
            this.lblStockMinimo.Name = "lblStockMinimo";
            this.lblStockMinimo.Size = new System.Drawing.Size(94, 20);
            this.lblStockMinimo.TabIndex = 10;
            this.lblStockMinimo.Text = "Stock mínimo";
            // 
            // txtStockMinimo
            // 
            this.txtStockMinimo.Location = new System.Drawing.Point(903, 65);
            this.txtStockMinimo.Name = "txtStockMinimo";
            this.txtStockMinimo.Size = new System.Drawing.Size(100, 26);
            this.txtStockMinimo.TabIndex = 11;
            // 
            // chkAplicaIva
            // 
            this.chkAplicaIva.AutoSize = true;
            this.chkAplicaIva.Location = new System.Drawing.Point(28, 111);
            this.chkAplicaIva.Name = "chkAplicaIva";
            this.chkAplicaIva.Size = new System.Drawing.Size(149, 24);
            this.chkAplicaIva.TabIndex = 12;
            this.chkAplicaIva.Text = "Aplica IVA 15%";
            this.chkAplicaIva.UseVisualStyleBackColor = true;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AutoGenerateColumns = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIDProducto,
            this.colNombreProducto,
            this.colNombreCategoria,
            this.colPrecioCosto,
            this.colPrecioVenta,
            this.colStockActual,
            this.colStockMinimo,
            this.colAplicaIva});
            this.dgvProductos.Location = new System.Drawing.Point(24, 201);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersWidth = 62;
            this.dgvProductos.RowTemplate.Height = 28;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(980, 365);
            this.dgvProductos.TabIndex = 17;
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
            this.colNombreProducto.Width = 170;
            // 
            // colNombreCategoria
            // 
            this.colNombreCategoria.DataPropertyName = "NombreCategoria";
            this.colNombreCategoria.HeaderText = "Categoría";
            this.colNombreCategoria.MinimumWidth = 8;
            this.colNombreCategoria.Name = "colNombreCategoria";
            this.colNombreCategoria.ReadOnly = true;
            this.colNombreCategoria.Width = 130;
            // 
            // colPrecioCosto
            // 
            this.colPrecioCosto.DataPropertyName = "PrecioCosto";
            this.colPrecioCosto.HeaderText = "Costo";
            this.colPrecioCosto.MinimumWidth = 8;
            this.colPrecioCosto.Name = "colPrecioCosto";
            this.colPrecioCosto.ReadOnly = true;
            this.colPrecioCosto.Width = 90;
            // 
            // colPrecioVenta
            // 
            this.colPrecioVenta.DataPropertyName = "PrecioVenta";
            this.colPrecioVenta.HeaderText = "Precio Venta";
            this.colPrecioVenta.MinimumWidth = 8;
            this.colPrecioVenta.Name = "colPrecioVenta";
            this.colPrecioVenta.ReadOnly = true;
            this.colPrecioVenta.Width = 100;
            // 
            // colStockActual
            // 
            this.colStockActual.DataPropertyName = "StockActual";
            this.colStockActual.HeaderText = "Stock Actual";
            this.colStockActual.MinimumWidth = 8;
            this.colStockActual.Name = "colStockActual";
            this.colStockActual.ReadOnly = true;
            this.colStockActual.Width = 105;
            // 
            // colStockMinimo
            // 
            this.colStockMinimo.DataPropertyName = "StockMinimo";
            this.colStockMinimo.HeaderText = "Stock Mínimo";
            this.colStockMinimo.MinimumWidth = 8;
            this.colStockMinimo.Name = "colStockMinimo";
            this.colStockMinimo.ReadOnly = true;
            this.colStockMinimo.Width = 105;
            // 
            // colAplicaIva
            // 
            this.colAplicaIva.DataPropertyName = "AplicaIva";
            this.colAplicaIva.HeaderText = "Aplica IVA";
            this.colAplicaIva.MinimumWidth = 8;
            this.colAplicaIva.Name = "colAplicaIva";
            this.colAplicaIva.ReadOnly = true;
            this.colAplicaIva.Width = 90;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(24, 151);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 35);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(158, 151);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(120, 35);
            this.btnModificar.TabIndex = 14;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(292, 151);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 35);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(426, 151);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 35);
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // FrmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 590);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.chkAplicaIva);
            this.Controls.Add(this.txtStockMinimo);
            this.Controls.Add(this.lblStockMinimo);
            this.Controls.Add(this.txtStockActual);
            this.Controls.Add(this.lblStockActual);
            this.Controls.Add(this.txtPrecioVenta);
            this.Controls.Add(this.lblPrecioVenta);
            this.Controls.Add(this.txtPrecioCosto);
            this.Controls.Add(this.lblPrecioCosto);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.txtNombreProducto);
            this.Controls.Add(this.lblNombreProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestión de productos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn colIDProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockMinimo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAplicaIva;
    }
}
