using System;

class Main_
{
	static void Main() {
		Console.WriteLine("\nC# Tests:");
		Test(Tests.HelloWorldTest, "HelloWorld()");
		Console.WriteLine("Done!");
	}
	
	static void Test(Action tester, string name) {
		try {
			tester();
			Console.WriteLine("PASS:" + name);
		} catch (Exception ex) {
			Console.WriteLine("FAIL:" + name + ": " + ex.Message);
		}
	}
}
