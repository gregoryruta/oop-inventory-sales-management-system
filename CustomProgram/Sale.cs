using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class Sale
    {
        public void Execute(InventoryItem saleItem, int quantity, float unitPrice, Inventory inventory, Ledger ledger)
        {
            //generate list of InventoryItems with the saleItem sku
            List<InventoryItem> SaleItemSkuList = new List<InventoryItem>();
            foreach (InventoryItem item in inventory.Items)
                if (saleItem.Sku == item.Sku)
                   SaleItemSkuList.Add(item);

            //for the sale quantity, remove the items in the SaleItemSkuList from the inventory.
            //starting from SaleItemSkuList[0] and incrementing ensures FIFO stock control.
            for (int i = 0; i < quantity; i++)
                inventory.Remove(SaleItemSkuList[i]);

            //create transaction and put in ledger
            string txDetails = $"SELL {saleItem.Sku} x {quantity} @ {unitPrice.ToString("c2")} / unit";
            Transaction transaction = new Transaction(StaticMethods.CurrentDateTime(), txDetails);
            ledger.Put(transaction);
        }
    }
}
