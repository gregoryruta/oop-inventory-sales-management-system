using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class InventoryView : IView
    {
        private ProductList _productList;
        private Inventory _inventory;

        public InventoryView(ProductList productList, Inventory inventory)
        {
            _productList = productList;
            _inventory = inventory;
        }

        public List<string> Execute()
        {
            List<string> output = new List<string>();
            output.Add("All inventory items");

            //group InventoryItems by category
            IEnumerable<IGrouping<string, InventoryItem>> categoryGroups = _inventory.Items.GroupBy(item => item.Category);

            //foreach group of InventoryItems with the same category...
            foreach (IGrouping<string, InventoryItem> categoryGroup in categoryGroups)
            {
                output.Add(null);
                output.Add(categoryGroup.Key.ToUpper());

                //group InventoryItems by SKU
                IEnumerable<IGrouping<string, InventoryItem>> SkuGroups = categoryGroup.GroupBy(item => item.Sku);

                //foreach group of InventoryItems with identical SKUs...
                foreach (IGrouping<string, InventoryItem> SkuGroup in SkuGroups)
                {
                    //get the IProduct from the first item in the group
                    //since they are the same SKU, they are the same IProduct
                    IProduct product = StaticMethods.GetProductFromSku(SkuGroup.First().Sku, _productList);

                    //get its properties...
                    string line = null;
                    foreach (PropertyInfo property in product.GetType().GetProperties())
                    {
                        if (property.Name == "Sku")
                            line += $"{property.GetValue(product)} | ";
                        else if (property.Name != "Category")
                            line += $"{property.Name.ToUpper()}: {property.GetValue(product)} | ";
                    }
                    //get stock count
                    line += $"STOCK COUNT: {StaticMethods.GetInventoryItemCount(product.Sku, _inventory)}";
                    output.Add(line);
                }
            }
            return output;
        }
    }
}
