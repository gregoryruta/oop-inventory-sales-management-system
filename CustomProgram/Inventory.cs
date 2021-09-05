using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class Inventory
    {
        private List<InventoryItem> _items;

        public Inventory()
        {
            _items = new List<InventoryItem>();
        }

        public void Put(InventoryItem inventoryItem)
        {
            _items.Add(inventoryItem);
        }

        public void Remove(InventoryItem inventoryItem)
        {
            _items.Remove(inventoryItem);
        }

        public List<InventoryItem> Items
        {
            get
            {
                return _items;
            }
        }
    }
}
