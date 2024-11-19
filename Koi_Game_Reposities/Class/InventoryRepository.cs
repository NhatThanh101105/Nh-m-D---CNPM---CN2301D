using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Reposities.Class
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly KoiGameDatabaseContext _dbcontext;
        public InventoryRepository(KoiGameDatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void addNewItems(int idplayer, int itemId, string name, int quantity)
        {

            var newItem = _dbcontext.Inventories
                .FirstOrDefault(i => i.PlayerId == idplayer && i.ItemId == itemId && i.ItemType == name);

            if (newItem == null)
            {
                newItem = new Inventory
                {
                    PlayerId = idplayer,
                    ItemId = itemId,
                    ItemType = name,
                    Quantity = quantity
                };
                _dbcontext.Inventories.Add(newItem);
            }
            else 
            {
                newItem.Quantity += quantity;
                _dbcontext.Inventories.Update(newItem);
            }
            _dbcontext.SaveChanges();

        }



        public void removeItems(int idplayer, int itemId, string name, int quantity)
        {
            var item = _dbcontext.Inventories
                .FirstOrDefault(i => i.PlayerId == idplayer && i.ItemId == itemId && i.ItemType == name);
            if(item != null)
            {
                if(item.Quantity == quantity)
                {
                    _dbcontext.Inventories .Remove(item);
                }
                else
                {
                    item.Quantity -= quantity;
                    _dbcontext.Inventories.Update(item);
                }
                _dbcontext.SaveChanges() ;
            }
        }
      

        public List<Inventory> getItemByTypeName(int idplayer, string typeName) 
        {
                return _dbcontext.Inventories
                .Where(i=>i.PlayerId==idplayer&& i.ItemType == typeName)// lay ra cac do dung dựa tren id, ten nametype
                .ToList();
        }
    }
}
