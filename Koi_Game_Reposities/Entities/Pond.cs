using System;
using System.Collections.Generic;

namespace Koi_Game_Reposities.Entities;

public partial class Pond
{
    public int PondId { get; set; }

    public string? PondName { get; set; }

    public int? Level { get; set; }

    public int? Size { get; set; }

    public decimal? PondPrice { get; set; }
}
