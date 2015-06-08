public class Assert {
//    public static <T> void areEqual(T expected, T actual) {
//        areEqual(expected, actual, null);
//    }
//
//    public static <T> void areEqual(T expected, T actual, String failText) {
//        if (expected.equals(actual)) {
//            throw new RuntimeException(failText != null ? failText : "Expected '" + expected.toString() + "' but got '" + actual + "'.");
//        }
//    }

    public static void areEqual(Object expected, Object actual) {
        areEqual(expected, actual, null);
    }

    public static void areEqual(Object expected, Object actual, String failText) {
        if (!expected.equals(actual)) {
            throw new RuntimeException(failText != null ? failText : "Expected '" + expected + "' but got '" + actual + "'.");
        }
    }

    public static void isFalse(Boolean condition) {
        isFalse(condition, null);
    }

    public static void isFalse(Boolean condition, String failText) {
        if (condition) {
            fail(failText);
        }
    }

    public static void isTrue(Boolean condition) {
        isFalse(condition, null);
    }

    public static void isTrue(Boolean condition, String failText) {
        if (!condition) {
            fail(failText);
        }
    }

    public static void isInRange(Double least, Double most, Double actual) {
        isInRange(least, most, actual, null);
    }

    public static void isInRange(Double least, Double most, Double actual, String failText) {
        if (actual < least || actual > most) {
            fail(failText);
        }
    }

    private static void fail(String failText) {
        if (failText == null || failText.isEmpty()) {
            throw new RuntimeException();
        }
        else {
            throw new RuntimeException(failText);
        }

    }

}
