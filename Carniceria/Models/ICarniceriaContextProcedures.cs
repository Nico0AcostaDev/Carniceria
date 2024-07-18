﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Carniceria.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Carniceria.Models
{
    public partial interface ICarniceriaContextProcedures
    {
        Task<int> sp_insertar_deudaAsync(int? id_cliente, decimal? total, OutputParameter<int?> id_deuda, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> sp_insertar_deuda_detalleAsync(int? id_deuda, int? id_producto, decimal? kilos, int? cantidad, decimal? monto_producto, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<sp_obtener_clientesResult>> sp_obtener_clientesAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<sp_obtener_productosResult>> sp_obtener_productosAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
