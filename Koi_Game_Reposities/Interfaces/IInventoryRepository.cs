using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Reposities.Interfaces
{
   public interface IInventoryRepository
    {
        List<KeyValuePair<int?, string?>> getAllItems(int idplayer);
        List<int?> getSl(int idplayer);
        void addNewItems(int idplayer, int itemId, string name, int quantity);
        void removeItems(int idplayer, int itemId, string name, int quantity);
    }
}
