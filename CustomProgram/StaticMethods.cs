using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CustomProgram
{
    public static class StaticMethods
    {

        private static Dictionary<string, Type> _productClassRegistry = new Dictionary<string, Type>();

        public static void RegisterProduct(string className, Type classType)
        {
            _productClassRegistry.Add(className, classType);
        }

        public static IProduct CreateProduct(string className)
        {
            return (IProduct)Activator.CreateInstance(_productClassRegistry[className]);
        }

        public static int ReadInt(this StreamReader reader)
        {
            return Convert.ToInt32(reader.ReadLine());
        }

        public static float ReadSingle(this StreamReader reader)
        {
            return Convert.ToSingle(reader.ReadLine());
        }

        public static int GetInventoryItemCount(string sku, Inventory inventory)
        {
            int count = 0;
            foreach (InventoryItem item in inventory.Items)
                if (sku == item.Sku)
                    count++;
            return count;
        }

        public static IProduct GetProductFromSku(string sku, ProductList productList)
        {
            foreach (IProduct product in productList.Products)
                if (sku == product.Sku)
                    return product;
            return null;
        }

        public static string CurrentDateTime()
        {
            return DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }
    }
}
