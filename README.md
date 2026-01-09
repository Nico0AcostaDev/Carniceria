🥩 Funcionamiento de la CARNE
    La carne es un producto especial identificado con tipo = 'C'.    
    No se maneja por cantidad, sino por kilos.    
    El precio es por kilo.    
    Cada vez que se modifica el precio de la carne: Se registra el nuevo valor en la tabla historial_precios.    
    La fecha válida del precio para la carne siempre se toma desde historial_precios.fecha_actualizacion.    
    Al ingresar un producto se fija si es carne, si lo es, no impacta en stock_productos, es decir, no maneja stock.

📦 Funcionamiento de los PRODUCTOS (no carne)

    Los productos comunes tienen tipo = 'P'.    
    Se manejan por cantidad de unidades.    
    El precio actual se guarda en la tabla productos.    
    Cada cambio de precio: Actualiza el campo precio en productos.    
    Inserta un registro en historial_precios.    
    La fecha de actualización del producto: Se obtiene comparando la última fecha entre     
    stock_productos.fecha_actualizacion    
    historial_precios.fecha_actualizacion    
    Se toma la más cercana al presente.

💳 Funcionamiento de las DEUDAS
    📌 Generación de deuda    
    Cuando una venta se realiza a cuenta corriente:    
    Se crea una deuda en deudas_registradas.    
    Se insertan los productos vendidos en detalle_deuda_productos.    
    En cada detalle de deuda se guarda:    
    Producto    
    Cantidad o kilos    
    Precio aplicado en ese momento    
    monto_producto

🔄 Impacto del cambio de precio en deudas
    Productos (P)    
    Si el precio sube:    
    Se actualiza el monto_producto en todas las deudas activas.    
    Se recalcula el total de la deuda.    
    Si el precio baja:    
    No se modifica la deuda (criterio conservador).    
    Carne (C)    
    Al cambiar el precio por kilo:    
    Se recalcula el monto_producto usando:    
    kilos * precio_nuevo        
    Aplica siempre, ya que el precio de la carne es dinámico.
    La deuda refleja el precio vigente más reciente de la carne.

💵 Funcionamiento de los PAGOS

    Una deuda puede tener múltiples pagos parciales.    
    Cada pago se registra en la tabla pagos con:    
    Fecha    
    Monto abonado    
    El saldo de la deuda se calcula como:    
    total_deuda - SUM(pagos)    
    
    Cuando el saldo llega a cero:    
    La deuda se marca como saldada.
    📄 Visualización del detalle de deuda    
    El detalle de una deuda muestra:    
    Productos vendidos (cantidad o kilos + monto)
    
    Pagos realizados
    El orden se obtiene combinando ambos mediante UNION ALL    
    Permite ver claramente:    
    Qué se compró    
    Cuánto se pagó    
    Cuánto resta pagar 
Deudas → reflejan cambios de precio según reglas.

Pagos → descuentan el total hasta saldar la deuda.
