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

        public async Task<List<Player>> GetAllPlayer()
        {
            return await _dbcontext.Players.ToListAsync();
        }
        public void AddPlayer(Player player)
        {
            _dbcontext.Players.Add(player);
            _dbcontext.SaveChanges();
        }

        public void DelPlayer(Player player)
        {
            _dbcontext.Players.Remove(player);
            _dbcontext.SaveChanges();
        }

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

    }
}
