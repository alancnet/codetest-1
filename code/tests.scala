import java.util.Arrays

object Tests {
    def helloWorldTest() {
        Assert.areEqual("Hello World!", Code.helloWorld());
    }
    def capitalizeEveryNthWordTest() {
        def sentence = "Lorem ipsum dolor sit amet";
        Assert.areEqual("Lorem ipsum Dolor sit Amet", Code.capitalizeEveryNthWord(sentence, 0, 2));
        Assert.areEqual("Lorem ipsum Dolor Sit Amet", Code.capitalizeEveryNthWord(sentence, 2, 1));
    }
    def isPrimeTest() {
        Assert.isFalse(Code.isPrime(-1), "IsPrime(-1) should be false.");
        Assert.isFalse(Code.isPrime(0), "IsPrime(0) should be false.");

        val primesTo1000 = List(
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47,
            53, 59, 61, 67, 71, 73, 79, 83, 89, 97,
            101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199,
            211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293,
            307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397,
            401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499,
            503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599,
            601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691,
            701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797,
            809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887,
            907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997);

        // creates a 3-tuple as follows: (integer, whether it's prime, what the user's isPrime() method returns)
        val oneTo1000 = 1.to(1000).map(n => (n, primesTo1000.contains(n), Code.isPrime(n)))

        // handle any failures - we only need to deal with the first failure
        val firstFailure = oneTo1000.find(x => x._2 != x._3)
        if (firstFailure.isDefined) {
            Assert.isTrue(false, "IsPrime(" + firstFailure.get._1 + ") should be " + firstFailure.get._2)
        }
    }
    def goldenRatioTest() {
        Assert.isInRange(1.61800, 1.61806, Code.goldenRatio(1.0, 1.0));
        Assert.isInRange(1.61800, 1.61806, Code.goldenRatio(100, 6));
    }
    def fibonacciTest() {
        Assert.areEqual(0, Code.fibonacci(0));
        Assert.areEqual(1, Code.fibonacci(1));
        Assert.areEqual(1, Code.fibonacci(2));
        Assert.areEqual(2, Code.fibonacci(3));
        Assert.areEqual(6765, Code.fibonacci(20));
    }
    def squareRootTest() {
        Assert.areEqual(5.0, Code.squareRoot(25.0));
        Assert.isInRange(1.414, 1.4144, Code.squareRoot(2.0));
    }

}