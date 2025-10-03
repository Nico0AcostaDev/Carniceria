using Carniceria.Dto;
using Carniceria.Models;
using Carniceria.Models.Carniceria.Dto;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Carniceria
{
    public partial class DeudasParcialesForm : Form
    {
        private readonly CarniceriaContext _dbcontext;
        private DataTable dtDeuda = new DataTable();
        private DataTable dtDeudaDetalle = new DataTable();
        private DataTable dtPagos = new DataTable();
        private List<DeudaRegistradaDto> deudas;
        Color lightGreen = Color.FromArgb(144, 238, 144);
        public DeudasParcialesForm(CarniceriaContext dbcontext)
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
            deudas = _dbcontext.DeudasRegistradas.ToList();
            var clientes = _dbcontext.Clientes.ToList().Where(x => x.IdCliente == deudas.First().IdCliente).ToList(); 
            foreach (var de in deudas.OrderByDescending(x => x.FechaDeuda))
            {   
                string estadoDeuda = "";
                
                if (de.Saldada == true)
                {
                    estadoDeuda = "Cancelada";   
                } 
                else
                {
                    estadoDeuda = "Activa";
                } 

                dtDeuda.Rows.Add(de.IdDeuda, de.FechaDeuda, clientes.Select(x => x.Nombre), clientes.Select(x => x.Apellido), de.Total, estadoDeuda); 
            } 

            foreach (DataGridViewRow row in dgvDeuda.Rows)
            {
                if (row.Cells["Estado deuda"].Value.ToString() == "Cancelada")
                {
                    row.DefaultCellStyle.BackColor = lightGreen;
                }
            }
        }
        public async Task<(List<DetalleDeudaDto>, List<PagoDto>)> ObtenerDetalleDeudaAsync(int idDeuda)
        {
            // Traer estado de la deuda (saldada)
            var deuda = await _dbcontext.DeudasRegistradas
                .Where(d => d.IdDeuda == idDeuda)
                .FirstOrDefaultAsync();

            bool saldada = deuda?.Saldada == true;

            // Traer productos vinculados a la deuda
            var detalleProductos = await _dbcontext.DetalleDeudaProductos
                .Where(d => d.IdDeuda == idDeuda)
                .Join(
                    _dbcontext.Productos,          // tabla productos
                    d => d.IdProducto,             // FK en detalle_deuda_productos
                    p => p.IdProducto,             // PK en productos
                    (d, p) => new DetalleDeudaDto
                    {
                        NombreProducto = p.NombreProducto,
                        Cantidad = d.Cantidad,
                        Kilos = d.Kilos,
                        MontoProducto = d.MontoProducto,
                        Saldada = saldada
                    }
                )
                .ToListAsync();

            // Traer pagos de la deuda
            var pagos = await _dbcontext.Pagos
                .Where(p => p.IdDeuda == idDeuda)
                .Select(p => new PagoDto
                {
                    IdParciales = p.IdParciales,
                    FechaPago = p.FechaPago,
                    MontoPagado = p.MontoPagado 
                })
                .ToListAsync();

            return (detalleProductos, pagos);
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
            var detalle = _dbcontext.DetalleDeudaProductos.Where(x => x.IdDeuda == idDeuda);
            var producto = _dbcontext.Productos.ToList();
            foreach (var item in detalle)
            {
                var prod = producto.Where(x => x.IdProducto == item.IdProducto).FirstOrDefault();
                if (prod.NombreProducto != null)
                {
                    dtDeudaDetalle.Rows.Add(prod.NombreProducto, item.Cantidad, item.Kilos, item.MontoProducto);
                }
                /*
                if (item.id_parciales != null)
                {
                    dtPagos.Rows.Add(item.id_parciales, item.fecha_pago, item.monto_pagado);
                    montoAcumulado += item.monto_pagado.Value;
                    
                }
                */
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

            decimal pago = Convert.ToDecimal(textBoxPago.Text + ".00", CultureInfo.InvariantCulture);

            if (pago == 0m)
            {
                MessageBox.Show("Por favor, ingresar montos mayores a 0");
                return;
            }

            var deuda = await ObtenerDetalleDeudaAsync(idDeuda);

            decimal total = deuda.Item2.Sum(p => (decimal?)p.MontoPagado) ?? 0m; 
            
            if (pago <= total && (total + pago) <= total)
            {
                // Insertar pago
                var pagoNuevo = new PagoDto
                {
                    IdDeuda = idDeuda,
                    MontoPagado = pago,
                    FechaPago = DateTime.Now
                };
                _dbcontext.Pagos.Add(pagoNuevo);

                // Actualizar total abonado
                total += pago;
                /*
                // Si está totalmente saldada
                if (total == total)
                {
                    deuda.Item1.sel = true;
                    _dbcontext.DeudasRegistradas.Update(deuda);
                }

                await _dbcontext.SaveChangesAsync(); 
                */
            } 

            label4.Text = "";
            label7.Text = "";
            textBoxPago.Text = "";

            dtDeuda.Clear();
            dtDeudaDetalle.Clear();
            dtPagos.Clear();
            CargarGridAndCombo();
        }

        #region NotUsing
        private async void button2_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
