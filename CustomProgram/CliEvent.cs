using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class CliEvent
    {
        public string Prompt(string prompt)
        {
            Console.Write($"\n{prompt}\n-> ");
            return Console.ReadLine();
        }

        public void PrintLine(string line)
        {
            Console.WriteLine($"\n{line}");
        }

        public void PrintList(List<string> list)
        {
            Console.WriteLine();
            foreach (string line in list)
                Console.WriteLine(line);
        }
    }
}
