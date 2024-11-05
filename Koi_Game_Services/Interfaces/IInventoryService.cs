using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Interfaces
{
    public interface IInventoryService
    {
        List<KeyValuePair<int?,string?>> getAllItems(int idplayer);// lay taat item cua nguoi choiw
        List<int?> getSl(int idplayer);// lay ra sl item cua nguoi choi
        void addItem(int idplayer, int itemId, string name, int quantity);// luu item cua nguoiw choiw vao inventory

        void removeItem(int idplayer, int itemId, string name, int quantity);// xoa item cua nguowi choiw 
    }
}
