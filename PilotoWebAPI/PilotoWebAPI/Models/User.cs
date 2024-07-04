using System;
using System.Collections.Generic;

namespace PilotoWebAPI.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserEmail { get; set; } = null!;

    public string Password { get; set; } = null!;
}
