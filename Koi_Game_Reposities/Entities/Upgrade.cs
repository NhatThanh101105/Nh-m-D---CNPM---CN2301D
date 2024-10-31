using System;
using System.Collections.Generic;

namespace Koi_Game_Reposities.Entities;

public partial class Upgrade
{
    public int UpgradeId { get; set; }

    public string? UpgradeName { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }
}
