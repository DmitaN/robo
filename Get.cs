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
        public void GetMethods(string path) {

            string[] dllFiles = Directory.GetFiles(path, "*.dll");
            foreach (var dllFile in dllFiles)
            {
                var asm = Assembly.LoadFrom(dllFile);
                Type[] types = asm.GetTypes();
                foreach (var item in types)
                {
                    Type myType = asm.GetType(item.ToString());
                    Console.WriteLine(item.ToString());
                    foreach (MemberInfo mi in myType.GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                    {
                        Console.WriteLine($"- {mi.Name}");
                    }
                    foreach (MemberInfo mi in myType.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                    {
                        Console.WriteLine($"- {mi.Name}");
                    }
                }
            }
        }
    }
}
