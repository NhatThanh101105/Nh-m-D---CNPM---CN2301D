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

        public bool napTien(string username, int VND, string seri)
        {
            
            var player = _playerRepository.GetPlayerByUsername(username);
            if (player == null) { return false; }

            // kiem tra so seri, cho mac dinhh chuoi 00000000
            if (seri != "00000000") { return false; }
            //vnd==20k
            if (VND == 20000)
            {
                player.Coin += 20;
                _playerRepository.UpdatePlayer(player);
                return true;

            }
            //vnd==50k
            else if (VND == 50000)
            {
                player.Coin += 50;
                _playerRepository.UpdatePlayer(player);
                return true;
            }
            //vnd==100k
            else  if(VND == 100000)
            {
                player.Coin += 100;
                _playerRepository.UpdatePlayer(player);
                return true;
            }
            //vnd==200k
            else if (VND == 200000)
            {
                player.Coin += 200;
                _playerRepository.UpdatePlayer(player);
                return true;
            }
            //vnd==500k
            else
            {
                player.Coin += 500;
                _playerRepository.UpdatePlayer(player);
                return true;
            }

        }

        
    }
}
