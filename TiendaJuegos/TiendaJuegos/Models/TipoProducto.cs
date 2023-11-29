using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaJuegos.Models;

public partial class TipoProducto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
    public string? Nombre { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
