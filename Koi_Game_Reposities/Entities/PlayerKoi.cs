using System;
using System.Collections.Generic;

namespace Koi_Game_Reposities.Entities;

public partial class PlayerKoi
{
    public int PlayerKoiId { get; set; }

    public int? PlayerId { get; set; }

    public int? KoiId { get; set; }

    public virtual KoiFish? Koi { get; set; }

    public virtual Player? Player { get; set; }
    public virtual ICollection<PondKoi> PondKois { get; set; } = new List<PondKoi>();
}
