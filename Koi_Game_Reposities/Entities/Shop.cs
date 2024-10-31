using System;
using System.Collections.Generic;

namespace Koi_Game_Reposities.Entities;

public partial class Shop
{
    public int ShopId { get; set; }

    public int? ItemId { get; set; }

    public string? ItemType { get; set; }

    public string? ItemName { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }
}
