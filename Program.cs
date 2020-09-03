using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;

namespace robo_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var get = new Get();
            get.GetMethods(@"C:\Users\Admin\source\repos\robo_test\bin\Debug\dll\");

            Console.ReadKey();
        }
    }
}
