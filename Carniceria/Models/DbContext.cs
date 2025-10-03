using Carniceria.Models;
using Carniceria.Models.Carniceria.Dto;
using Microsoft.EntityFrameworkCore; 

namespace Carniceria.Models
{ 
        public class CarniceriaContext : DbContext
        {
            public CarniceriaContext(DbContextOptions<CarniceriaContext> options)
                : base(options)
            {
            } 
         
            public DbSet<ProductoDto> Productos { get; set; }
            public DbSet<StockProductoDto> StockProductos { get; set; }
            public DbSet<HistorialPrecioDto> HistorialPrecios { get; set; }
            public DbSet<ClienteDto> Clientes { get; set; }
            public DbSet<DeudaRegistradaDto> DeudasRegistradas { get; set; }
            public DbSet<DetalleDeudaProductoDto> DetalleDeudaProductos { get; set; }
            public DbSet<PagoDto> Pagos { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            { 
                // Productos
                modelBuilder.Entity<ProductoDto>(entity =>
                {
                    entity.ToTable("productos");
                    entity.HasKey(e => e.IdProducto);
                });

                // StockProductos
                modelBuilder.Entity<StockProductoDto>(entity =>
                {
                    entity.ToTable("stock_productos");
                    entity.HasKey(e => e.IdStock);
                    entity.HasOne<ProductoDto>()
                          .WithMany()
                          .HasForeignKey(e => e.IdProducto);
                });

                // HistorialPrecios
                modelBuilder.Entity<HistorialPrecioDto>(entity =>
                {
                    entity.ToTable("historial_precios");
                    entity.HasKey(e => e.IdHistorial);
                    entity.HasOne<ProductoDto>()
                          .WithMany()
                          .HasForeignKey(e => e.IdProducto);
                });

                // Clientes
                modelBuilder.Entity<ClienteDto>(entity =>
                {
                    entity.ToTable("clientes");
                    entity.HasKey(e => e.IdCliente);
                });

                // DeudasRegistradas
                modelBuilder.Entity<DeudaRegistradaDto>(entity =>
                {
                    entity.ToTable("deudas_registradas");
                    entity.HasKey(e => e.IdDeuda);
                    entity.HasOne<ClienteDto>()
                          .WithMany()
                          .HasForeignKey(e => e.IdCliente);
                });

                // DetalleDeudaProductos
                modelBuilder.Entity<DetalleDeudaProductoDto>(entity =>
                {
                    entity.ToTable("detalle_deuda_productos");
                    entity.HasKey(e => e.IdDeudaProducto);
                    entity.HasOne<DeudaRegistradaDto>()
                          .WithMany()
                          .HasForeignKey(e => e.IdDeuda);
                    entity.HasOne<ProductoDto>()
                          .WithMany()
                          .HasForeignKey(e => e.IdProducto);
                });

                // Pagos
                modelBuilder.Entity<PagoDto>(entity =>
                {
                    entity.ToTable("pagos");
                    entity.HasKey(e => e.IdParciales);
                    entity.HasOne<DeudaRegistradaDto>()
                          .WithMany()
                          .HasForeignKey(e => e.IdDeuda);
                });
            }
        }  
}
 
