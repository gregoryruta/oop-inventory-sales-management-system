using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace CustomProgram
{
    public class Bicycle : IProduct
    {
        private string _sku;
        private string _category;
        private string _brand;
        private string _name;
        private string _type;
        private string _rider;
        private string _size;
        private string _colour;

        public Bicycle(string brand, string name, string type, string rider, string size, string colour)
        {
            _category = "Bicycles";
            _brand = brand;
            _name = name;
            _type = type;
            _rider = rider;
            _size = size;
            _colour = colour;
        }

        //need this constructor to load from file
        public Bicycle()
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
            writer.WriteLine(_rider);
            writer.WriteLine(_size);
            writer.WriteLine(_colour);
        }

        public void Load(StreamReader reader)
        {
            _sku = reader.ReadLine();
            _category = reader.ReadLine();
            _brand = reader.ReadLine();
            _name = reader.ReadLine();
            _type = reader.ReadLine();
            _rider = reader.ReadLine();
            _size = reader.ReadLine();
            _colour = reader.ReadLine();
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

        public string Rider
        {
            get
            {
                return _rider;
            }
        }

        public string Size
        {
            get
            {
                return _size;
            }
        }

        public string Colour
        {
            get
            {
                return _colour;
            }
        }
    }
}
