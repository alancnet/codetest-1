object Main {    
    def test(t: () => Unit, name:String) {
      try {
        t();
        println("PASS:" + name)
      } catch {
        case e: Exception => 
          println("FAIL:" + name + ": " + e.getMessage)
      }
    }
    
    def main(args: Array[String]) {
      println("\nScala Tests:");
      test(Tests.helloWorldTest, "helloWorld()");
      println("Done!");
    }
  }


