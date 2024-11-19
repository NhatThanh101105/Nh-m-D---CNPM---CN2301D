using Koi_Game_Reposities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Reposities.Interfaces
{
    public interface IPlayerPondRepository
    {
        //List<PlayerPond> getPlayerPond(int idplayer);
        int getPlayerPondId(int idplayer,int pondId);

        void addPondToPlayer(int idplayer, int pondId);
    }
}
