using System;
using System.Collections.Generic;

namespace Koi_Game_Reposities.Entities;

public partial class PlayerKoiFish
{
    public int PlayerKoiFishId { get; set; }

    public int? PlayerId { get; set; }

    public int? KoiId { get; set; }

    public virtual KoiFish? Koi { get; set; }
}
