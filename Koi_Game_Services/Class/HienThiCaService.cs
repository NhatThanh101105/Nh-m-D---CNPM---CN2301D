using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Class
{
    public class HienThiCaService:IHienThiCaService
    {
        private readonly IPlayerKoiFishRepository _playerKoiFishRepository;
        public HienThiCaService(IPlayerKoiFishRepository playerKoiFishRepository)
        {
            _playerKoiFishRepository = playerKoiFishRepository;
        }
        public List<int?> getKoiByIdPlayer(int idPlayer)
        {
            return _playerKoiFishRepository.getKoisByIdPlayer(idPlayer);
        }
    }
}
