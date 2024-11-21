using Koi_Game_Reposities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Reposities.Interfaces
{
    public interface ITradeRepository
    {
        void newTrade(Trade trade);
        void deleteTrade(int TradeId);
        List<Trade> getAllTrade(int idplayer);
        Trade getTradeById(int TradeId);        
        List< Trade> getKoiOnSale(int idplayer); 
    }
}
