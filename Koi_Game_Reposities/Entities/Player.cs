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

    public bool IsNewPlayer { get; set; } = true; // Mặc định là true cho người chơi mới

    public DateTime? SinhSan { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();//

    public virtual ICollection<PlayerKoi> PlayerKois { get; set; } = new List<PlayerKoi>();//

    public virtual ICollection<Trade> TradeBuyers { get; set; } = new List<Trade>();

    public virtual ICollection<Trade> TradeSellers { get; set; } = new List<Trade>();
    public virtual ICollection<PlayerPond> PlayerPonds { get; set; } = new List<PlayerPond>();
}
