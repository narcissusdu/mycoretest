using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TestInterfaces;
using TestTarget;

namespace ConsoleEntrance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Test Entrance:");
            string cmd = string.Empty;
            int testNo = 0;
            List<AbstractTestClass> testList = null;
            while (!string.Equals(cmd, "exit"))
            {
                testList = GetTestList().ToList();
                DisplayTestList(testList);
                cmd = Console.ReadLine();
                if (int.TryParse(cmd, out testNo) && testNo > 0 && testList != null && testNo <= testList.Count)
                {
                    DoTest(testList, testNo);
                }
            }

        }

        private static void DoTest(List<AbstractTestClass> testList, int testNo)
        {
            Console.WriteLine(string.Format("==========Test #{0}# starts==========", testList[testNo - 1].GetName()));
            Console.WriteLine(testList[testNo - 1].Test());
            Console.WriteLine(string.Format("========== Test #{0}# ends ==========", testList[testNo - 1].GetName()));
        }

        private static IEnumerable<AbstractTestClass> GetTestList()
        {
            Assembly asm = Assembly.Load(new AssemblyName("TestTarget"));
            foreach (TypeInfo t in asm.DefinedTypes)
            {
                if (t.IsSubclassOf(typeof(AbstractTestClass)))
                {
                    yield return (AbstractTestClass)asm.CreateInstance(t.FullName);
                }
            }
        }

        private static void DisplayTestList(List<AbstractTestClass> testList)
        {
            if (testList == null || testList.Count == 0)
            {
                Console.WriteLine("No test was found, press enter to search again.");
            }
            else
            {
                Console.WriteLine("No.\tTestName");
                for (int index = 0; index < testList.Count; index++)
                {
                    Console.WriteLine(string.Format("{0}\t{1}", index + 1, testList[index].GetName()));
                }
                Console.WriteLine("Enter the number to start the test.");
            }
        }

    }
}
