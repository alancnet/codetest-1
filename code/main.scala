object Program {
    def helloWorldTest() {
      Assert.areEqual("Hello World!", TestModule.helloWorld());
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

