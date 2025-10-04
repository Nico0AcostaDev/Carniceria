using Carniceria.Models; 

namespace Carniceria.Forms
{
    public partial class Productos : Form
    {
        private readonly CarniceriaContext _dbcontext;
        public Productos(CarniceriaContext dbcontext)
        {
            _dbcontext = dbcontext;
            InitializeComponent();
            CargarComboTipo();
        }

        private void CargarComboTipo()
        {
            tipoComboBox.Items.Clear();
            tipoComboBox.Items.Add(new { Text = "Producto", Value = "P" });
            tipoComboBox.Items.Add(new { Text = "Carne", Value = "C" });

            tipoComboBox.DisplayMember = "Text";
            tipoComboBox.ValueMember = "Value";
        }

        private void cantidadTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void precioTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',' || e.KeyChar == '.') && ((sender as TextBox).Text.Contains(",") || (sender as TextBox).Text.Contains(".")))
            {
                e.Handled = true;
            }
        }

        private async void AceptarBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nombreProdTxt.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nombreProdTxt.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cantidadTxt.Text) || !int.TryParse(cantidadTxt.Text, out _))
            {
                MessageBox.Show("Debe ingresar una cantidad válida (solo números).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cantidadTxt.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(PrecioTxt.Text) || !decimal.TryParse(PrecioTxt.Text, out _))
            {
                MessageBox.Show("Debe ingresar un precio válido (número decimal).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PrecioTxt.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(descripcionTxt.Text))
            {
                MessageBox.Show("Debe ingresar una descripción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                descripcionTxt.Focus();
                return;
            }

            if (tipoComboBox.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tipoComboBox.Focus();
                return;
            }
            // Obtener el valor P o C
            string tipoSeleccionado = (string)tipoComboBox.SelectedItem.GetType().GetProperty("Value")?.GetValue(tipoComboBox.SelectedItem, null);

            try
            {
                await _dbcontext.Procedures.sp_insertar_producto_con_stockAsync(
                    nombreProdTxt.Text,
                    tipoSeleccionado,
                    decimal.Parse(cantidadTxt.Text),
                    int.Parse(cantidadTxt.Text)
                );

                MessageBox.Show("Producto insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Productos_Load(object sender, EventArgs e)
        {

        }
    }
}
