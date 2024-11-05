using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.DTO;
using Koi_Game_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Class.nhanca_newplayer
{
    public class XuLiNhanCaLanDau : IXuLiNhanCaLanDau
    {
        private readonly IKoiRepository _koiRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IInventoryService _inventoryService;
        private readonly IPlayerKoiFishRepository _playerKoiFishRepository;

        public XuLiNhanCaLanDau(IKoiRepository koiRepository, IPlayerRepository playerRepository, IInventoryService inventoryService, IPlayerKoiFishRepository playerKoiFishRepository)
        {
            _koiRepository = koiRepository;
            _playerRepository = playerRepository;
            _inventoryService = inventoryService;
            _playerKoiFishRepository = playerKoiFishRepository;
        }

        public async Task<List<int>> getThreeKois()
        {
            return await _koiRepository.GetThreeKois();
        }
        public void NhanCa(int idPlayer, List<int> idkois)
        {

            // ham nay dung der nhaanj cas
            //tái sử dụng vào lần sau như khi nhận cá sau sinh, mua cá
            foreach (var koiId in idkois)
            {
                var playerKoi = new PlayerKoi
                {
                    PlayerId = idPlayer,
                    KoiId = koiId
                };

                _playerKoiFishRepository.SaveFishToPlayer(playerKoi);
            }
        }
        public async Task<bool> kiemtraNewPlayer(int idPlayer)
        {
            //kiem tra nguoi xem co phair ngupiw choiw mowis k
            var player = await _playerRepository.GetPlayer(idPlayer);
            if (player == null) return false;
            if (player.IsNewPlayer == true)
            {
                player.IsNewPlayer = false;
                _playerRepository.UpdatePlayer(player);


                //doan nay neuw laf nguoi choi moiw thif cho nhan them 1 cai hof macj dinhj
                _inventoryService.addItem(idPlayer, 1,"ho",1);

                return true;
            }
            return false;

        }
    }
}
