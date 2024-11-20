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
    public class PlayerPondService: IPlayerPondService
    {
        private readonly IPlayerPondRepository _playerPondRepository;
        public PlayerPondService(IPlayerPondRepository playerPondRepository)
        {
            _playerPondRepository = playerPondRepository;
        }
       // public List<PlayerPond> getPlayerPond(int idplayer)
        //{
        //    return _playerPondRepository.getPlayerPond(idplayer);
        //}
        public int getPlayerPondId(int idplayer, int pondId)
        {
            return _playerPondRepository.getPlayerPondId(idplayer, pondId);
        }
        public void addPondToPlayer(int idplayer, int pondId)
        {
            _playerPondRepository.addPondToPlayer(idplayer, pondId);
        }
    }
}
