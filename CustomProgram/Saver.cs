using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CustomProgram
{
    public class Saver
    {

        public Saver(ProductList productList, Inventory inventory, Ledger ledger)
        {
            SaveProducts(productList);
            SaveInventoryItems(inventory);
            SaveTransactions(ledger);
        }

        private void SaveProducts(ProductList productList)
        {
            StreamWriter writer;
            writer = new StreamWriter("./products.txt");
            writer.WriteLine(productList.Products.Count());
            foreach (IProduct product in productList.Products)
                product.Save(writer);
            writer.Close();
        }

        private void SaveInventoryItems(Inventory inventory)
        {
            StreamWriter writer;
            writer = new StreamWriter("./inventory_items.txt");
            writer.WriteLine(inventory.Items.Count());
            foreach (InventoryItem inventoryItem in inventory.Items)
                inventoryItem.Save(writer);
            writer.Close();
        }

        private void SaveTransactions(Ledger ledger)
        {
            StreamWriter writer;
            writer = new StreamWriter("./transactions.txt");
            writer.WriteLine(ledger.Transactions.Count);
            foreach (Transaction transaction in ledger.Transactions)
                transaction.Save(writer);
            writer.Close();
        }
    }
}
