using System;
using System.Collections.Generic;

namespace Practica2.Models;

public partial class Persona
{
    public int? NoControl { get; set; }

    public string? Nombre { get; set; }

    public string? Domicilio { get; set; }

    public string? Ciudad { get; set; }

    public decimal? Edad { get; set; }

    public string? Oficio { get; set; }

    public int? PersonaId { get; set; }
}
