using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Class
{
    public class KoiService : IKoiService
    {
        private readonly IKoiRepository _koiRepository;
        private readonly KoiGameDatabaseContext _context; // Định nghĩa _context

        public KoiService(IKoiRepository koiRepository, KoiGameDatabaseContext context) // Nhận context qua DI
        {
            _koiRepository = koiRepository;
            _context = context; // Khởi tạo _context
        }

        public async Task<List<KoiFish>> GetAllKoiFishes()
        {
            return await _koiRepository.GetAllKoiFishs();
        }

        public async Task<KoiFish> GetKoiFishById(int id)
        {
            return await _koiRepository.GetKoiFishById(id);
        }

        public List<KoiFish> GetKoiFishes()
        {
            // Truy vấn cơ sở dữ liệu để lấy danh sách cá Koi
            var koiFishes = _context.KoiFishes.ToList(); // Lấy danh sách từ cơ sở dữ liệu
            return koiFishes; // Trả về danh sách cá Koi
        }

        public async Task<string> GetKoiImagePath(int koiId)
        {
            return await _koiRepository.GetKoiImageURLById(koiId);
        }
    }
}
