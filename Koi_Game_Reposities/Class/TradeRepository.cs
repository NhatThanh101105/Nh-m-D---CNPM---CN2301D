using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Reposities.Class
{
    public class TradeRepository : ITradeRepository
    {
        private readonly KoiGameDatabaseContext _dbcontext;
        public TradeRepository(KoiGameDatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<Trade> getAllTrade(int idplayer)// laay tats car danh sach giao dichj
        {
         //   return _dbcontext.Trades
          //      .Include(t => t.Koi)           // Load the Koi data
           //     .Include(t => t.PlayerKoi)      // Load PlayerKoi if it's being referenced
            //    .Include(t => t.Seller)         // Load the Seller data
             //   .ToList();

            return _dbcontext.Trades
                .Include(t => t.Koi)
                .Include(t => t.PlayerKoi)
                .ThenInclude(pk => pk.Koi)
                .Include(t => t.Seller)
                .Where(t=>t.SellerId!=idplayer).ToList();
        }
        public Trade getTradeById(int tradeId)// timf giao dichj, dungf ddeer lamf ddieuf kienj
        {
            return _dbcontext.Trades
                .Include(t => t.Koi)
                .Include(t => t.Seller)
                .FirstOrDefault(t => t.TradeId == tradeId);

        }

        public void newTrade(Trade trade)// taoj 1 giao dichj moiws
        {
            _dbcontext.Trades.Add(trade);
            _dbcontext.SaveChanges();
       
        }
        public void deleteTrade(int  tradeId)// huyr giao dichj || khi bans thanhf coong tuwj ddoongj xoas
        {
            var trade = _dbcontext.Trades.Find(tradeId);
            if(trade !=null)
            {
                _dbcontext.Trades.Remove(trade);
                _dbcontext.SaveChanges();
            }
        }
        public List<Trade> getKoiOnSale(int idplayer)
        {
            return _dbcontext.Trades
            .Include(t => t.Koi)
            .ThenInclude(k => k.PlayerKois)
            .Where(t => t.SellerId == idplayer && t.BuyerId == null)
            .ToList();
        }
    }
}
