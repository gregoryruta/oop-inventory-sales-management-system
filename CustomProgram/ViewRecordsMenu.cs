using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class ViewRecordsMenu : Menu
    {
        private ProductList _productList;
        private Inventory _inventory;
        private Ledger _ledger;

        public ViewRecordsMenu(ProductList productList, Inventory inventory, Ledger ledger)
        {
            _productList = productList;
            _inventory = inventory;
            _ledger = ledger;
        }

        public override void Show()
        {
            bool validated = true;
            while (true)
            {
                string prompt = validated ? "View records menu\n1. View products\n2. View inventory\n3. View ledger\n4. Back" : "Invalid Input! Enter a number between 1 and 4.";
                string response = GetInput(prompt);
                switch (response)
                {
                    case "1":
                        validated = true;
                        OutputList(new ProductListView(_productList, _inventory).Execute());
                        break;
                    case "2":
                        validated = true;
                        OutputList(new InventoryView(_productList, _inventory).Execute());
                        break;
                    case "3":
                        validated = true;
                        OutputList(new LedgerView(_ledger).Execute());
                        break;
                    case "4":
                        return;
                    default:
                        validated = false;
                        break;
                }
            }
        }
    }
}
