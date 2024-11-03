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
    public class AddKoiToPlayerService : IAddKoiToPlayerService
    {
        private readonly IKoiRepository _koiRepository;
        private readonly IPlayerRepository _playerRepository;
        public AddKoiToPlayerService(IKoiRepository koiRepository, IPlayerRepository playerRepository)
        {
            _koiRepository = koiRepository;
            _playerRepository = playerRepository;
        }
        public void AddKoiToPlayer(int idPlayer, int idKoi)
        {
            // kiem tra nguowi choiw va cas 
            var koi=_koiRepository.GetKoiFishById(idKoi);
            var player = _playerRepository.GetPlayer(idPlayer);

            // dat cho vui chuws cais nayf chacws chanw vao  
            if (koi!=null && player!=null)
            {
                var playerKoi = new PlayerKoi
                {
                    KoiId = idKoi,
                    PlayerId = idPlayer,
                };
                _koiRepository.SaveFishToPlayer(playerKoi);
            }
        }
    }
}
