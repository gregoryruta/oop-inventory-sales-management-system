using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CustomProgram
{
    public class Loader
    {

        public Loader(ProductList productList, Inventory inventory, Ledger ledger)
        {
            LoadProducts(productList);
            LoadInventoryItems(inventory);
            LoadTransactions(ledger);
        }

        private void LoadProducts(ProductList productList)
        {
            StreamReader reader;
            reader = new StreamReader("./products.txt");
            int count = reader.ReadInt();
            for (int i = 0; i < count; i++)
            {
                string className = reader.ReadLine();
                IProduct product = StaticMethods.CreateProduct(className);
                product.Load(reader);
                productList.Put(product);
            }
            reader.Close();
        }

        private void LoadInventoryItems(Inventory inventory)
        {
            StreamReader reader;
            reader = new StreamReader("./inventory_items.txt");
            int count = reader.ReadInt();
            for (int i = 0; i < count; i++)
            {
                InventoryItem inventoryItem = new InventoryItem();
                inventoryItem.Load(reader);
                inventory.Put(inventoryItem);
            }
            reader.Close();
        }

        private void LoadTransactions(Ledger ledger)
        {
            StreamReader reader;
            reader = new StreamReader("./transactions.txt");
            int count = reader.ReadInt();
            for (int i = 0; i < count; i++)
            {
                Transaction transaction = new Transaction();
                transaction.Load(reader);
                ledger.Put(transaction);
            }
            reader.Close();
        }
    }
}
