object Tests {
    def helloWorldTest() {
        Assert.areEqual("Hello World!", TestModule.helloWorld());
    }
    def capitalizeEveryNthWordTest() {
        def sentence = "Lorem ipsum dolor sit amet";
        Assert.areEqual("Lorem ipsum Dolor sit Amet", TestModule.capitalizeEveryNthWord(sentence, 0, 2));
        Assert.areEqual("Lorem ipsum Dolor Sit Amet", TestModule.capitalizeEveryNthWord(sentence, 2, 1));
    }
    def isPrimeTest() {
        Assert.isFalse(TestModule.isPrime(-1), "IsPrime(-1) should be false.");
        Assert.isFalse(TestModule.isPrime(0), "IsPrime(0) should be false.");
        Assert.isFalse(TestModule.isPrime(1), "IsPrime(1) should be false.");
        Assert.isTrue(TestModule.isPrime(2), "IsPrime(2) should be true.");
        Assert.isTrue(TestModule.isPrime(5), "IsPrime(5) should be true.");
        Assert.isFalse(TestModule.isPrime(87), "IsPrime(87) should be false.");
        Assert.isTrue(TestModule.isPrime(97), "IsPrime(97) should be true.");
    }
}