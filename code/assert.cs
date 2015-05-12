using System;
static class Assert {
	public static void AreEqual(object expected, object actual) {
		if (expected == null && actual == null) return;
		if (expected == actual) return;
		if (expected != null && expected.Equals(actual)) return;
		if (actual != null && actual.Equals(expected)) return;
		throw new Exception(String.Format("Expected '{0}', got '{1}'.", expected, actual));
	}
	public static void IsTrue(bool condition) {
		AreEqual(true, condition);
	}
}
