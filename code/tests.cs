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
}