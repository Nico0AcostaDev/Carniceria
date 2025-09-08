using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carniceria.Dto
{
    public class StockProducto
    {
        public int id_producto { get; set; }
        [StringLength(255)]
        public string nombre_producto { get; set; }
        [Column("cantidad", TypeName = "decimal(10,2)")]
        public decimal? cantidad { get; set; }
        [Column("precio", TypeName = "decimal(10,2)")]
        public decimal? precio { get; set; }
        public DateTime fecha_actualizacion { get; set; }
        [StringLength(1)]
        public string cod_estado { get; set; }
    }
}
