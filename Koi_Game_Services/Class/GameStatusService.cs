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
    public class GameStatusService : IGameStatusService
    {
        private readonly IGameStatusRepository _gameStatusRepository;
        public GameStatusService(IGameStatusRepository gameStatusRepository)
        {
            _gameStatusRepository = gameStatusRepository;
        }

        public void saveGame(int idplayer, int pondId, int playerPondId)
        {
            _gameStatusRepository.saveGame(idplayer, pondId, playerPondId);
        }
        public GameStatus getPlayerStatus (int idplayer)
        {
            return _gameStatusRepository.getPlayerStatus(idplayer);
        }
    }
}
