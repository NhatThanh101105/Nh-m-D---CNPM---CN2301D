using Koi_Game_Reposities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Reposities.Interfaces
{
   public interface IInventoryRepository
    {
     
        void addNewItems(int idplayer, int itemId, string name, int quantity);
        void removeItems(int idplayer, int itemId, string name, int quantity);
        List<Inventory> getItemByTypeName(int idplayer,string typeName);
    }
}
