using ProyectoFacturaMarket.Controlador;
using ProyectoFacturaMarket.Entidades;
using System;
using System.Windows.Forms;

namespace ProyectoFacturaMarket.Formulario
{
    public partial class FrmCategorias : Form
    {
        private readonly CategoriaBD categoriaBD = new CategoriaBD();
        private int idCategoriaSeleccionada;

        public FrmCategorias()
        {
            InitializeComponent();
            Load += FrmCategorias_Load;
            dgvCategorias.SelectionChanged += DgvCategorias_SelectionChanged;
            btnGuardar.Click += BtnGuardar_Click;
            btnModificar.Click += BtnModificar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;

            bool puedeAdministrar = SesionUsuario.EsAdmin;
            btnGuardar.Enabled = puedeAdministrar;
            btnModificar.Enabled = puedeAdministrar;
            btnEliminar.Enabled = puedeAdministrar;
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            try
            {
                dgvCategorias.DataSource = null;
                dgvCategorias.DataSource = categoriaBD.ListarCategorias();
                dgvCategorias.ClearSelection();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MostrarError("cargar las categorías", ex);
            }
        }

        private void DgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count == 0)
                return;

            Categoria categoria = dgvCategorias.SelectedRows[0].DataBoundItem as Categoria;
            if (categoria == null)
                return;

            idCategoriaSeleccionada = categoria.IDCategoria;
            txtNombreCategoria.Text = categoria.NombreCategoria;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCategoria.Text.Trim();
            if (nombre.Length == 0)
            {
                MessageBox.Show("Ingrese el nombre de la categoría.", "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCategoria.Focus();
                return;
            }

            try
            {
                bool guardada = categoriaBD.InsertarCategoria(new Categoria
                {
                    NombreCategoria = nombre,
                    Estado = true
                });
                if (guardada)
                {
                    MessageBox.Show("La categoría se guardó correctamente.", "Categorías", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCategorias();
                }
            }
            catch (Exception ex)
            {
                MostrarError("guardar la categoría", ex);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCategoria.Text.Trim();
            if (idCategoriaSeleccionada <= 0)
            {
                MessageBox.Show("Seleccione una categoría para modificar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (nombre.Length == 0)
            {
                MessageBox.Show("Ingrese el nombre de la categoría.", "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCategoria.Focus();
                return;
            }

            try
            {
                bool modificada = categoriaBD.ModificarCategoria(new Categoria
                {
                    IDCategoria = idCategoriaSeleccionada,
                    NombreCategoria = nombre,
                    Estado = true
                });
                if (modificada)
                {
                    MessageBox.Show("La categoría se modificó correctamente.", "Categorías", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCategorias();
                }
            }
            catch (Exception ex)
            {
                MostrarError("modificar la categoría", ex);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (idCategoriaSeleccionada <= 0)
            {
                MessageBox.Show("Seleccione una categoría para eliminar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Desea desactivar la categoría seleccionada?",
                "Confirmar desactivación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (confirmacion != DialogResult.Yes)
                return;

            try
            {
                if (categoriaBD.EliminarLogicoCategoria(idCategoriaSeleccionada))
                {
                    MessageBox.Show("La categoría se desactivó correctamente.", "Categorías", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCategorias();
                }
            }
            catch (Exception ex)
            {
                MostrarError("desactivar la categoría", ex);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            dgvCategorias.ClearSelection();
        }

        private void LimpiarCampos()
        {
            idCategoriaSeleccionada = 0;
            txtNombreCategoria.Clear();
        }

        private static void MostrarError(string operacion, Exception ex)
        {
            MessageBox.Show("No fue posible " + operacion + ":\r\n" + ex.Message,
                "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
