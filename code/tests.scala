object Tests {
    def helloWorldTest() {
        Assert.areEqual("Hello World!", TestModule.helloWorld());
    }
    def capitalizeEveryNthWordTest() {
        def sentence = "Lorem ipsum dolor sit amet";
        Assert.areEqual("Lorem ipsum dolor Sit amet", TestModule.capitalizeEveryNthWord(sentence, 0, 2));
        Assert.areEqual("Lorem ipsum Dolor Sit Amet", TestModule.capitalizeEveryNthWord(sentence, 2, 1));
    }
}