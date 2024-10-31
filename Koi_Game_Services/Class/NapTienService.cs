using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Class
{
    public class NapTienService: INapTienService
    {
        private readonly IPlayerRepository _playerRepository;
        public NapTienService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public bool napTien(string username, int coin)
        {
            var player = _playerRepository.GetPlayerByUsername(username);
            if (player == null) { return false; }
            if (coin <= 0)
            {
                return false ;
            }
             player.Coin += coin;
            _playerRepository.UpdatePlayer(player);
            return true;
        }

        
    }
}
