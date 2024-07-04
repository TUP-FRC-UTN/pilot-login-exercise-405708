using System;
using System.Collections.Generic;

namespace PilotoWebAPI.Models;

public partial class Piloto
{
    public int IdPiloto { get; set; }

    public string? Nombre { get; set; }

    public int? CantHrVuelo { get; set; }

    public string? Email { get; set; }

    public int? Pais { get; set; }

    public virtual Paise? PaisNavigation { get; set; }
}
