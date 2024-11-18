using System;
using System.Collections.Generic;


namespace Koi_Game_Reposities.Entities;

public partial class PlayerPond
{
    public int PlayerPondId { get; set; }
    public int PlayerId { get; set; }
    public int PondId { get; set; }
    public virtual Player Player { get; set; } = null!;
    public virtual Pond Pond { get; set; } = null!;
    public virtual ICollection<PondKoi> PondKois { get; set; } = new List<PondKoi>();
}
