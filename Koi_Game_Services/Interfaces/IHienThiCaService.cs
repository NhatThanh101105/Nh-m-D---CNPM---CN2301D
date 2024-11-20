using Koi_Game_Reposities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Interfaces
{
    public interface IHienThiCaService
    {
    

      //  Task<string> getImage(int idkoi);

        List<PlayerKoi> GetKoiInPond(int idPlayer,int playerPondId);

        List<PlayerKoi> getAllKoiPlayer(int idplayer);


    }
}
