using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            StaticMethods.RegisterProduct("Bicycle", typeof(Bicycle));
            StaticMethods.RegisterProduct("Part", typeof(Part));
            StaticMethods.RegisterProduct("Accessory", typeof(Accessory));

            ProductList productList = new ProductList();
            Inventory inventory = new Inventory();
            Ledger ledger = new Ledger();
     
            new Loader(productList, inventory, ledger); //load files

            Console.WriteLine("Bicycle Shop Inventory Manager");
            new MainMenu(productList, inventory, ledger).Show(); //jump into main menu

            new Saver(productList, inventory, ledger); //save files
        }
    }
}
