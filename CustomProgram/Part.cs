using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CustomProgram
{
    public class Part : IProduct
    {
        private string _sku;
        private string _category;
        private string _brand;
        private string _name;
        private string _type;
        private string _variant;

        public Part(string brand, string name, string type, string variant)
        {
            _category = "Parts";
            _brand = brand;
            _name = name;
            _type = type;
            _variant = variant;
        }

        //need this constructor to load from file
        public Part()
        {

        }

        public void Save(StreamWriter writer)
        {
            writer.WriteLine(this.GetType().Name);
            writer.WriteLine(_sku);
            writer.WriteLine(_category);
            writer.WriteLine(_brand);
            writer.WriteLine(_name);
            writer.WriteLine(_type);
            writer.WriteLine(_variant);
        }

        public void Load(StreamReader reader)
        {
            _sku = reader.ReadLine();
            _category = reader.ReadLine();
            _brand = reader.ReadLine();
            _name = reader.ReadLine();
            _type = reader.ReadLine();
            _variant = reader.ReadLine();
        }

        public string Sku
        {
            get
            {
                return _sku;
            }
            set
            {
                _sku = value;
            }
        }

        public string Category
        {
            get
            {
                return _category;
            }
        }

        public string Brand
        {
            get
            {
                return _brand;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }
        }

        public string Variant
        {
            get
            {
                return _variant;
            }
        }
    }
}
