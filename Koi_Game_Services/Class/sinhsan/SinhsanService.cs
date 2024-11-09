using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Class.sinhsan
{
    public class SinhsanService : ISinhsanService
    {
        private readonly IKoiRepository _koiRepository;
        private readonly ILogicSinhsanService _logicSinhsanService;
        private readonly IAddKoiToPlayerService _addKoiToPlayerService;
        public SinhsanService(IKoiRepository koiRepository, ILogicSinhsanService logicSinhsanService, IAddKoiToPlayerService addKoiToPlayerService)
        {
            _koiRepository = koiRepository;
            _logicSinhsanService = logicSinhsanService;
            _addKoiToPlayerService = addKoiToPlayerService;
        }
        public async Task<bool> SinhSan(int koiId_1, int koiId_2, int idPlayer)
        {
            var koi_1 = await _koiRepository.GetKoiFishById(koiId_1);
            var koi_2 = await _koiRepository.GetKoiFishById(koiId_2);
            if (koi_1 == null || koi_2 == null)
            {
                return false;
            }

            int id_koi_con = await _logicSinhsanService.GetIdKoi_SauSinh(koi_1.Color, koi_2.Color);

            _addKoiToPlayerService.AddKoiToPlayer(idPlayer, id_koi_con);

            return true;
        }
    }
}
