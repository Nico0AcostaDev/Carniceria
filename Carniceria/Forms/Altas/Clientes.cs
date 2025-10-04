using Carniceria.Models; 
namespace Carniceria.Forms.Altas
{
    public partial class Clientes : Form
    {
        private readonly CarniceriaContext _dbcontext;
        public Clientes(CarniceriaContext dbcontext)
        {
            _dbcontext = dbcontext;
            InitializeComponent(); 
        }

        private void Clientes_Load(object sender, EventArgs e)
        {

        } 
        private void button1_Click(object sender, EventArgs e)
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
                // Llamada al SP
                  _dbcontext.Procedures.sp_insertar_clienteAsync(
                    Nombretxt.Text,
                    Apellidotxt.Text,
                    telefono,
                    Infotxt.Text,
                    direccion,
                    email
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
