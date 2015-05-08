object Program {
    def helloWorldTest() {
      Assert.areEqual("Hello World!", TestModule.helloWorld());
    }
    
    def capitalizeEveryNthWordTest() {
      def sentence = "Lorem ipsum dolor sit amet";
      Assert.areEqual("Lorem Ipsum dolor Sit amet", TestModule.capitalizeEveryNthWord(sentence, 0, 2));
      Assert.areEqual("Lorem ipsum Dolor Sit Amet", TestModule.capitalizeEveryNthWord(sentence, 2, 1));
      Assert.areEqual("Lorem ipsum Dolor sit Amet", TestModule.capitalizeEveryNthWord(sentence, 0, 2));
    }

    def test(t: () => Unit, name:String) {
      try {
        t();
        println(s"PASS:$name")
      } catch {
        case e: Exception => 
          println(s"FAIL:$name: ${e.getMessage}")
      }
    }
    
    def main(args: Array[String]) {
      println("\nScala Tests:");
      test(helloWorldTest, "helloWorld()");
      test(capitalizeEveryNthWordTest, "capitalizeEveryNthWord(...)");
      println("Done!");
    }
  }

object Assert {
  def areEqual[T](expected:T, actual:T) {
    if (expected != actual) {
      throw new Exception(s"Expected '$expected' but got '$actual'.");
    }
  }
}

