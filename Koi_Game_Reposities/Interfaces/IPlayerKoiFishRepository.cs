using Koi_Game_Reposities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Reposities.Interfaces
{
    public  interface IPlayerKoiFishRepository
    {
        List<int?> getKoisByIdPlayer(int playerID);
        void SaveFishToPlayer(PlayerKoi playerKoi);
        void RemoveFishFromPlayer(PlayerKoi playerKoi);

        void updatePlayerKoi(PlayerKoi playerKoi);

        PlayerKoi getPlayerKoiById(int playerKoiId);
        List<PlayerKoi> getAllKoiPlayer(int idplayer);

        int getPlayerKoiId(int idplayer, int KoiId);
    }
}
