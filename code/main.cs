using System;

class Program
{
	static void HelloWorldTest() {
		Assert.AreEqual("Hello World!", TestClass.HelloWorld());
	}
	static void CapitalizeEveryNthWordTest() {
		var sentence = "Lorem ipsum dolor sit amet";
		Assert.AreEqual("Lorem Ipsum dolor Sit amet", TestClass.CapitalizeEveryNthWord(sentence, 0, 2));
		Assert.AreEqual("Lorem ipsum Dolor Sit Amet", TestClass.CapitalizeEveryNthWord(sentence, 2, 1));
		Assert.AreEqual("Lorem ipsum Dolor sit Amet", TestClass.CapitalizeEveryNthWord(sentence, 0, 2));
	}
		
	static void Main() {
		Console.WriteLine("\nC# Tests:");
		Test(HelloWorldTest, "HelloWorld()");
		Test(CapitalizeEveryNthWordTest, "CapitalizeEveryNthWord(...)");
		Console.WriteLine("Done!");
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
