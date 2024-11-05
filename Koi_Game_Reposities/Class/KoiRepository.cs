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

        // Lấy ra 3 con cá
        public async Task<List<int>> GetThreeKois()
        {
            var allKois = await GetAllKoiFishs();
            var selectKois = allKois
                .Where(k => k.KoiId == 1 || k.KoiId == 2 || k.KoiId == 3) // Lấy ID cá
                .Select(k => k.KoiId)
                .ToList();
            // Trả về danh sách ID cá koi
            return selectKois;
        }

        public void SaveFishToPlayer(PlayerKoi playerKoi)
        {
            _dbcontext.PlayerKoi.Add(playerKoi);
            _dbcontext.SaveChanges();
        }

        public async Task<string> GetKoiImageURLById(int koiId)
        {
            var koiFish = await _dbcontext.KoiFishes.FindAsync(koiId); // Thay _context bằng _dbcontext
            return koiFish?.ImageURL; // Giả sử có thuộc tính ImageURL trong KoiFish
        }
    }
}
