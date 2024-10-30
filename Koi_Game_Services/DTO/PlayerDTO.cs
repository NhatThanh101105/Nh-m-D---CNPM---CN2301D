using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.DTO
{
    public class PlayerDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? UserName {  get; set; }
        public string? Password { get; set; }
        public int Coin { get; set; }

    }
}
