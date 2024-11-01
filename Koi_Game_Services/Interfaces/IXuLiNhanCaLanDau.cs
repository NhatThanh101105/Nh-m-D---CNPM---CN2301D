using Koi_Game_Reposities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Interfaces
{

    public interface IXuLiNhanCaLanDau
    { 
        Task<List<KoiFish>> getThreeKois();
        void NhanCa(int idPlayer, List<int> idkois);
    }
}
