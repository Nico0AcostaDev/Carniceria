using Carniceria.Dto;
using Carniceria.Models;
using System.Data;
namespace Carniceria
{
    public partial class VentaForm : Form
    {
        private readonly CarniceriaContext _dbcontext;
        private DataTable dtProductos = new DataTable();
        public VentaForm(CarniceriaContext dbcontext)
        {
            InitializeComponent();
            _dbcontext = dbcontext; 

            dtProductos.Columns.Add("Id_Productos", typeof(int));
            dtProductos.Columns.Add("Nombre Producto", typeof(string));

            dgvProductos.DataSource = dtProductos;
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
                dtProductos.Rows.Add(product.id_producto, product.nombre_producto);
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
    }
}
