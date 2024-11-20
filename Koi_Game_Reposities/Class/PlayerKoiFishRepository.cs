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
    public class PlayerKoiFishRepository : IPlayerKoiFishRepository
    {
        private readonly KoiGameDatabaseContext _dbcontext;

        public PlayerKoiFishRepository(KoiGameDatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
 
        public PlayerKoi getPlayerKoiById(int playerKoiId)
        {
            return _dbcontext.PlayerKoi.FirstOrDefault(pk => pk.PlayerKoiId == playerKoiId);
        }
        public void SaveFishToPlayer(PlayerKoi playerKoi)
        {
            _dbcontext.PlayerKoi.Add(playerKoi);
            _dbcontext.SaveChanges();
        }
        public void RemoveFishFromPlayer(PlayerKoi playerKoi)
        {
            _dbcontext.PlayerKoi.Remove(playerKoi);
            _dbcontext.SaveChanges();
        }

        public void updatePlayerKoi(PlayerKoi playerKoi)
        {
            _dbcontext.PlayerKoi.Update(playerKoi);
            _dbcontext.SaveChanges();
        }

        public List<PlayerKoi> getAllKoiPlayer(int idplayer)
        {
            return _dbcontext.PlayerKoi 
                .Include(pk => pk.Koi)   
                .Where(pk => pk.PlayerId == idplayer)
                .ToList();
        }

    }
}
