using Carniceria.Models;
using System.Windows.Forms;

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
            AplicarEstilos();
        }



        private void CargarComboTipo()
        {
            tipoComboBox.Items.Clear();
            tipoComboBox.Items.Add(new { Text = "Producto", Value = "P" });
            tipoComboBox.Items.Add(new { Text = "Carne", Value = "C" });

            tipoComboBox.DisplayMember = "Text";
            tipoComboBox.ValueMember = "Value";
        }

        // Validación en tiempo real: solo números en cantidad
        private void cantidadTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Validación en tiempo real: solo números y coma/punto en precio
        private void precioTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo un separador decimal
            if ((e.KeyChar == ',' || e.KeyChar == '.') && ((sender as TextBox).Text.Contains(",") || (sender as TextBox).Text.Contains(".")))
            {
                e.Handled = true;
            }
        }

        private async void AceptarBtn_Click(object sender, EventArgs e)
        {
            // Validaciones
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
                // --- LLAMADA AL SP ---
                await _dbcontext.Procedures.sp_insertar_producto_con_stockAsync(
                    nombreProdTxt.Text,
                    tipoSeleccionado,
                    decimal.Parse(cantidadTxt.Text),          // decimal
                    int.Parse(cantidadTxt.Text)
                );

                MessageBox.Show("✅ Producto insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al insertar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarEstilos()
        {
            this.BackColor = Color.WhiteSmoke;
            this.Font = new Font("Segoe UI", 10);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // más formal
            this.MaximizeBox = false;

            // --- Iteramos todos los controles ---
            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = Color.FromArgb(90, 50, 110); // violeta oscuro
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Cursor = Cursors.Hand;

                    btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(110, 70, 140);
                    btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(90, 50, 110);
                }
                else if (c is Label lbl)
                {
                    lbl.ForeColor = Color.FromArgb(50, 30, 70);
                    lbl.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                }
                else if (c is ComboBox cb)
                {
                    cb.BackColor = Color.White;
                    cb.ForeColor = Color.FromArgb(50, 30, 70);
                    cb.DropDownStyle = ComboBoxStyle.DropDownList;
                    cb.FlatStyle = FlatStyle.Flat;
                }
                else if (c is TextBox tb)
                {
                    tb.BackColor = Color.White;
                    tb.ForeColor = Color.FromArgb(50, 30, 70);
                    tb.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }

        private void Productos_Load(object sender, EventArgs e)
        {

        }
    }
}
