using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Interfaces
{
    public interface ILogicSinhsanService
    {
        Task<int> GetIdKoi_SauSinh(string color_1,string color_2);
    }
}
