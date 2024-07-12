using Carniceria.Dto;
using Carniceria.Models;
using System.Data;
namespace Carniceria
{
    public partial class VentaForm : Form
    {
        private readonly CarniceriaContext _dbcontext;
        private DataTable dtProductos = new DataTable();
        private DataTable dtDgvVenta = new DataTable();
        private DeudaRegistradaDTO deuda = new DeudaRegistradaDTO(); 
        private List<ProductoDto> productList = new List<ProductoDto>();
        private string nombre_producto = "";
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
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.Columns[0].Visible = false;
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
                dataSource.Add(new ClienteDTO() { Nombre = cli.nombre });
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

            producto.precio_unitario = Convert.ToDecimal(textBox4.Text);

            // C es igual a carnes... logica para detectar cantidades o kilos
            if(tipo == "C")
            {
                if(textBox1.Text.Length == 3)
                {
                   MessageBox.Show($"Se debe ingresar expresado en kilogramos... 2 o 4 digitos...", "Atencion!", MessageBoxButtons.OK);
                }
                else if (textBox1.Text.Length > 2)//si los digitos son mayor a 2... por ejemplo 1200 es decir, kilo 200
                {
                    producto.kilos = Convert.ToDecimal(textBox1.Text) / 1000m;
                    producto.subtotal = producto.precio_unitario * producto.kilos;
                }                
                else
                {
                    producto.kilos = Convert.ToDecimal(textBox1.Text);
                    producto.subtotal = producto.precio_unitario * producto.kilos;
                }
            } 
            else
            {
                producto.cantidad = Convert.ToInt32(textBox1.Text);
                producto.subtotal = producto.precio_unitario * producto.cantidad;
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
            dtDgvVenta.Rows.Add(producto.nombre_producto, producto.cantidad,producto.kilos, producto.precio_unitario, producto.subtotal);
        }
    }
}
