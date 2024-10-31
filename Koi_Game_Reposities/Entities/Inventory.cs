using System;
using System.Collections.Generic;

namespace Koi_Game_Reposities.Entities;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public int? PlayerId { get; set; }

    public int? ItemId { get; set; }

    public string? ItemType { get; set; }

    public int? Quantity { get; set; }

    public virtual Player? Player { get; set; }
}
