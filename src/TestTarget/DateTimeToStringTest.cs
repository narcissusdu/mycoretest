using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestInterfaces;

namespace TestTarget
{
    public class DateTimeToStringTest : AbstractTestClass
    {
        public override string Test()
        {
	    return DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss");
	}
    }
}
