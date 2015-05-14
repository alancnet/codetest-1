using System;
static class Assert {
    public static void AreEqual(object expected, object actual, string failText = null) {
        if (expected == null && actual == null) return;
        if (expected == actual) return;
        if (expected != null && expected.Equals(actual)) return;
        if (actual != null && actual.Equals(expected)) return;
        throw new Exception(String.Format(failText ?? "Expected '{0}', got '{1}'.", expected, actual));
    }
    public static void IsTrue(bool condition, string failText = null) {
        if (!condition)
            throw new Exception(failText ?? "Expected true.");
    }
    public static void IsFalse(bool condition, string failText = null) {
        if (condition)
            throw new Exception(failText ?? "Expected false.");
    }
    public static void IsInRange(double least, double most, double actual, string failText = null) {
        if (actual < least || actual > most) {
            throw new Exception(String.Format(failText ?? "Expected {0} to {1}, got {2}.", least, most, actual));
        }
    }
}
