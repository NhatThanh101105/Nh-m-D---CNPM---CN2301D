using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Interfaces
{
    public interface IGameStatusService
    {
        int getPondId(int idplayer);
        int getPlayerPondId(int idplayer);

        void saveGame(int idplayer, int pondId, int playerPondId);
    }
}
