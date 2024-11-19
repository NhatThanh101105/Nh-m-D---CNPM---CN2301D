using Koi_Game_Reposities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Interfaces
{
    public interface IInventoryService
    {
    
        void addItem(int idplayer, int itemId, string name, int quantity);// luu item cua nguoiw choiw vao inventory

        void removeItem(int idplayer, int itemId, string name, int quantity);// xoa item cua nguowi choiw 

        List<Inventory> getItemByNameType(int idplayer, string nameType);
    }
}
