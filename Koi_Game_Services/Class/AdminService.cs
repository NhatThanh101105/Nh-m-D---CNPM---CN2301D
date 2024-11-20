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
    public class AdminService : IAdminService
    {
        private readonly IPlayerRepository _playerRepository;
        public AdminService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public List<Player> getAllPlayer(int idplayer)
        {
            var player = _playerRepository.GetAllPlayer(idplayer);
            return player;
        }
        public bool DelPlayer(int idplayer)
        {
            return _playerRepository.DelPlayer(idplayer);
        }
    }
}
