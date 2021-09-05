using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public abstract class Menu
    {
        public abstract void Show();

        protected string GetInput(string prompt)
        {
            return new CliEvent().Prompt(prompt);
        }

        protected void OutputLine(string line)
        {
            new CliEvent().PrintLine(line);
        }

        protected void OutputList(List<string> list)
        {
            new CliEvent().PrintList(list);
        }
    }
}
