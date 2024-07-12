namespace Carniceria.Dto
{
    public class ProductoDto
    {
        public int idProducto { get; set; }
        public string nombre_producto { get; set; } 
        public decimal kilos { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public decimal subtotal{ get; set; }
    }
}
