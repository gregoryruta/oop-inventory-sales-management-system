using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class BicycleCreator : Creator
    {
        private string _brand;
        private string _name;
        private string _type;
        private string _rider;
        private string _size;
        private string _colour;

        public BicycleCreator(string brand, string name, string type, string rider, string size, string colour)
        {
            _brand = brand;
            _name = name;
            _type = type;
            _rider = rider;
            _size = size;
            _colour = colour;
        }

        protected override IProduct CreateProduct()
        {
            return new Bicycle(_brand, _name, _type, _rider, _size, _colour);
        }
    }
}
