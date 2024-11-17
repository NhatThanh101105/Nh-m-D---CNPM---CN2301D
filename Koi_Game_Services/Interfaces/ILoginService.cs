using Koi_Game_Reposities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Interfaces
{
    public interface ILoginService
    {
        Player Login(string username, string password);
        bool Register(string username, string password,string name, string correctPassword);
        bool QuenMatKhau(string username, string otp, string newpass, string confirmpass);

        Player getPlayerByUsername(string username);

    }
}
