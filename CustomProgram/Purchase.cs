using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class Purchase
    {
        public void Execute(IProduct product, int quantity, float unitCost, Inventory inventory, Ledger ledger)
        {
            //for the purchase quantity, create inventory items and put in inventory
            for (int i = 0; i < quantity; i++)
                inventory.Put(new InventoryItem(product.Sku, product.Category, unitCost));
            
            //create transacton and put in ledger
            string txDetails = $"BUY {product.Sku} x {quantity} @ {unitCost.ToString("c2")} / unit";
            Transaction transaction = new Transaction(StaticMethods.CurrentDateTime(), txDetails);
            ledger.Put(transaction);
        }
    }
}
