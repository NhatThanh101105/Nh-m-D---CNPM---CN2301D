using System;
using System.Collections.Generic;

namespace Koi_Game_Reposities.Entities;

public partial class Player
{
    public int PlayerId { get; set; }

    public string? Name { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public decimal? Coin { get; set; }

    public virtual ICollection<Trade> TradeBuyers { get; set; } = new List<Trade>();

    public virtual ICollection<Trade> TradeSellers { get; set; } = new List<Trade>();
}
