using Carniceria.Dto;
using Carniceria.Models;
using System.Data;

namespace Carniceria
{
    public partial class ModificacionesForm : Form
    {
        private readonly CarniceriaContext _dbcontext;
        private DataTable dtvProductos = new DataTable();

        public ModificacionesForm(CarniceriaContext dbcontext)
        {
            InitializeComponent();
            _dbcontext = dbcontext;

            disabledTextbox();

            dtvProductos.Columns.Add("ID Producto", typeof(int));
            dtvProductos.Columns.Add("Nombre Producto", typeof(string));
            dtvProductos.Columns.Add("Cantidad", typeof(decimal));
            dtvProductos.Columns.Add("Precio Unitario", typeof(decimal));
            dtvProductos.Columns.Add("Fecha Actualización", typeof(DateTime));
            dtvProductos.Columns.Add("Estado", typeof(string));

            dgvProductos.DataSource = dtvProductos;
            ajustesFormatoDiseñoDgv();
        }

        private void disabledTextbox()
        {
            descripcionTxt.Enabled = false;
            cantidadTxt.Enabled = false;
            precioTxt.Enabled = false;
            estadoTxt.Enabled = false;
        }

        private void ajustesFormatoDiseñoDgv()
        {
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.MultiSelect = false;
            dgvProductos.Columns[0].Visible = false;
            dgvProductos.ReadOnly = true;
            dgvProductos.AllowUserToOrderColumns = false;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AllowUserToResizeRows = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void CargarGridAndCombo()
        {
            var stockProductos = await _dbcontext.Procedures.sp_obtener_stock_con_precioAsync();

            foreach (var sp in stockProductos)
            {
                dtvProductos.Rows.Add(sp.id_producto, sp.nombre_producto, sp.cantidad, sp.precio, sp.fecha_actualizacion, sp.cod_estado);
            }
        }

        private void ModificacionesForm_Load(object sender, EventArgs e)
        {
            CargarGridAndCombo();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvProductos.Rows[e.RowIndex];

            descripcionTxt.Text = row.Cells["Nombre Producto"].Value?.ToString();
            cantidadTxt.Text = row.Cells["Cantidad"].Value?.ToString();
            lblUltActualizacion.Text = row.Cells["Fecha Actualización"].Value?.ToString();
            precioTxt.Text = Convert.ToDecimal(row.Cells["Precio Unitario"].Value).ToString("0.00");
            estadoTxt.Text = row.Cells["Estado"].Value?.ToString();
        }

        private void btnDescripcionHide_Click(object sender, EventArgs e)
        {
            descripcionTxt.Enabled = !descripcionTxt.Enabled;
        }

        private void btnCantidadHide_Click(object sender, EventArgs e)
        {
            cantidadTxt.Enabled = !cantidadTxt.Enabled;
        }

        private void btnEstadoHide_Click(object sender, EventArgs e)
        {
            estadoTxt.Enabled = !estadoTxt.Enabled;
        }

        private void btnPrecioHide_Click(object sender, EventArgs e)
        {
            precioTxt.Enabled = !precioTxt.Enabled;
        }

        private async void AceptarBtn_Click(object sender, EventArgs e)
        {
            // Validaciones con estilo consistente
            if (string.IsNullOrWhiteSpace(descripcionTxt.Text))
            {
                MessageBox.Show("Debe ingresar una descripción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(cantidadTxt.Text))
            {
                MessageBox.Show("Debe ingresar una cantidad.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(precioTxt.Text))
            {
                MessageBox.Show("Debe ingresar un precio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(estadoTxt.Text))
            {
                MessageBox.Show("Debe ingresar un estado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que cantidad sea numérica
            if (!decimal.TryParse(cantidadTxt.Text, out decimal cantidad))
            {
                MessageBox.Show("Cantidad debe ser un valor numérico.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar estado
            string estado = estadoTxt.Text.ToUpper();
            if (estado != "A" && estado != "B")
            {
                MessageBox.Show("Estado solo puede ser 'A' o 'B'.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar fila seleccionada
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un producto para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener fila seleccionada
            DataGridViewRow filaSeleccionada = dgvProductos.SelectedRows[0];
            int id_producto = Convert.ToInt32(filaSeleccionada.Cells["ID Producto"].Value);

            string descripcionOriginal = filaSeleccionada.Cells["Nombre Producto"].Value?.ToString();
            decimal cantidadOriginal = Convert.ToDecimal(filaSeleccionada.Cells["Cantidad"].Value);
            decimal precioOriginal = Convert.ToDecimal(filaSeleccionada.Cells["Precio Unitario"].Value);
            string estadoOriginal = filaSeleccionada.Cells["Estado"].Value?.ToString();

            // Solo enviar cambios
            string descripcionParam = descripcionTxt.Text != descripcionOriginal ? descripcionTxt.Text : null;
            decimal? cantidadParam = cantidad != cantidadOriginal ? cantidad : (decimal?)null;
            decimal? precioParam = Convert.ToDecimal(precioTxt.Text) != precioOriginal ? Convert.ToDecimal(precioTxt.Text) : (decimal?)null;
            string estadoParam = estado != estadoOriginal ? estado : null;

            try
            {
                // Llamada al SP
                await _dbcontext.Procedures.sp_editar_productoAsync(
                    id_producto,
                    descripcionParam,
                    cantidadParam,
                    precioParam,
                    estadoParam
                );

                // Si todo sale bien
                MessageBox.Show("✅ Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dtvProductos.Clear();
                CargarGridAndCombo();
                disabledTextbox();
            }
            catch (Exception ex)
            {
                // Si ocurre un error
                MessageBox.Show($"❌ Ocurrió un error al actualizar el producto:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
