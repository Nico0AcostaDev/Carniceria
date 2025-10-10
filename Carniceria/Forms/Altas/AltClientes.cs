using Carniceria.Models; 
namespace Carniceria.Forms.Altas
{
    public partial class AltClientes : Form
    {
        private readonly CarniceriaContext _dbcontext;
        public AltClientes(CarniceriaContext dbcontext)
        {
            _dbcontext = dbcontext;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
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

            try
            {
                _dbcontext.Procedures.sp_insertar_clienteAsync(
                  Nombretxt.Text,
                  Apellidotxt.Text,
                  Telefonotxt.Text,
                  Direcciontxt.Text,
                  Emailtxt.Text,
                  Infotxt.Text

              );

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
