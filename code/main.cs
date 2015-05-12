using System;
using System.Reflection;
using System.Linq;

class Main_
{
    static void Main() {
        Console.WriteLine("\nC# Tests:");
        typeof(Tests)
            .GetMethods()
            .OrderBy(m=>m.Name)
            .Where(m=>m.Name.EndsWith("Test"))
            .Select(m=>{
                Test(m);
                return 0;
            })
            .ToArray();
        Console.WriteLine("Done!");
    }
    
    static void Test(MethodInfo m) {
        try {
            m.Invoke(null, null);
            Console.WriteLine("PASS:" + m.Name);
        } catch (Exception ex) {
            Console.WriteLine("FAIL:" + m.Name + ": " + ex.InnerException.Message);
        }
    }
}
