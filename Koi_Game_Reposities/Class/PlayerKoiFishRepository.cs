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
        public  List<int?> getKoisByIdPlayer(int playerID)
        {
            return   _dbcontext.PlayerKoi.Where(p=>p.PlayerId == playerID).Select(p=>p.KoiId).ToList();
        }
        public void SaveFishToPlayer(PlayerKoi playerKoi)
        {
            _dbcontext.PlayerKoi.Add(playerKoi);
            _dbcontext.SaveChanges();
        }
    }
}
