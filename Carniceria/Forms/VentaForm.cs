using Carniceria.Dto;
using Carniceria.Models;
using System.Data;
using System.Globalization; 

namespace Carniceria
{
    public partial class VentaForm : Form
    {
        private readonly CarniceriaContext _dbcontext;
        private DataTable dtProductos = new DataTable();
        private DataTable dtDgvVenta = new DataTable();
        private List<Producto> productList = new List<Producto>();
        private string nombre_producto = "";
        private decimal precio_producto;
        private int id_cliente = new int();
        private decimal total = new decimal();
        private string tipo = "";
        private int producto_id = new int();
        public VentaForm(CarniceriaContext dbcontext)
        {
            InitializeComponent();
            _dbcontext = dbcontext;

            dtProductos.Columns.Add("Id_Productos", typeof(int));
            dtProductos.Columns.Add("Nombre Producto", typeof(string));
            dtProductos.Columns.Add("Precio", typeof(decimal));
            dtProductos.Columns.Add("Tipo", typeof(string));

            dtDgvVenta.Columns.Add("Nombre Producto", typeof(string));
            dtDgvVenta.Columns.Add("Cantidad", typeof(string));
            dtDgvVenta.Columns.Add("Kilos", typeof(decimal));
            dtDgvVenta.Columns.Add("Precio Unitario", typeof(decimal));
            dtDgvVenta.Columns.Add("Subtotal", typeof(decimal));

            dgvProductos.DataSource = dtProductos;
            dgvVenta.DataSource = dtDgvVenta;
            ajustesFormatoDiseñoDgv();
        }
        private void ajustesFormatoDiseñoDgv()
        {
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.MultiSelect = false;
            dgvProductos.Columns[0].Visible = false;
            dgvProductos.ReadOnly = true;
            dgvVenta.ReadOnly = true;
            dgvProductos.AllowUserToOrderColumns = false;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AllowUserToResizeRows = false;

            dgvVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVenta.AllowUserToAddRows = false;
            dgvVenta.MultiSelect = false;

            dgvVenta.AllowUserToOrderColumns = false;
            dgvVenta.AllowUserToResizeColumns = false;
            dgvVenta.AllowUserToResizeRows = false;
        }
        private async void CargarGridAndCombo()
        {
            var productos = await _dbcontext.Procedures.sp_obtener_productosAsync();
            var clientes = await _dbcontext.Procedures.sp_obtener_clientesAsync();

            foreach (var product in productos)
            {
                dtProductos.Rows.Add(product.id_producto, product.nombre_producto, product.precio, product.tipo);
            }
            var dataSource = new List<Cliente>();


            foreach (var cli in clientes)
            {
                dataSource.Add(new Cliente() { Nombre = cli.nombre, Apellido = cli.apellido, IdCliente = cli.id_cliente, InfoRelevante = cli.info_relevante });
            }

            this.comboBox1.DataSource = dataSource;
            this.comboBox1.DisplayMember = "Nombre";
            this.comboBox1.ValueMember = "IdCliente";

            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void VentaForm_Load(object sender, EventArgs e)
        {
            CargarGridAndCombo();
        }
        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvProductos.SelectedRows[0];

            producto_id = Convert.ToInt32(row.Cells["Id_Productos"].Value);
            tipo = row.Cells["Tipo"].Value.ToString();
            textBox2.Text = row.Cells["Nombre Producto"].Value.ToString();

            nombre_producto = row.Cells["Nombre Producto"].Value.ToString();
            precio_producto = Convert.ToDecimal(row.Cells["Precio"].Value);

            //C carne P producto
            if (tipo == "C")
            {
                label8.Text = "Kilos";
                label6.Text = "Precio por kilo";
                textBox4.Text = "";
                textBox4.Enabled = true;
            }
            else
            {
                label8.Text = "Cantidad";
                label6.Text = "Valor Unitario";

                decimal precio = Convert.ToDecimal(row.Cells["Precio"].Value);
                textBox4.Text = precio.ToString("0.00", CultureInfo.InvariantCulture);
                textBox4.Enabled = false;
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            limpiarControles();
        }
        private void limpiarControles()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();

            if (!validarCarrito(textBox1.Text, textBox2.Text, textBox4.Text))
                return;
            int stockDisponible = 0;
            if (tipo == "P") // 👈 solo consulto stock si es producto
            {
                var stockResult = await _dbcontext.Procedures.sp_consultar_stock_productoAsync(producto_id);

                bool hayStock = false;

                if (stockResult.Any())
                {
                    var stockRow = stockResult.First();
                    if (stockRow.stock_disponible > 0)
                    {
                        stockDisponible = (int)stockRow.stock_disponible;
                        hayStock = true;
                    }
                    else
                    {
                        hayStock = false;
                    }
                }

                if (!hayStock)
                {
                    MessageBox.Show("El producto se agotó.", "Atención!", MessageBoxButtons.OK);
                    return;
                }
            }

            producto.precio_unitario = Convert.ToDecimal(textBox4.Text.Replace(",", ""));

            if (tipo == "C")
            {
                if (!decimal.TryParse(textBox1.Text, out decimal kilos))
                {
                    MessageBox.Show("Solo se permiten números en Kilos.", "Atención!", MessageBoxButtons.OK);
                    return;
                }

                producto.kilos = kilos;
                producto.subtotal = producto.precio_unitario * producto.kilos;
            }
            else
            {
                if (!int.TryParse(textBox1.Text, out int cantidad))
                {
                    MessageBox.Show("Solo se permiten números en Cantidad.", "Atención!", MessageBoxButtons.OK);
                    return;
                }

                // Limitar por stock
                if (cantidad > stockDisponible)
                {
                    MessageBox.Show($"Solo hay {stockDisponible} unidades disponibles.", "Atención!", MessageBoxButtons.OK);
                    return;
                }

                producto.cantidad = cantidad;
                producto.subtotal = Math.Round(producto.precio_unitario * producto.cantidad, 2);
            }

            producto.nombre_producto = nombre_producto;
            producto.idProducto = producto_id;

            bool existeProducto = productList.Any(x => x.idProducto == producto.idProducto);

            if (!existeProducto)
            {
                addCompraToGrid(producto);
                limpiarControles();
            }
            else
            {
                MessageBox.Show($"El producto ya se encuentra cargado en el listado de compras!!", "Atención!", MessageBoxButtons.OK);
                limpiarControles();
            }
        }

