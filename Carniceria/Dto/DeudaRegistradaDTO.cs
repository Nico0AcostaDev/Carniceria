namespace Carniceria.Dto
{
    public class DeudaRegistradaDTO
    {
        public int IdDeuda { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaDeuda { get; set; }
        public decimal Total { get; set; }
        public bool? Saldada { get; set; }
        public List<DetalleDeudaProductoDTO> DetalleProducto { get; set; }
    }
    public class DetalleDeudaProductoDTO
    {
        public int IdDeudaProducto { get; set; }
        public int IdDeuda { get; set; }
        public int IdProducto { get; set; }
        public decimal? Kilos { get; set; }
        public int? Cantidad { get; set; }
        public decimal MontoProducto { get; set; }
    }

}
