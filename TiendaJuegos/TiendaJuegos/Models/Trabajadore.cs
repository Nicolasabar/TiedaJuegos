using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaJuegos.Models;

public partial class Trabajadore
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El número de rut es obligatorio.")]
    public string? Rut { get; set; }


    // Para las validaciones mas basicas y que pueden ser expresadas bajo anotaciones de datos agregar en el modelo
    [Required(ErrorMessage = "El número de celular es obligatorio.")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "El número de celular debe tener exactamente 8 dígitos.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "El número de celular debe contener solo dígitos.")]
    public string? NumeroCelular { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string? Nombres { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    public string? Apellidos { get; set; }

    [Required(ErrorMessage = "La fecha de nacimiento es obligatorio.")]
    public DateOnly? FechaNacimiento { get; set; }

    // Validador de correo integrago en asp.net
    [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
    public string? Correo { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