        public void addCompraToGrid(Producto producto)
        {
            productList.Add(producto);
            dtDgvVenta.Rows.Add(producto.nombre_producto, producto.cantidad, producto.kilos, producto.precio_unitario, producto.subtotal);
        }
        private bool validarCarrito(string cantidad, string producto, string precioUnitario)
        {
            bool valida = true;
            if (string.IsNullOrEmpty(cantidad))
            {
                MessageBox.Show($"No hay ningun producto a cobrar...", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = false;
            }

            if (string.IsNullOrEmpty(precioUnitario))
            {
                MessageBox.Show($"No hay monto a cobrar, por favor, insertar uno correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = false;
            }

            if (string.IsNullOrEmpty(producto))
            {
                MessageBox.Show($"No hay producto asociado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = false;
            }

            return valida;
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            id_cliente = (int)this.comboBox1.SelectedValue;

            if (string.IsNullOrEmpty(id_cliente.ToString()))
            {
                MessageBox.Show($"Debemos seleccionar un cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var pd in productList)
            {
                total += pd.subtotal;
            }

            if (total == 0)
            {
                MessageBox.Show($"No hay productos a cobrar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"El total de la deuda es ${total} pesos",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                OutputParameter<int?> id_deuda = new OutputParameter<int?>();
                await _dbcontext.Procedures.sp_insertar_deudaAsync(id_cliente, total, id_deuda);
                decimal acumulador = 0m;
                foreach (var pdl in productList)
                {
                    acumulador += pdl.subtotal;
                    await _dbcontext.Procedures.sp_insertar_deuda_detalleAsync(id_deuda._value, pdl.idProducto, pdl.kilos, pdl.cantidad, pdl.subtotal);
                }
            }

            Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = textBox1.SelectionStart;

            string text = textBox1.Text.Replace(",", "");
            if (text.Length > 4)
                text = text.Substring(0, 4);
            if (text.Length == 4)
            {
                text = text.Insert(1, ",");
            }
            else if (text.Length == 5)
            {
                text = text.Insert(2, ",");
            }

            textBox1.Text = text;

            textBox1.SelectionStart = cursorPosition + (textBox1.Text.Length - text.Length);
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = textBox4.SelectionStart;

            string text = textBox4.Text.Replace(",", "");
            if (text.Length > 4)
                text = text.Substring(0, 4);
            if (text.Length == 4)
            {
                text = text.Insert(1, ",");
            }
            else if (text.Length == 5)
            {
                text = text.Insert(2, ",");
            }

            textBox4.Text = text;

            textBox4.SelectionStart = cursorPosition + (textBox4.Text.Length - text.Length);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is Cliente clienteSeleccionado)
            {
                lblNombre.Text = clienteSeleccionado.Nombre;
                lblApellido.Text = clienteSeleccionado.Apellido;
                lblInfo.Text = clienteSeleccionado.InfoRelevante;
            }
        }
    }
}
