 namespace Carniceria.Models
 {
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace Carniceria.Dto
    { 
        public class ProductoDto
        {
            [Column("id_producto")]
            public int IdProducto { get; set; }
            [Column("nombre_producto")]
            public string NombreProducto { get; set; }
            [Column("precio")]
            public decimal? Precio { get; set; }
            [Column("tipo")]
            public string Tipo { get; set; }
            [Column("cod_estado")]
            public string CodEstado { get; set; } 
        }

        public class StockProductoDto
        {
            [Column("id_stock")]
            public int IdStock { get; set; }
            [Column("id_producto")]
            public int IdProducto { get; set; }
            [Column("descripcion")]
            public string Descripcion { get; set; }
            [Column("cantidad")]
            public int? Cantidad { get; set; }
            [Column("fecha_actualizacion")]
            public DateTime FechaActualizacion { get; set; }
            [Column("cod_estado")]
            public string CodEstado { get; set; }
        }

        public class HistorialPrecioDto
        {
            public int IdHistorial { get; set; }
            public int IdProducto { get; set; }
            public decimal PrecioNuevo { get; set; }
            public DateTime FechaActualizacion { get; set; }
            public string CodEstado { get; set; }
        }

        public class ClienteDto
        {
            [Column("id_cliente")]
            public int IdCliente { get; set; }
            [Column("nombre")]
            public string Nombre { get; set; }
            [Column("apellido")]
            public string Apellido { get; set; }
            [Column("telefono")]
            public string Telefono { get; set; }
            [Column("direccion")]
            public string Direccion { get; set; }
            [Column("email")]
            public string Email { get; set; }
            [Column("info_relevante")]
            public string InfoRelevante { get; set; }
            [Column("fecha_registro")]
            public DateTime? FechaRegistro { get; set; }
            [Column("cod_estado")]
            public string CodEstado { get; set; }
        }

        public class DeudaRegistradaDto
        {
            [Column("id_deuda")]
            public int IdDeuda { get; set; }
            [Column("id_cliente")]
            public int IdCliente { get; set; }
            [Column("fecha_deuda")]
            public DateTime FechaDeuda { get; set; }
            [Column("total")]
            public decimal Total { get; set; }
            [Column("saldada")]
            public bool Saldada { get; set; }
        }

        public class DetalleDeudaProductoDto
        {
            [Column("id_deuda_producto")]
            public int IdDeudaProducto { get; set; }
            [Column("id_deuda")]
            public int IdDeuda { get; set; }
            [Column("id_producto")]
            public int IdProducto { get; set; }
            [Column("kilos")]
            public decimal? Kilos { get; set; }
            [Column("cantidad")]
            public int? Cantidad { get; set; }
            [Column("monto_producto")]
            public decimal MontoProducto { get; set; }
        }

        public class PagoDto
        {
            [Column("id_parciales")]
            public int IdParciales { get; set; }
            [Column("id_deuda")]
            public int IdDeuda { get; set; }
            [Column("monto_pagado")]
            public decimal MontoPagado { get; set; }
            [Column("fecha_pago")]
            public DateTime FechaPago { get; set; }
        }
    }

}
