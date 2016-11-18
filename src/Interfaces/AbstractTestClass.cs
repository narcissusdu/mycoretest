using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestInterfaces
{
    public abstract class AbstractTestClass : ITestable
    {
        public virtual string GetName()
        {
            return this.GetType().Name;
        }

        public abstract string Test();

    }
}
