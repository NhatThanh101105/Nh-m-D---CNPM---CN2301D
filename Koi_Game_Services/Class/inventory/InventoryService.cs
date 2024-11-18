using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Class.inventory
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public void addItem(int idplayer, int itemId, string name, int quantity)
        {
            _inventoryRepository.addNewItems(idplayer, itemId, name, quantity);
        }

        public List<KeyValuePair<int?,string?>> getAllItems(int idplayer)
        {
            return _inventoryRepository.getAllItems(idplayer);
        }
        public List<int?> getSl(int idplayer)
        {
            return _inventoryRepository.getSl(idplayer);
        }

        public void removeItem(int idplayer, int itemId, string name, int quantity)
        {
            _inventoryRepository.removeItems(idplayer, itemId, name, quantity);
        }

        public List<Inventory> getItemByNameType(int idplayer,string nameType)
        {
            return _inventoryRepository.getItemByTypeName(idplayer, nameType);
        }
    }
}
