using Koi_Game_Reposities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Reposities.Interfaces
{
    public  interface IKoiRepository
    {
        Task<List<KoiFish>> GetAllKoiFishs();
        Task<KoiFish> GetKoiFishById(int id);

    }
}
