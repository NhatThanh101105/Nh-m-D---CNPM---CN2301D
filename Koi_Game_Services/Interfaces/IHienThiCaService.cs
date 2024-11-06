using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Interfaces
{
    public interface IHienThiCaService
    {
        List<int?> getKoiByIdPlayer(int idPlayer);

      //  Task<string> getImage(int idkoi);
    }
}
