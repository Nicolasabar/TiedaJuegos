using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaJuegos.Models;

public partial class Producto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
    public string? Nombre { get; set; }


    [Required(ErrorMessage = "El campo Tipo o categoria es obligatorio.")] 
    public int? TipoProductoId { get; set; }

    [Required(ErrorMessage = "El campo Cantidad es obligatorio.")]
    public int? Cantidad { get; set; }

    [Required(ErrorMessage = "El campo Precio es obligatorio.")]
    public decimal? Precio { get; set; }

    public virtual TipoProducto? TipoProducto { get; set; }


}
