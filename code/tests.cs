using System;
using System.Collections.Generic;

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

        HashSet<int> primesTo1000 = new HashSet<int> {
            2, 3, 5, 7, 11, 13, 17, 19, 23,
            29, 31, 37, 41, 43, 47, 53, 59, 61, 67,
            71, 73, 79, 83, 89, 97, 101, 103, 107, 109,
            113, 127, 131, 137, 139, 149, 151, 157, 163, 167,
            173, 179, 181, 191, 193, 197, 199, 211, 223, 227,
            229, 233, 239, 241, 251, 257, 263, 269, 271, 277,
            281, 283, 293, 307, 311, 313, 317, 331, 337, 347,
            349, 353, 359, 367, 373, 379, 383, 389, 397, 401,
            409, 419, 421, 431, 433, 439, 443, 449, 457, 461,
            463, 467, 479, 487, 491, 499, 503, 509, 521, 523,
            541, 547, 557, 563, 569, 571, 577, 587, 593, 599,
            601, 607, 613, 617, 619, 631, 641, 643, 647, 653,
            659, 661, 673, 677, 683, 691, 701, 709, 719, 727,
            733, 739, 743, 751, 757, 761, 769, 773, 787, 797,
            809, 811, 821, 823, 827, 829, 839, 853, 857, 859,
            863, 877, 881, 883, 887, 907, 911, 919, 929, 937,
            941, 947, 953, 967, 971, 977, 983, 991, 997};

        for (int i=1; i<1000; i++) {
            if (primesTo1000.Contains(i)) {
                Assert.IsTrue(Code.IsPrime(i), "IsPrime(" + i + ") should be true.");
            }
            else {
                Assert.IsFalse(Code.IsPrime(i), "IsPrime(" + i + ") should be false.");
            }
        }
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