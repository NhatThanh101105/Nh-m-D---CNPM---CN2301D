using Koi_Game_Reposities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Interfaces
{
    public interface ISinhsanService
    {
        Task<bool> SinhSan (int koiId_1,int koiId_2,int idPlayer);
    }
}
