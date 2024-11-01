using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Interfaces
{
    public interface IAddKoiToPlayerService
    {

        void AddKoiToPlayer(int idPlayer,int idKoi);
    }
}
