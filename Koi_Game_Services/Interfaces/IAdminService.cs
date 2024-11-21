using Koi_Game_Reposities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Interfaces
{
    public interface IAdminService
    {
        List<Player> getAllPlayer(int idplayer);
        bool DelPlayer(int idplayer);
    }
}
