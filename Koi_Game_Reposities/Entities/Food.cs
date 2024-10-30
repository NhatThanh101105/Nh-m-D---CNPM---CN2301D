using System;
using System.Collections.Generic;

namespace Koi_Game_Reposities.Entities;

public partial class Food
{
    public string FoodId { get; set; } = null!;

    public string? FoodName { get; set; }

    public string? FoodType { get; set; }

    public decimal? FoodPrice { get; set; }
}
