using Koi_Game_Reposities.Entities;
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
        Task<bool> addKoiToPond(int playerKoiId, int playerPondId,int idplayer);


       Task<bool> removeKoiFromPond(int playerKoiId, int playerPondId,int idplayer);

        List<int> getKoiInPond(int idplayer,int playerPondId);


        // lay ra danh sach cas owr trong hof 
        List<PlayerKoi> GetKoiInPond(int idplayer, int playerPondId);

    }
}
