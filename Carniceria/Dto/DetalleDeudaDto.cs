using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carniceria.Dto
{
    
        public class DetalleDeudaDto
        {
            public string NombreProducto { get; set; }
            public int? Cantidad { get; set; }
            public decimal? Kilos { get; set; }
            public decimal MontoProducto { get; set; }
            public bool Saldada { get; set; }   // <-- agregado
        }
    
}
