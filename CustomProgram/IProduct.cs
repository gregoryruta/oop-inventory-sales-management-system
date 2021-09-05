using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CustomProgram
{
    public interface IProduct
    {
        string Sku { get; set; }

        string Category { get; }

        string Brand { get; }

        string Name { get; }

        void Save(StreamWriter writer);

        void Load(StreamReader reader);
    }
}
