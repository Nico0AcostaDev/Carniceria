using Carniceria.Models;
using System.Data;
using System.Globalization;

namespace Carniceria
{
    public partial class DeudasForm : Form
    {
        private readonly CarniceriaContext _dbcontext;
        private DataTable dtDeuda = new DataTable();
        private DataTable dtDeudaDetalle = new DataTable();
        private DataTable dtPagos = new DataTable();
        private List<sp_obtener_deudaResult> deudas;
        Color lightGreen = Color.FromArgb(144, 238, 144);
        public DeudasForm(CarniceriaContext dbcontext)
        {
            InitializeComponent();
            _dbcontext = dbcontext;

            dtDeuda.Columns.Add("Id_Deuda", typeof(int));
            dtDeuda.Columns.Add("Fecha", typeof(string));
            dtDeuda.Columns.Add("Nombre", typeof(string));
            dtDeuda.Columns.Add("Apellido", typeof(string));
            dtDeuda.Columns.Add("Total", typeof(decimal));
            dtDeuda.Columns.Add("Estado deuda", typeof(string));

            dtDeudaDetalle.Columns.Add("Nombre Producto", typeof(string));
            dtDeudaDetalle.Columns.Add("Cantidad", typeof(int));
            dtDeudaDetalle.Columns.Add("Kilos", typeof(decimal));
            dtDeudaDetalle.Columns.Add("Precio Unitario", typeof(decimal));
            dtDeudaDetalle.Columns.Add("Fecha", typeof(string));

            dtPagos.Columns.Add("Id Pagos", typeof(int));
            dtPagos.Columns.Add("Fecha Pago", typeof(DateTime));
            dtPagos.Columns.Add("Monto Pagado", typeof(decimal));

            dgvPagos.DataSource = dtPagos;
            dgvDeuda.DataSource = dtDeuda;
            dgvDetalle.DataSource = dtDeudaDetalle;
            ajustesFormatoDiseñoDgv();
        }
        private void ajustesFormatoDiseñoDgv()
        {
            dgvDeuda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDeuda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDeuda.AllowUserToAddRows = false;
            dgvDeuda.MultiSelect = false; 
            dgvDeuda.Columns[0].Visible = false;
            dgvPagos.Columns[0].Visible = false;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.MultiSelect = false;

            dgvDetalle.ReadOnly = true;
            dgvDeuda.ReadOnly = true;
            dgvDetalle.ReadOnly = true;

            dgvPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPagos.AllowUserToAddRows = false;
            dgvPagos.MultiSelect = false;

            dgvDetalle.AllowUserToOrderColumns = false;
            dgvDetalle.AllowUserToResizeColumns = false;
            dgvDetalle.AllowUserToResizeRows = false;
            dgvDeuda.AllowUserToOrderColumns = false;
            dgvDeuda.AllowUserToResizeColumns = false;
            dgvDeuda.AllowUserToResizeRows = false;
            dgvPagos.AllowUserToOrderColumns = false;
            dgvPagos.AllowUserToResizeColumns = false;
            dgvPagos.AllowUserToResizeRows = false;
        }
        private void DeudasParcialesForm_Load(object sender, EventArgs e)
        {
            CargarGridAndCombo();
        }
        private async void CargarGridAndCombo()
        {
            deudas = await _dbcontext.Procedures.sp_obtener_deudaAsync();

            foreach (var de in deudas.OrderByDescending(x => x.fecha_deuda))
            {
                string estadoDeuda = de.saldada.Value ? "Cancelada" : "Activa";
                
                string mes = de.fecha_deuda.ToString("MMMM", new System.Globalization.CultureInfo("es-ES")); 
                mes = char.ToUpper(mes[0]) + mes.Substring(1);
                dtDeuda.Rows.Add(de.id_deuda, mes, de.nombre, de.apellido, de.total, estadoDeuda); 
            } 

            foreach (DataGridViewRow row in dgvDeuda.Rows)
            {
                if (row.Cells["Estado deuda"].Value.ToString() == "Cancelada")
                {
                    row.DefaultCellStyle.BackColor = lightGreen;
                }
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row1 in dgvDeuda.Rows)
            {
                if (row1.Cells["Estado deuda"].Value.ToString() == "Cancelada")
                {
                    row1.DefaultCellStyle.BackColor = lightGreen;
                }
            }

            decimal montoAcumulado = 0m;
            dtDeudaDetalle.Clear();
            dtPagos.Clear();
            DataGridViewRow row = dgvDeuda.SelectedRows[0];

            int idDeuda = Convert.ToInt32(row.Cells["Id_Deuda"].Value);
            var detalle = await _dbcontext.Procedures.sp_obtener_detalle_deudaAsync(idDeuda);
           
            foreach (var item in detalle)
            {   
                if (item.nombre_producto != null)
                {
                    dtDeudaDetalle.Rows.Add(item.nombre_producto, item.cantidad, item.kilos, item.monto_producto, item.fecha_compra);
                }
                
                if (item.id_parciales != null)
                {
                    dtPagos.Rows.Add(item.id_parciales, item.fecha_pago, item.monto_pagado);
                    montoAcumulado += item.monto_pagado.Value;
                    
                }
            }

            lblFaltante.Text = montoAcumulado.ToString();
            decimal total = Convert.ToDecimal(row.Cells["Total"].Value);
            decimal resultado = total - montoAcumulado;
            lblLiquidar.Text = resultado.ToString();
            label4.Text = row.Cells["Total"].Value.ToString();
            label7.Text = row.Cells["Nombre"].Value.ToString() + " " + row.Cells["Apellido"].Value.ToString();
            string deuda_estado = row.Cells["Estado deuda"].Value.ToString();

            if (deuda_estado == "Activa")
            {
                textBoxPago.Enabled = true;
                button3.Enabled = true;
            } 
            else
            {
                textBoxPago.Enabled = false;
                button3.Enabled = false;                
            }
        }        
        private async void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvDeuda.SelectedRows[0];

            int idDeuda = Convert.ToInt32(row.Cells["Id_Deuda"].Value);

            decimal pago = decimal.Parse(
    textBoxPago.Text,
    NumberStyles.Number,
    new CultureInfo("es-AR")
);

            if (pago == 0m)
            {
                MessageBox.Show("Por favor, ingresar montos mayores a 0", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OutputParameter<int?> pagoEjecutado = new OutputParameter<int?>();
            await _dbcontext.Procedures.sp_insertar_pagoAsync(idDeuda, pago,pagoEjecutado);

            if (pagoEjecutado.Value == 1)
            {
                MessageBox.Show($"Se abono {pago} sobre la deuda correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
            }  
            else if (pagoEjecutado.Value == 0)
            {
                MessageBox.Show($"No se pudo efectuar el pago, posiblemente el monto a abonar sea mayor a la deuda", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);           
            }

            label4.Text = "";
            label7.Text = "";
            textBoxPago.Text = "";

            dtDeuda.Clear();
            dtDeudaDetalle.Clear();
            dtPagos.Clear();
            CargarGridAndCombo();
        } 
    }
}
