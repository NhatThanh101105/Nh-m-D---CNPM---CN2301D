using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.DTO;
using Koi_Game_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Class
{
    public class LoginService : ILoginService
    {
        private readonly IPlayerRepository _playerRepository;
        public LoginService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
     
     
        // chuc nang dang nhap
        public  bool Login(string username, string password)
        {
            var player=  _playerRepository.GetPlayerByUsername(username);
            return player != null && player.Password == password;
        }


        // chuc nang dang ki
        public bool Register(string username, string password, string name, string correctPassword)
        {

            //kiem tra xem co trung ten dang nhap khong
            if (_playerRepository.GetPlayerByUsername(username) != null)
            {
                return false;
            }

            //kiem tra xem pass lan 2 co giong pass lan 1 khong
            if (password != correctPassword)
            {
                return false;
            }

            // add player
            var player = new Player
            {
                UserName = username,
                Password = password,
                Name = name,
                Coin = 0
            };
            _playerRepository.AddPlayer(player);
            return true;
            
        }
    }
}
