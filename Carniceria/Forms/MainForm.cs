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
            DeudasForm deudasParciales = new DeudasForm(_dbcontext);
            deudasParciales.ShowDialog();
            this.Show();
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ModProductos modifForm = new ModProductos(_dbcontext);
            modifForm.ShowDialog();
            this.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltProductos Productos = new AltProductos(_dbcontext);
            Productos.ShowDialog();
            this.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltClientes clientesForm = new AltClientes(_dbcontext);
            clientesForm.ShowDialog();
            this.Show();
        }

        private void Backupbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string backupFolder = @"C:\BackupsSQL";

                if (!Directory.Exists(backupFolder))
                    Directory.CreateDirectory(backupFolder);

                string backupFile = Path.Combine(
                    backupFolder,
                    $"Carniceria_{DateTime.Now:yyyyMMdd_HHmmss}.bak"
                );

                string connectionString = _dbcontext.Database.GetDbConnection().ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string databaseName = connection.Database;

                    string query = $@"
            BACKUP DATABASE [{databaseName}]
            TO DISK = '{backupFile}'
            WITH INIT
        ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    $"Backup creado exitosamente:\n\n{backupFile}",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Backup Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

        }

        private void modificarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModProductos modifForm = new ModProductos(_dbcontext);
            modifForm.ShowDialog();
            this.Show();
        } 
    }
}
