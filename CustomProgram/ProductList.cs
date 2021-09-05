using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class ProductList
    {
        private List<IProduct> _products;

        public ProductList()
        {
            _products = new List<IProduct>();
        }

        public void Put(IProduct product)
        {
            _products.Add(product);

            //only create sku if its not loaded from file
            if (product.Sku == null)
                product.Sku = SkuCreator(product.Brand);
        }

        private string SkuCreator(string brand)
        {
            string letters = brand.Substring(0, 1).ToUpper();
            string numbers = _products.Count.ToString("D6");
            return letters + numbers;
        }

        public List<IProduct> Products
        {
            get
            {
                return _products;
            }
        }
    }
}
