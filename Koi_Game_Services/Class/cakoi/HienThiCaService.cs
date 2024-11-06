using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Class.cakoi
{
    public class HienThiCaService : IHienThiCaService
    {
        private readonly IPlayerKoiFishRepository _playerKoiFishRepository;
    //    private readonly IKoiRepository _koiRepository;
        public HienThiCaService(IPlayerKoiFishRepository playerKoiFishRepository)//, IKoiRepository koiRepository)
        {
            _playerKoiFishRepository = playerKoiFishRepository;
         //   _koiRepository = koiRepository;
        }
        public List<int?> getKoiByIdPlayer(int idPlayer)
        {
            return _playerKoiFishRepository.getKoisByIdPlayer(idPlayer);
        }
        /*
        public async Task<string> getImage(int idkoi)
        {
            var koi= await _koiRepository.GetKoiFishById(idkoi);
            return koi.ImageURL;
        }*/
    }
}
