using Carniceria.Dto;
using Carniceria.Models;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Carniceria
{
    public partial class VentaForm : Form
    {
        private readonly CarniceriaContext _dbcontext;
        private DataTable dtProductos = new DataTable();
        private DataTable dtDgvVenta = new DataTable();
        private List<ProductoDto> productList = new List<ProductoDto>();
        private string nombre_producto = "";
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
                dtProductos.Rows.Add(product.id_producto, product.nombre_producto, product.tipo);
            }
            var dataSource = new List<ClienteDTO>();


            foreach (var cli in clientes)
            {
                dataSource.Add(new ClienteDTO() { Nombre = cli.nombre, IdCliente = cli.id_cliente });
            }

            //Setup data binding
            this.comboBox1.DataSource = dataSource;
            this.comboBox1.DisplayMember = "Nombre";
            this.comboBox1.ValueMember = "IdCliente";

            // make it readonly
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void VentaForm_Load(object sender, EventArgs e)
        {
            CargarGridAndCombo();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvProductos.SelectedRows[0];

            producto_id = Convert.ToInt32(row.Cells["Id_Productos"].Value);
            tipo = row.Cells["Tipo"].Value.ToString();
            textBox2.Text = row.Cells["Nombre Producto"].Value.ToString();

            nombre_producto = row.Cells["Nombre Producto"].Value.ToString();
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
        private void button2_Click(object sender, EventArgs e)
        {
            ProductoDto producto = new ProductoDto();

            if (!validarCarrito(textBox1.Text, textBox2.Text, textBox4.Text))
                return;

            producto.precio_unitario = Convert.ToDecimal(textBox4.Text);

            // C es igual a carnes... logica para detectar cantidades o kilos
            if (tipo == "C")
            {
                int length = textBox1.Text.Length;
                if (!Regex.IsMatch(textBox1.Text, @"^\d*$"))
                {
                    MessageBox.Show("Solo se permiten números."); 
                    return;
                }
                if (length == 2 || length == 1)
                {
                    string value = textBox1.Text + ".00";
                    producto.kilos  = Convert.ToDecimal(value, CultureInfo.InvariantCulture);
                    producto.subtotal = Math.Round(producto.precio_unitario * producto.kilos, 2);  
                }
                else if (length == 4)
                {
                    string value = textBox1.Text.Insert(1, ".");
                    producto.kilos = Convert.ToDecimal(value, CultureInfo.InvariantCulture);
                    producto.subtotal = Math.Round(producto.precio_unitario * producto.kilos, 2);
                }
                else if (length == 0 || length != 2 || length != 4) // If the length is not 2 or 4, show an error
                {
                    MessageBox.Show("Longitud no válida.", "Atencion!", MessageBoxButtons.OK);
                    return;  
                } 
            }
            else
            {
                //string value = textBox1.Text + ".00"; 
                //var value2  = Convert.ToDecimal(value, CultureInfo.InvariantCulture);
                producto.cantidad = Convert.ToInt32(textBox1.Text);
                producto.subtotal = Math.Round(producto.precio_unitario * producto.cantidad);
            }

            producto.nombre_producto = nombre_producto;
            producto.idProducto = producto_id;

            bool existeProducto = productList.Where(x => x.idProducto == producto.idProducto).Any();

            if (!existeProducto)
            {
                addCompraToGrid(producto);
                limpiarControles();
            }
            else
            {
                MessageBox.Show($"El producto ya se encuentra cargado en el listado de compras!!", "Atencion!", MessageBoxButtons.OK);
                limpiarControles();
            }
        }
        public void addCompraToGrid(ProductoDto producto)
        {
            productList.Add(producto);
            dtDgvVenta.Rows.Add(producto.nombre_producto, producto.cantidad, producto.kilos, producto.precio_unitario, producto.subtotal);
        }

        private bool validarCarrito(string cantidad, string producto, string precioUnitario)
        {
            bool valida = true;
            if (string.IsNullOrEmpty(cantidad))
            {
                MessageBox.Show($"No hay ningun producto a cobrar...", "Atencion!", MessageBoxButtons.OK);
                valida = false;
            }

            if (string.IsNullOrEmpty(precioUnitario))
            {
                MessageBox.Show($"No hay monto a cobrar, por favor, insertar uno correcto", "Atencion!", MessageBoxButtons.OK);
                valida = false;
            }

            if (string.IsNullOrEmpty(producto))
            {
                MessageBox.Show($"No hay producto asociado", "Atencion!", MessageBoxButtons.OK);
                valida = false;
            }

            return valida;
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            id_cliente = (int)this.comboBox1.SelectedValue;

            if (string.IsNullOrEmpty(id_cliente.ToString()))
            {
                MessageBox.Show($"Debemos seleccionar un cliente", "Atencion!", MessageBoxButtons.OK);
                return;
            }

            foreach (var pd in productList)
            {
                total += pd.subtotal;
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
            this.Close();
        }

        private void dgvProductos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
