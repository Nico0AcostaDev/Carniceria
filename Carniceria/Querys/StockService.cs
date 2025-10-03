using Carniceria.Models; 

namespace Carniceria.Querys
{   
    public class StockService
    {
        private readonly CarniceriaContext _dbContext;

        public StockService(CarniceriaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public class StockProductoDto
        {
            public int IdProducto { get; set; }
            public int StockDisponible { get; set; }
            public string Mensaje { get; set; } = string.Empty;
        }
        public StockProductoDto ConsultarStockProducto(int idProducto)
        {
            // Consulta a la tabla stock_productos
            var cantidad = _dbContext.StockProductos
                .Where(s => s.IdProducto == idProducto && s.CodEstado == "A")
                .Select(s => (int?)s.Cantidad) // nullable para que pueda ser null
                .FirstOrDefault();

            if (cantidad.HasValue && cantidad.Value > 0)
            {
                return new StockProductoDto
                {
                    IdProducto = idProducto,
                    StockDisponible = cantidad.Value,
                    Mensaje = $"Stock disponible: {cantidad.Value}"
                };
            }
            else
            {
                return new StockProductoDto
                {
                    IdProducto = idProducto,
                    StockDisponible = 0,
                    Mensaje = "El producto se agotó"
                };
            }
        }
    }
}
