using Koi_Game_Reposities.Entities;
using Koi_Game_Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Interfaces
{
    public interface IPlayerService
    {
        Task<List<Player>> GetAllPlayers();
        Task<Player> GetPlayer(int id);
        void AddPlayer (PlayerDTO playerDTO);
        void UpdatePlayer (PlayerDTO playerDTO);
        void DeletePlayer (PlayerDTO playerDTO); 
    }
}
