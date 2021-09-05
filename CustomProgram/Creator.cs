using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public abstract class Creator
    {
        protected abstract IProduct CreateProduct();

        public IProduct GetProduct()
        {
            return this.CreateProduct();
        }
    }
}
