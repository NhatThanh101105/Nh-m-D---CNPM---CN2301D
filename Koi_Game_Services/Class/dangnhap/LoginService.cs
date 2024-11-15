using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.DTO;
using Koi_Game_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Class.dangnhap
{
    public class LoginService : ILoginService
    {
        private readonly IPlayerRepository _playerRepository;
        public LoginService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }


        // chuc nang dang nhap
        public Player Login(string username, string password)
        {
            var player = _playerRepository.GetPlayerByUsername(username);
            if (player != null)
            {
                password = password.Trim();
                if (string.Equals(player.Password.Trim(), password, StringComparison.Ordinal))
                {
                    return player;
                }
            }
            return null;

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
        public bool QuenMatKhau(string username, string otp, string newpass, string confirmpass) 
        {
            if (otp != "12345678") return false;
            var player= _playerRepository.GetPlayerByUsername(username);
            if(player== null) { return false; }
            if(newpass!=confirmpass) { return false; }
            player.Password= confirmpass;
            _playerRepository.UpdatePlayer(player);
            return true;
        }

        public Player getPlayerByUsername(string username)
        {
            return _playerRepository.GetPlayerByUsername(username);
        }
    }
}
