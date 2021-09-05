using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class AccessoryCreator : Creator
    {
        private string _brand;
        private string _name;
        private string _type;
        private string _variant;

        public AccessoryCreator(string brand, string name, string type, string variant)
        {
            _brand = brand;
            _name = name;
            _type = type;
            _variant = variant;
        }

        protected override IProduct CreateProduct()
        {
            return new Accessory(_brand, _name, _type, _variant);
        }
    }
}
