using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Class.pond
{
    public class PondKoiService : IPondKoiService
    {
        private readonly IPondKoiRepository _pondKoiRepository;
        public PondKoiService(IPondKoiRepository pondKoiRepository)
        {
            _pondKoiRepository = pondKoiRepository;
        }

        public void addKoiToPond(int playerId, int pondId)
        {
            _pondKoiRepository.addKoiToPond(playerId, pondId);
        }

        public List<int> getKoiPlayer(int playerId)
        {
            return _pondKoiRepository.getKoiPlayer(playerId);
        }
    }
}
