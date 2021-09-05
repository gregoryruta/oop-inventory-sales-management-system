using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CustomProgram
{
    public class InventoryItem
    {
        private string _category;
        private string _sku;
        private float _costPrice;

        public InventoryItem(string sku, string category, float costPrice)
        {
            _sku = sku;
            _category = category;
            _costPrice = costPrice;
        }

        //need this constructor to load from file
        public InventoryItem()
        {

        }

        public void Save(StreamWriter writer)
        {
            writer.WriteLine(_sku);
            writer.WriteLine(_category);
            writer.WriteLine(_costPrice);
        }

        public void Load(StreamReader reader)
        {
            _sku = reader.ReadLine();
            _category = reader.ReadLine();
            _costPrice = reader.ReadSingle();
        }

        public string Sku
        {
            get
            {
                return _sku;
            }
        }

        public string Category
        {
            get
            {
                return _category;
            }
        }

        public float CostPrice
        {
            get
            {
                return _costPrice;
            }
        }
    }
}
