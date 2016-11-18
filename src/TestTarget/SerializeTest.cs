using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestInterfaces;

namespace TestTarget
{
    public class SerializeTest : AbstractTestClass
    {
        public class Person
        {
            public static Person Instance { get { return new Person { Age = 18, Name = "Carson" }; } }
            public int Age { get; set; }
            public string Name { get; set; }
        }
        public override string Test()
        {
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xs = new XmlSerializer(typeof(Person));
                xs.Serialize(sw, Person.Instance);
                return sw.ToString();
            }
        }
    }
}
