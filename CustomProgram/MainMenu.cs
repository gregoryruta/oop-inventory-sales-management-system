using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class MainMenu : Menu
    {
        private ProductList _productList;
        private Inventory _inventory;
        private Ledger _ledger;

        public MainMenu(ProductList productList, Inventory inventory, Ledger ledger)
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
                string prompt = validated ? "Main menu\n1. Create product\n2. Purchase\n3. Sell\n4. View records\n5. Quit" : "Invalid Input! Enter a number between 1 and 5";
                string response = GetInput(prompt);
                switch (response)
                {
                    case "1":
                        validated = true;
                        new CreateMenu(_productList).Show();
                        break;
                    case "2":
                        validated = true;
                        PurchaseSequence();
                        break;
                    case "3":
                        validated = true;
                        SaleSequence();
                        break;
                    case "4":
                        validated = true;
                        new ViewRecordsMenu(_productList, _inventory, _ledger).Show();
                        break;
                    case "5":
                        return;
                    default:
                        validated = false;
                        break;
                }
            }
        }

        private void PurchaseSequence()
        {
            OutputLine("PURCHASE");
            OutputList(new ProductListView(_productList, _inventory).Execute());
            IProduct product = GetProductFromUserSku();
            int stockCount = StaticMethods.GetInventoryItemCount(product.Sku, _inventory);
            string lastPurchasePrice = GetLastPurchasePrice(product.Sku);
            OutputLine($"Stock count: {stockCount}\nLast purchase price: {lastPurchasePrice}");
            int quantity = GetQuantity(null);
            float unitCost = GetPrice();
            new Purchase().Execute(product, quantity, unitCost, _inventory, _ledger);
            OutputLine("Successful purchase. Inventory & ledger updated.");
        }

        private void SaleSequence()
        {
            OutputLine("SALE");
            OutputList(new InventoryView(_productList, _inventory).Execute());
            InventoryItem inventoryItem = GetInventoryItemFromUserSku();
            int stockCount = StaticMethods.GetInventoryItemCount(inventoryItem.Sku, _inventory);
            string lastPurchasePrice = GetLastPurchasePrice(inventoryItem.Sku);
            OutputLine($"Stock count: {stockCount}\nLast purchase price: {lastPurchasePrice}");
            int quantity = GetQuantity(stockCount);
            float unitCost = GetPrice();
            new Sale().Execute(inventoryItem, quantity, unitCost, _inventory, _ledger);
            OutputLine("Successful sale. Inventory & ledger updated.");
        }

        private IProduct GetProductFromUserSku()
        {
            bool validated = true;
            while (true)
            {
                string prompt = validated ? "Enter SKU:" : "SKU not found in product list. Try again.";
                string response = GetInput(prompt);
                IProduct product = StaticMethods.GetProductFromSku(response.ToUpper(), _productList);
                if (product is IProduct)
                    return product;
                validated = false; //product is null
            }
        }

        private InventoryItem GetInventoryItemFromUserSku()
        {
            bool validated = true;
            while (true)
            {
                string prompt = validated ? "Enter SKU:" : "SKU not found in inventory. Try again.";
                string response = GetInput(prompt);
                foreach (InventoryItem inventoryItem in _inventory.Items)
                    if (response.ToUpper() == inventoryItem.Sku)
                        return inventoryItem;
                validated = false;
            }
        }

        private string GetLastPurchasePrice(string sku)
        {
            int inventoryCount = _inventory.Items.Count() - 1;
            for (int i = inventoryCount; i >= 0; i--)
                if (sku == _inventory.Items[i].Sku)
                    return _inventory.Items[i].CostPrice.ToString("c2");
            return "Never purchased";
        }

        private int GetQuantity(int? maxQuantity)
        {
            bool validated = true;
            while (true)
            {
                string errMsg = maxQuantity.HasValue ? "Invalid Input! Enter a positive number no greater than the stock count." : "Invalid Input! Enter a positive number.";
                string prompt = validated ? "Enter Quantity:" : errMsg;
                string response = GetInput(prompt);
                if (int.TryParse(response, out int quantity) && quantity >= 1)
                    //if there is no max qty OR if there is and requested qty is less than the max qty
                    if (!maxQuantity.HasValue || (maxQuantity.HasValue && quantity <= maxQuantity))
                        return quantity;
                validated = false;
            }
        }

        private float GetPrice()
        {
            bool validated = true;
            while (true)
            {
                string prompt = validated ? "Enter unit price:" : "Invalid Input! Enter a price.";
                string response = GetInput(prompt);
                if (float.TryParse(response, out float price))
                    return price;
                validated = false;
            }
        }
    }
}
