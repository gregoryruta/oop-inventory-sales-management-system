using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class ProductListView : IView
    {
        private ProductList _productList;
        private Inventory _inventory;

        public ProductListView(ProductList productList, Inventory inventory)
        {
            _productList = productList;
            _inventory = inventory;
        }
        public List<string> Execute()
        {
            List<string> output = new List<string>();
            output.Add("All registered products");

            //group IProducts by category
            IEnumerable<IGrouping<string, IProduct>> categoryGroups = _productList.Products.GroupBy(product => product.Category);

            //foreach group of IProducts with the same category...
            foreach (IGrouping<string, IProduct> group in categoryGroups)
            {
                output.Add(null);
                output.Add(group.Key.ToUpper());

                //foreach IProduct in the group...
                foreach (IProduct product in group)
                {
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