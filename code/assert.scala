object Assert {
  def areEqual[T](expected:T, actual:T) {
    if (expected != actual) {
      throw new Exception("Expected '" + expected + "' but got '" + actual + ".");
    }
  }
}
