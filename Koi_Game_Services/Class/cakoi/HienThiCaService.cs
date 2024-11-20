using Koi_Game_Reposities.Entities;
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
        private readonly IPondKoiRepository _pondKoiRepository;
    //    private readonly IKoiRepository _koiRepository;
        public HienThiCaService(IPlayerKoiFishRepository playerKoiFishRepository, IPondKoiRepository pondKoiRepository)//, IKoiRepository koiRepository)
        {
            _playerKoiFishRepository = playerKoiFishRepository;
            _pondKoiRepository = pondKoiRepository;
         //   _koiRepository = koiRepository;
        }

        public List<PlayerKoi> GetKoiInPond(int idplayer,int playerPondId)
        {
            return _pondKoiRepository.GetKoiInPond(idplayer, playerPondId);
        }

        public List<PlayerKoi> getAllKoiPlayer(int idplayer)
        {
            return _playerKoiFishRepository.getAllKoiPlayer(idplayer);
        }
    }
}
