using System;
using System.Collections.Generic;

namespace Koi_Game_Reposities.Entities;

public partial class KoiFish
{
    public int KoiId { get; set; }

    public string? KoiName { get; set; }

    public string? KoiColor { get; set; }

    public int? KoiAge { get; set; }

    public string? KoiRare { get; set; }

    public string? KoiGen { get; set; }

    public decimal? KoiPrice { get; set; }

    public virtual ICollection<PlayerKoiFish> PlayerKoiFishes { get; set; } = new List<PlayerKoiFish>();
}
