using Koi_Game_Reposities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Interfaces
{
    public interface ITradeService
    {
        List<Trade> getAllTrade(int idplayer);
        bool newTrade(int sellerId, int playerKoiId, decimal price);
        bool cancelTrade(int tradeId);
        Task<bool> trade(int buyerId, int tradeId,int koiId);
        List<Trade> getKoiOnSale(int idplayer);
    }
}
