﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carniceria.Models
{
    public partial class sp_obtener_deudaResult
    {
        public int id_deuda { get; set; }
        public DateTime fecha_deuda { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        [Column("total", TypeName = "decimal(10,2)")]
        public decimal total { get; set; }
        public bool? saldada { get; set; }
    }
}
