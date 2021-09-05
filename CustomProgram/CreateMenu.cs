using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class CreateMenu : Menu
    {
        private ProductList _productList;

        public CreateMenu(ProductList productList)
        {
            _productList = productList;
        }

        public override void Show()
        {
            bool validated = true;
            while (true)
            {
                string prompt = validated ? "Add product:\n1. Bicycle\n2. Part\n3. Accessory\n4. Back" : "Invalid Input! Enter a number between 1 and 4.";
                string response = GetInput(prompt);
                switch (response)
                {
                    case "1":
                        validated = true;
                        CreateBicycleSequence();
                        break;
                    case "2":
                        validated = true;
                        CreatePartSequence();
                        break;
                    case "3":
                        CreateAccessorySequence();
                        validated = true;
                        break;
                    case "4":
                        return;
                    default:
                        validated = false;
                        break;
                }
            }
        }

        private void CreateBicycleSequence()
        {
            OutputLine("CREATE BICYCLE");
            string brand = GetGeneric("brand");
            string name = GetGeneric("name");
            string type = GetGeneric("type");
            string rider = GetRider();
            string size = GetSize();
            string colour = GetGeneric("colour");
            Creator creator = new BicycleCreator(brand, name, type, rider, size, colour);
            IProduct iProduct = creator.GetProduct();
            _productList.Put(iProduct);
        }

        private void CreatePartSequence()
        {
            OutputLine("CREATE PART");
            string brand = GetGeneric("brand");
            string name = GetGeneric("name");
            string type = GetGeneric("type");
            string variant = GetGeneric("variant");
            Creator creator = new PartCreator(brand, name, type, variant);
            IProduct iProduct = creator.GetProduct();
            _productList.Put(iProduct);
        }

        private void CreateAccessorySequence()
        {
            OutputLine("CREATE ACCESSORY");
            string brand = GetGeneric("brand");
            string name = GetGeneric("name");
            string type = GetGeneric("type");
            string variant = GetGeneric("variant");
            Creator creator = new AccessoryCreator(brand, name, type, variant);
            IProduct iProduct = creator.GetProduct();
            _productList.Put(iProduct);
        }

        private string GetGeneric(string thing)
        {
            bool validated = true;
            while (true)
            {
                string prompt = validated ? $"Enter {thing}:" : $"Invalid Input! Enter a {thing}.";
                string response = GetInput(prompt);
                if (!string.IsNullOrWhiteSpace(response))
                    return response;
                validated = false;
            }
        }

        private string GetRider()
        {
            bool validated = true;
            while (true)
            {
                string prompt = validated ? "Enter rider - (M)ale, (F)emale, (U)nisex, (C)hild:" : "Invalid Input! Enter a valid rider: M, F, U or C.";
                string response = GetInput(prompt);
                if (new string[] { "M", "F", "U", "C" }.Contains(response.ToUpper()))
                    return response;
                validated = false;
            }
        }

        private string GetSize()
        {
            bool validated = true;
            while (true)
            {
                string prompt = validated ? "Enter size - XS, S, M, L, XL:" : "Invalid Input! Enter a valid size: XS, S, M, L, XL.";
                string response = GetInput(prompt);
                if (new string[] { "XS", "S", "M", "L", "XL" }.Contains(response.ToUpper()))
                    return response;
                validated = false;
            }
        }
    }
}
