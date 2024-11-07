using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Reposities.Entities;
public partial class GameStatus
{
    //luu trang thai game
    public int gameSatus { get; set; }
    public int idPlayer { get; set; }
    public int PondId { get; set; }
    public int PlayerPondId { get; set; }
}

