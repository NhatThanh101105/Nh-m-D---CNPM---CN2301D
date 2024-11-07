using System;
using System.Collections.Generic;


namespace Koi_Game_Reposities.Entities;

public class PondKoi
{
    public int PondKoiId { get; set; }
    public int PlayerPondId { get; set; }           // Hồ hiện tại của cá
    public int PlayerKoiId { get; set; }             // Cá của người chơi

    public virtual PlayerPond PlayerPond { get; set; } = null!;
    public virtual PlayerKoi PlayerKoi { get; set; } = null!;
}
