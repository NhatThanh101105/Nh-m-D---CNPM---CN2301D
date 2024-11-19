using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Class.trade
{
    public class TradeService : ITradeService
    {
        private readonly ITradeRepository _tradeRepository;
        private readonly IPlayerService _playerService;
        private readonly IAddKoiToPlayerService _addKoiToPlayerService;
        private readonly IPlayerKoiFishRepository _playerKoiFishRepository;
        public TradeService(ITradeRepository tradeRepository,IPlayerService playerService, IAddKoiToPlayerService addKoiToPlayerService, IPlayerKoiFishRepository playerKoiFishRepository)
        {
            _tradeRepository = tradeRepository;
            _playerService = playerService;
            _addKoiToPlayerService = addKoiToPlayerService;
            _playerKoiFishRepository = playerKoiFishRepository;
        }
        public bool cancelTrade(int tradeId)
        {
            var trade= _tradeRepository.getTradeById(tradeId);
            if (trade==null) return false;

            var playerkoi = _playerKoiFishRepository.getPlayerKoiById((int)trade.PlayerKoiId);
            playerkoi.IsOnTrade = false;
            _playerKoiFishRepository.updatePlayerKoi(playerkoi);

            _tradeRepository.deleteTrade(tradeId);
            return true;
        }

        public List<Trade> getAllTrade(int idplayer)
        {
            return _tradeRepository.getAllTrade(idplayer);
        }

        public bool newTrade(int sellerId, int playerKoiId, decimal price)
        {
            // lay ra playerkoi chinhr cas IsOnTrade nguowif choiw thanhf true sau ddos luuw laij
            var playerkoi= _playerKoiFishRepository.getPlayerKoiById(playerKoiId);
            if (playerkoi == null || playerkoi.IsOnTrade) return false;

            playerkoi.IsOnTrade = true;
            _playerKoiFishRepository.updatePlayerKoi(playerkoi);

            var trade = new Trade
            {
                SellerId = sellerId,
                PlayerKoiId=playerKoiId,
                Price = price
            };
            _tradeRepository.newTrade(trade);
            return true;
        }

        public async Task<bool> trade(int buyerId, int tradeId,int koiId)
        {
            var trade= _tradeRepository.getTradeById(tradeId);
            if (trade == null) { return false ; }
            var buyer= await _playerService.GetPlayer(buyerId); 
            if (buyer.Coin < trade.Price)
            {
                return false;
            }
            // truwf tienf nguowif mua, vaf add ca cho nguowif mua
            _addKoiToPlayerService.AddKoiToPlayer(buyerId, koiId);
            decimal chietkhau = 0.4m;
            buyer.Coin -= trade.Price;
            _playerService.UpdatePlayer(buyer);

            // cong tien cho nguowif bans vaf xoas cas cua nguoiwf bans
            var seller= await _playerService.GetPlayer((int)trade.SellerId);
            seller.Coin+=trade.Price*chietkhau;
            _playerService.UpdatePlayer(seller);
            _addKoiToPlayerService.RemoveKoiFromPlayer((int)trade.PlayerKoiId);


            // xoa giao dichj
            _tradeRepository.deleteTrade(tradeId);

            return true;
             
        }
        public List<Trade> getKoiOnSale(int idplayer)
        {
            return _tradeRepository.getKoiOnSale(idplayer);
        }
    }
}
