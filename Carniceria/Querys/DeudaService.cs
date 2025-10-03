using Carniceria.Models;
using Carniceria.Models.Carniceria.Dto;

namespace Carniceria.Querys
{
    public class DeudaService
    {
        private readonly CarniceriaContext _dbContext;

        public DeudaService(CarniceriaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public class CrearDeudaProductoDto
        {
            public int IdProducto { get; set; }
            public decimal Kilos { get; set; }
            public int Cantidad { get; set; }
            public decimal MontoProducto { get; set; }
        }

        public class CrearDeudaDto
        {
            public int IdCliente { get; set; }
            public decimal Total { get; set; }
            public bool Saldada { get; set; }
            public List<CrearDeudaProductoDto> Productos { get; set; } = new();
        }

        public async Task<int> CrearDeudaAsync(CrearDeudaDto nuevaDeuda)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            { 
                var deuda = new DeudaRegistradaDto
                {
                    IdCliente = nuevaDeuda.IdCliente,
                    FechaDeuda = DateTime.Now,
                    Total = nuevaDeuda.Total,
                    Saldada = nuevaDeuda.Saldada
                };

                _dbContext.DeudasRegistradas.Add(deuda);
                await _dbContext.SaveChangesAsync();

                 
                foreach (var prod in nuevaDeuda.Productos)
                {
                    var deudaProd = new DetalleDeudaProductoDto
                    {
                        IdDeuda = deuda.IdDeuda,  
                        IdProducto = prod.IdProducto,
                        Kilos = prod.Kilos,
                        Cantidad = prod.Cantidad,
                        MontoProducto = prod.MontoProducto
                    };

                    _dbContext.DetalleDeudaProductos.Add(deudaProd);
                }

                await _dbContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return deuda.IdDeuda; 
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

}
