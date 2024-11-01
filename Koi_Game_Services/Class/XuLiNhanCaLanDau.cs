using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Class
{
    public class XuLiNhanCaLanDau : IXuLiNhanCaLanDau
    {
        private readonly IKoiRepository _koiRepository;
        public XuLiNhanCaLanDau(IKoiRepository koiRepository)
        {
            _koiRepository = koiRepository;
        }

        public async Task<List<KoiFish>> getThreeKois()
        {
            return await _koiRepository.GetThreeKois();
        }
        public void NhanCa(int idPlayer, List<int> idkois)
        {
            foreach (var koiId in idkois)
            {
                var playerKoi = new PlayerKoi
                {
                    PlayerId = idPlayer,
                    KoiId = koiId
                };

                _koiRepository.SaveFishToPlayer(playerKoi);
            }
        }
    }
}
