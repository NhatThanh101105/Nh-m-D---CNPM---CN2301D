using Koi_Game_Reposities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Interfaces
{
    public interface IGameStatusService
    {
        

        void saveGame(int idplayer, int pondId, int playerPondId);
        GameStatus getPlayerStatus(int idplayer);
    }
}
