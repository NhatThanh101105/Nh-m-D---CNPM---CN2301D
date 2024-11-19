using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Class.player
{
    public class AddKoiToPlayerService : IAddKoiToPlayerService
    {
        private readonly IKoiRepository _koiRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IPlayerKoiFishRepository _playerFishRepository;
        public AddKoiToPlayerService(IKoiRepository koiRepository, IPlayerRepository playerRepository, IPlayerKoiFishRepository playerFishRepository)
        {
            _koiRepository = koiRepository;
            _playerRepository = playerRepository;
            _playerFishRepository = playerFishRepository;
        }
        public void AddKoiToPlayer(int idPlayer, int idKoi)
        {
            // kiem tra nguowi choiw va cas 
            var koi = _koiRepository.GetKoiFishById(idKoi);
            var player = _playerRepository.GetPlayer(idPlayer);

            // dat cho vui chuws cais nayf chacws chanw vao  
            if (koi != null && player != null)
            {
                var playerKoi = new PlayerKoi
                {
                    KoiId = idKoi,
                    PlayerId = idPlayer,
                };
                _playerFishRepository.SaveFishToPlayer(playerKoi);
            }
        }

 
        public void RemoveKoiFromPlayer(int playerKoiId)
        {

 
            var playerkoi=_playerFishRepository.getPlayerKoiById(playerKoiId);
            if(playerkoi!=null)
            {
                _playerFishRepository.RemoveFishFromPlayer(playerkoi);
            }
        }
    }
}
