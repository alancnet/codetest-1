using System;

class Program
{
	static void HelloWorldTest() {
		Assert.AreEqual(TestClass.HelloWorld(), "Hello World!");
	}
		
	static void Main() {
		Console.WriteLine("\nC# Tests:");
		Test(HelloWorldTest, "HelloWorld()");
	}
	
	static void Test(Action tester, string name) {
		try {
			tester();
			Pass(name);
		} catch (Exception ex) {
			Fail("{0}: {1}", name, ex.Message);
		}
	}
	static void Pass(string text, params object[] args) {
		Console.WriteLine("PASS:" + text, args);
	}
	static void Fail(string text, params object[] args) {
		Console.WriteLine("FAIL:" + text, args);
	}
	
	static class Assert {
		public static void AreEqual(object expected, object actual) {
			if (expected == null && actual == null) return;
			if (expected == actual) return;
			if (expected != null && expected.Equals(actual)) return;
			if (actual != null && actual.Equals(expected)) return;
			throw new Exception(String.Format("Expected '{0}', got '{1}'.", expected, actual));
		}
		public static void IsTrue(bool condition) {
			AreEqual(true, condition);
		}
	}
}
