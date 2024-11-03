using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.DTO;
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
        private readonly IPlayerRepository _playerRepository;

        public XuLiNhanCaLanDau(IKoiRepository koiRepository,IPlayerRepository playerRepository)
        {
            _koiRepository = koiRepository;
            _playerRepository = playerRepository;
        }

        public async Task<List<int>> getThreeKois()
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
        public async Task<bool> kiemtraNewPlayer(int idPlayer)
        {
            var player=  await _playerRepository.GetPlayer(idPlayer);
            if (player == null) return false;
            if (player.IsNewPlayer == true)
            {
                player.IsNewPlayer = false;
                _playerRepository.UpdatePlayer(player);
                return true;
            }
            return false;

        }
    }
}
