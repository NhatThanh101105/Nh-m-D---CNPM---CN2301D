using Koi_Game_Reposities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Interfaces
{
    public interface IKoiService
    {
        Task<List<KoiFish>> GetAllKoiFishes();
        Task<KoiFish> GetKoiFishById(int id);

        List<KoiFish> GetKoiFishes();
    }
}
