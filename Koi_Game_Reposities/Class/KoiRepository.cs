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
    public class KoiRepository : IKoiRepository
    {
        private readonly KoiGameDatabaseContext _dbcontext;
        public KoiRepository(KoiGameDatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<KoiFish>> GetAllKoiFishs()
        {
            return await _dbcontext.KoiFishes.ToListAsync();
        }

        public async Task<KoiFish> GetKoiFishById(int id)
        {
            return await _dbcontext.KoiFishes.FindAsync(id);
        }
        // lay ra 3 con ca 
        public async Task<List<KoiFish>> GetThreeKois()
        {
            return await _dbcontext.KoiFishes.Take(3).ToListAsync();
        }

        public void SaveFishToPlayer(PlayerKoi playerKoi)
        {
            _dbcontext.PlayerKois.Add(playerKoi);
            _dbcontext.SaveChanges();
        }
    }
}
