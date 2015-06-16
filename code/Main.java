import java.lang.reflect.Method;

public class Main {

    private static void test(Method t) {
        try {
            t.invoke(null);
            System.out.println("PASS:" + t.getName());
        }
        catch (Exception e) {
            System.out.println("FAIL:" + t.getName() + ": " + (e.getCause().getMessage() != null ? e.getCause().getMessage() : e.getCause()));
        }
    }
    
    public static void main(String[] args) {
        System.out.println("\nJava Tests:");

        for (Method m : (new Tests()).getClass().getMethods()) {
            if (m.getName().endsWith("Test")) {
                test(m);
            }
        }
        System.out.println("Done!");
    }
}


