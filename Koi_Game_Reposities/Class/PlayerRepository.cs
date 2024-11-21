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
    public class PlayerRepository : IPlayerRepository
    {

        private readonly KoiGameDatabaseContext _dbcontext;

        public PlayerRepository(KoiGameDatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

  //      public async Task<List<Player>> GetAllPlayer()
    //    {
      //      return await _dbcontext.Players.ToListAsync();
        //}
        public void AddPlayer(Player player)
        {
            _dbcontext.Players.Add(player);
            _dbcontext.SaveChanges();
        }

//        public void DelPlayer(Player player)
  //      {
    //        _dbcontext.Players.Remove(player);
      //      _dbcontext.SaveChanges();
        //}

        public async Task<Player> GetPlayer(int id)
        {
           return await _dbcontext.Players.FindAsync(id); 
        }

        public void UpdatePlayer(Player player)
        {
            _dbcontext.Players.Update(player);
            _dbcontext.SaveChanges();
        }

        public  Player  GetPlayerByUsername(string username)
        {
            return _dbcontext.Players.FirstOrDefault(p => p.UserName==username);
        }
        public List<Player> GetAllPlayer(int idplayer)
        {
            return _dbcontext.Players
                .Include(p=>p.PlayerKois)
                .Where(p=>p.PlayerId!=idplayer)
                .ToList();
        }
        public bool DelPlayer(int idplayer)
        {
            var player = _dbcontext.Players
                .Include(p=>p.PlayerKois)// lấy theo dánh sahc playerkoi
                .ThenInclude(pk=>pk.PondKois)// truy vấn luôn danh sách pondkoi
                .Include(p=>p.Inventories)// láy theo danh sách túi đồ 
                .Include(p=>p.TradeBuyers)// lkaays danh sách trade
                .Include(p=>p.TradeSellers)// lấy danh sách trade
                .Include(p=>p.PlayerPonds)// láy danh sách playerpond
                .ThenInclude(pp => pp.PondKois)// kèm theo pondkoi
                .FirstOrDefault(p=>p.PlayerId==idplayer);


            if (player == null)
            {
                return false;
            }
            foreach (var pond in player.PlayerPonds)
            {
                _dbcontext.PondKois.RemoveRange(pond.PondKois);
            }

            // Xóa PlayerPonds
            _dbcontext.PlayerPonds.RemoveRange(player.PlayerPonds);

            // Xóa PondKois trong PlayerKois
            foreach (var playerKoi in player.PlayerKois)
            {
                _dbcontext.PondKois.RemoveRange(playerKoi.PondKois);
            }

            // Xóa PlayerKois
            _dbcontext.PlayerKoi.RemoveRange(player.PlayerKois);

            // Xóa Inventories
            _dbcontext.Inventories.RemoveRange(player.Inventories);

            // Xóa TradeBuyers
            _dbcontext.Trades.RemoveRange(player.TradeBuyers);

            // Xóa TradeSellers
            _dbcontext.Trades.RemoveRange(player.TradeSellers);

            // Xóa Player
            _dbcontext.Players.Remove(player);

            // Lưu thay đổi
            _dbcontext.SaveChanges();
           
            return true;
        }
    }
}
