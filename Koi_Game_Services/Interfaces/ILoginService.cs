using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Interfaces
{
    public interface ILoginService
    {
        bool Login(string username, string password);
        bool Register(string username, string password,string name, string correctPassword);
        bool ValidateUser(string username, string password);

    }
}
