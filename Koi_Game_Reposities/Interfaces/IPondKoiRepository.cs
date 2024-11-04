using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Reposities.Interfaces
{
    public interface IPondKoiRepository
    {
        // laays danh sachs id cas koi cua nguoiwf choiw nhungw khong cos matwj trong hoof
        List<int> getKoiPlayer(int playerID);

        // duaw cas vaof hoof
        void addKoiToPond(int playerKoiId, int PondId);
    }
}
