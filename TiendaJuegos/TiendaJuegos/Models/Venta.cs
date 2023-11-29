using System;
using System.Collections.Generic;

namespace TiendaJuegos.Models;

public partial class Venta
{
    public int IdCompra { get; set; }

    public int? VendedorId { get; set; }

    public string? ProductosVendidos { get; set; }

    public decimal? MontoTotal { get; set; }

    public DateOnly? FechaCompra { get; set; }

    public virtual Trabajadore? Vendedor { get; set; }


}
