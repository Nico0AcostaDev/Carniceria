using Carniceria.Models;
using Carniceria.Models.Carniceria.Dto;
namespace Carniceria.Forms.Altas
{
    public partial class Clientes : Form
    {
        private readonly CarniceriaContext _dbcontext;
        public Clientes(CarniceriaContext dbcontext)
        {
            _dbcontext = dbcontext;
            InitializeComponent();
            AplicarEstilos();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {

        }
        private void AplicarEstilos()
        {
            // Fondo general del form
            this.BackColor = Color.WhiteSmoke;
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            // Botones
            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = Color.FromArgb(90, 50, 110); // violeta oscuro
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }

                if (c is TextBox txt)
                {
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.BackColor = Color.White;
                    txt.ForeColor = Color.Black;
                    txt.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                }

                if (c is Label lbl)
                {
                    lbl.ForeColor = Color.FromArgb(50, 50, 50); // gris oscuro
                    lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            // Validaciones obligatorias
            if (string.IsNullOrWhiteSpace(Nombretxt.Text))
            {
                MessageBox.Show("El nombre es requerido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(Apellidotxt.Text))
            {
                MessageBox.Show("El apellido es requerido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(Infotxt.Text))
            {
                MessageBox.Show("La información es requerida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parámetros opcionales
            string telefono = string.IsNullOrWhiteSpace(Telefonotxt.Text) ? null : Telefonotxt.Text;
            string direccion = string.IsNullOrWhiteSpace(Direcciontxt.Text) ? null : Direcciontxt.Text;
            string email = string.IsNullOrWhiteSpace(Emailtxt.Text) ? null : Emailtxt.Text;

            try
            {
                var nuevoCliente = new ClienteDto
                {
                    Nombre = Nombretxt.Text,
                    Apellido = Apellidotxt.Text,
                    Telefono = telefono,
                    Direccion = direccion,
                    Email = email,
                    InfoRelevante = Infotxt.Text,
                    FechaRegistro = DateTime.Now,
                    CodEstado = "A"  
                };

                _dbcontext.Clientes.Add(nuevoCliente);
                await _dbcontext.SaveChangesAsync();

                MessageBox.Show("Usuario registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
