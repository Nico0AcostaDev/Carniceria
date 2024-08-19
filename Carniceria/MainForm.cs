using Carniceria.Models;
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
    }
}
