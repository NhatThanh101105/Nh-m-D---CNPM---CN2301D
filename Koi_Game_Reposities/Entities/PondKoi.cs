using System;
using System.Collections.Generic;


namespace Koi_Game_Reposities.Entities
{
    public class PondKoi
    {
        public int PondKoiId { get; set; }
        public int PondId { get; set; }           // Hồ hiện tại của cá
        public int PlayerKoiId { get; set; }      // Cá của người chơi

        public virtual Pond Pond { get; set; } = null!;
        public virtual PlayerKoi PlayerKoi { get; set; } = null!;
    }
}
