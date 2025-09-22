using Carniceria.Forms;
using Carniceria.Forms.Altas;
using Carniceria.Models;

namespace Carniceria
{
    public partial class MainForm : Form
    {
        private readonly CarniceriaContext _dbcontext;
        public MainForm(CarniceriaContext dbcontext)
        {
            InitializeComponent();
            _dbcontext = dbcontext;
            EstilosFormulario();
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

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void EstilosFormulario()
        {
            this.BackColor = Color.WhiteSmoke;
            this.Font = new Font("Segoe UI", 10);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestión";

            if (this.MainMenuStrip != null)
            {
                Color violeta = Color.FromArgb(90, 50, 110);
                Color violetaHover = Color.FromArgb(110, 70, 140);

                this.MainMenuStrip.BackColor = violeta;
                this.MainMenuStrip.ForeColor = Color.White;
                this.MainMenuStrip.Font = new Font("Segoe UI Semibold", 10);
                this.MainMenuStrip.RenderMode = ToolStripRenderMode.Professional;

                foreach (ToolStripMenuItem item in this.MainMenuStrip.Items)
                {
                    item.BackColor = violeta;
                    item.ForeColor = Color.White;

                    // Hover
                    item.MouseEnter += (s, e) => item.BackColor = violetaHover;
                    item.MouseLeave += (s, e) => item.BackColor = violeta;

                    // Todos los subitems igual
                    foreach (ToolStripItem subItem in item.DropDownItems)
                    {
                        subItem.BackColor = violeta;
                        subItem.ForeColor = Color.White;

                        subItem.MouseEnter += (s, e) => subItem.BackColor = violetaHover;
                        subItem.MouseLeave += (s, e) => subItem.BackColor = violeta;
                    }
                }
            }
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
    }
}
