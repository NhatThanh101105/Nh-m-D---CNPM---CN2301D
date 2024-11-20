using Koi_Game_Reposities.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Reposities.Interfaces
{
    public interface IPlayerRepository
    {
       // Task<List<Player>> GetAllPlayer();
        Task<Player> GetPlayer(int id);
        void AddPlayer (Player player);
        void UpdatePlayer (Player player);
        // void DelPlayer (Player player);

        List<Player> GetAllPlayer(int idplayer);

        bool DelPlayer(int idplayer);


        // get nguoi choi theo ten dang nhap de su dung chuc nang dang nhap 
        Player GetPlayerByUsername (string username);
        

    }
    
}
