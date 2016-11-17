using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestInterfaces
{
    public abstract class AbstractTestClass : ITestable
    {
        public abstract string GetName();

        public abstract string Test();

    }
}
