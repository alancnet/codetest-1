using System;

static class Tests {
	public static Action[] GetTests() {
		return new Action[] {
			HelloWorldTest
		};
	}
	public static void HelloWorldTest() {
		Assert.AreEqual("Hello World!", Code.HelloWorld());
	}
}