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

        public async Task<bool> addKoiToPond(int playerKoiId, int playerPondId,int idplayer)
        {
            return await _pondKoiRepository.addKoiToPond(playerKoiId,playerPondId,idplayer);
        }

        public async Task<bool> removeKoiFromPond(int playerKoiId,int playerPondId, int  idplayer)
        {
            return await _pondKoiRepository.removeKoiFromPond(playerKoiId ,playerPondId,idplayer);
        }
    }
}
