using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.DTO;
using Koi_Game_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString(); // Chuỗi băm dài 64 ký tự
            }
        }
        // chuc nang dang nhap
        public Player Login(string username, string password)
        {
            var player = _playerRepository.GetPlayerByUsername(username);
            if (player != null)
            {
                string hashedPassword = HashPassword(password.Trim());
                // password = password.Trim();
                if (string.Equals(player.Password.Trim(), hashedPassword, StringComparison.Ordinal))
                {
                    return player; // Đăng nhập thành công
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
            string hashedPassword = HashPassword(password);


            // add player
            var player = new Player
            {
                UserName = username,
                Password = hashedPassword,
                Name = name,
                Coin = 0
            };
            _playerRepository.AddPlayer(player);
            return true;

        }
        public bool QuenMatKhau(string username, string otp, string newpass, string confirmpass)
        {
            // Kiểm tra OTP
            if (otp != "12345678") return false;

            // Lấy thông tin người dùng
            var player = _playerRepository.GetPlayerByUsername(username);
            if (player == null) return false;

            // Kiểm tra xác nhận mật khẩu
            if (newpass != confirmpass) return false;

           
            string hashedPassword = HashPassword(confirmpass);

            // Cập nhật mật khẩu
            player.Password = hashedPassword;
            _playerRepository.UpdatePlayer(player);
            return true;
        }

        public Player getPlayerByUsername(string username)
        {
            return _playerRepository.GetPlayerByUsername(username);
        }
    }
}
