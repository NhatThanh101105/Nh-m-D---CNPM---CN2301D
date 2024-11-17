using System;
using System.Collections.Generic;

namespace Koi_Game_Reposities.Entities;

public partial class Pond
{
    public int PondId { get; set; }

    public string? Size { get; set; }

    public int? Capacity { get; set; }

    public decimal? Price { get; set; }
    public int Level { get; set; } = 1;
    public virtual ICollection<PondKoi> PondKois { get; set; } = new List<PondKoi>();
    public virtual ICollection<PlayerPond> PlayerPonds { get; set; } = new List<PlayerPond>();
}

