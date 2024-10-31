using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.DTO;
using Koi_Game_Services.Interfaces;

namespace Koi_Game_Services.Class
{
    public class LoginService : ILoginService
    {
        private readonly IPlayerRepository _playerRepository;

        public LoginService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        // Chức năng đăng nhập
        public bool Login(string username, string password)
        {
            var player = _playerRepository.GetPlayerByUsername(username);
            if (player != null)
            {
                password = password.Trim();
                if (string.Equals(player.Password.Trim(), password, StringComparison.Ordinal))
                {
                    return true;
                }
            }
            return false;
        }

        // Chức năng đăng ký
        public bool Register(string username, string password, string name, string correctPassword)
        {
            // Kiểm tra xem có trùng tên đăng nhập không
            if (_playerRepository.GetPlayerByUsername(username) != null)
            {
                return false;
            }

            // Kiểm tra xem mật khẩu lần hai có giống mật khẩu lần một không
            if (password != correctPassword)
            {
                return false;
            }

            // Thêm player
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

        // Chức năng xác thực người dùng
//        public bool ValidateUser(string username, string password)
  //      {
    //        return Login(username, password); // Sử dụng phương thức Login
      //  }
    }
}
