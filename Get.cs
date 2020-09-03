using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace robo_test
{
    public class Get
    {
        public void GetMethods(string path)
        {
            string[] dllFiles = Directory.GetFiles(path, "*.dll");
            foreach (var dllFile in dllFiles)
            {
                var asm = Assembly.LoadFrom(dllFile);
                Type[] types = asm.GetTypes();
                foreach (var item in types)
                {
                    Type myType = asm.GetType(item.ToString());
                    Console.WriteLine(item.ToString());
                    foreach (MethodInfo mi in myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.NonPublic))
                    {
                        if (mi.IsFamily || mi.IsPublic)
                            Console.WriteLine($"- {mi.Name}");
                    }
                }
            }
        }
    }
}
