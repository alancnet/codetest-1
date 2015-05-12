object Main {    
    def test(t: java.lang.reflect.Method) {
        try {
            t.invoke(Tests);
            println("PASS:" + t.getName)
        } catch {
            case e: Exception => 
                println("FAIL:" + t.getName + ": " + e.getCause.getMessage)
        }
    }
    
    def main(args: Array[String]) {
        println("\nScala Tests:");
        Tests
            .getClass
            .getMethods
            .sortWith(_.getName < _.getName)
            .filter(m=>m.getName.endsWith("Test"))
            .map(m=>{
                test(m);
                0
            });
        println("Done!");
    }
}


