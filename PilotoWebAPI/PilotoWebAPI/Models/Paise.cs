using System;
using System.Collections.Generic;

namespace PilotoWebAPI.Models;

public partial class Paise
{
    public int IdPais { get; set; }

    public string? Pais { get; set; }

    public virtual ICollection<Piloto> Pilotos { get; set; } = new List<Piloto>();
}
