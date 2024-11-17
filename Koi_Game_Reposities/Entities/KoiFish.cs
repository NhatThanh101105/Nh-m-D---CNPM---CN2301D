using System;
using System.Collections.Generic;

namespace Koi_Game_Reposities.Entities;

public partial class KoiFish
{
    public int KoiId { get; set; }

    public string? KoiName { get; set; }

    public string? Color { get; set; }

    public string? Rare { get; set; }

    public int? Age { get; set; }

    public decimal? Price { get; set; }

    public string? ImageURL { get; set; }

    public virtual ICollection<PlayerKoi> PlayerKois { get; set; } = new List<PlayerKoi>();

    public virtual ICollection<Trade> Trades { get; set; } = new List<Trade>();
}
