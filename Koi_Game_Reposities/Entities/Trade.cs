using System;
using System.Collections.Generic;

namespace Koi_Game_Reposities.Entities;

public partial class Trade
{
    public int TradeId { get; set; }

    public int? SellerId { get; set; }

    public int? BuyerId { get; set; }

    public int? KoiId { get; set; }

    public decimal? Price { get; set; }

    public virtual Player? Buyer { get; set; }

    public virtual KoiFish? Koi { get; set; }

    public virtual Player? Seller { get; set; }
}
