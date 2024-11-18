using System;
using System.Collections.Generic;


namespace Koi_Game_Reposities.Entities;
public partial class GameStatus
{
    //luu trang thai game
    public int gameStatus { get; set; }
    public int idPlayer { get; set; }
    public int PondId { get; set; }
    public int PlayerPondId { get; set; }
}
