using Carniceria.Forms;
using Carniceria.Forms.Altas;
using Carniceria.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Carniceria
{
    public partial class MainForm : Form
    {
        private readonly CarniceriaContext _dbcontext;
        public MainForm(CarniceriaContext dbcontext)
        {
            InitializeComponent(); 
            _dbcontext = dbcontext;  
        } 

        private void generarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentaForm frmVenta = new VentaForm(_dbcontext);
            frmVenta.ShowDialog();
            this.Show();
        }

        private void deudasParcialesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeudasParcialesForm deudasParciales = new DeudasParcialesForm(_dbcontext);
            deudasParciales.ShowDialog();
            this.Show();
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ModificacionesForm modifForm = new ModificacionesForm(_dbcontext);
            modifForm.ShowDialog();
            this.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos Productos = new Productos(_dbcontext);
            Productos.ShowDialog();
            this.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes clientesForm = new Clientes(_dbcontext);
            clientesForm.ShowDialog();
            this.Show();
        }

        private void Backupbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string backupFile = Path.Combine(desktopPath, $"MyDatabaseBackup_{DateTime.Now:yyyyMMdd_HHmmss}.bak");
                string connectionString = _dbcontext.Database.GetDbConnection().ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string databaseName = connection.Database;

                    string query = $"BACKUP DATABASE [{databaseName}] TO DISK = '{backupFile}'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }

                MessageBox.Show($"Backup creado exitosamente!\n\n{backupFile}",
                                "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                                "Backup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
    }
}
