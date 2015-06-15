using System;

static class Tests {
    public static void HelloWorldTest() {
        Assert.AreEqual("Hello World!", Code.HelloWorld());
    }
    public static void CapitalizeEveryNthWordTest() {
        var sentence = "Lorem ipsum dolor sit amet";
        Assert.AreEqual("Lorem ipsum Dolor sit Amet", Code.CapitalizeEveryNthWord(sentence, 0, 2));
        Assert.AreEqual("Lorem ipsum Dolor Sit Amet", Code.CapitalizeEveryNthWord(sentence, 2, 1));
    }
    public static void IsPrimeTest() {
        Assert.IsFalse(Code.IsPrime(-1), "IsPrime(-1) should be false.");
        Assert.IsFalse(Code.IsPrime(0), "IsPrime(0) should be false.");
        Assert.IsFalse(Code.IsPrime(1), "IsPrime(1) should be false.");
        Assert.IsTrue(Code.IsPrime(2), "IsPrime(2) should be true.");
        Assert.IsTrue(Code.IsPrime(5), "IsPrime(5) should be true.");
        Assert.IsFalse(Code.IsPrime(87), "IsPrime(87) should be false.");
        Assert.IsTrue(Code.IsPrime(97), "IsPrime(97) should be true.");
    }
    public static void GoldenRatioTest() {
        Assert.IsInRange(1.61800, 1.61806, Code.GoldenRatio(1.0, 1.0));
        Assert.IsInRange(1.61800, 1.61806, Code.GoldenRatio(100, 6));
    }
    public static void FibonacciTest() {
        Assert.AreEqual(0, Code.Fibonacci(0));
        Assert.AreEqual(1, Code.Fibonacci(1));
        Assert.AreEqual(1, Code.Fibonacci(2));
        Assert.AreEqual(2, Code.Fibonacci(3));
        Assert.AreEqual(6765, Code.Fibonacci(20));
    }
    public static void SquareRootTest() {
        Assert.AreEqual(5.0, Code.SquareRoot(25.0));
        Assert.IsInRange(1.414, 1.4144, Code.SquareRoot(2.0));
    }
}