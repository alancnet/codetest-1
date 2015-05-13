object Assert {
    class NullCoalesce[A <: AnyRef](a: A) { def ??(b: A) = if (a==null) b else a }
    implicit def coalesce_anything[A <: AnyRef](a: A) = new NullCoalesce(a)

    def areEqual[T](expected:T, actual:T, failText:String = null) {
        if (expected != actual) {
            throw new Exception(failText ?? "Expected '" + expected + "' but got '" + actual + "'.");
        }
    }
    def isTrue(condition:Boolean, failText:String = null) {
        if (!condition) {
            throw new Exception(failText ?? "Expected true.");
        }
    }
    def isFalse(condition:Boolean, failText:String = null) {
        if (condition) {
            throw new Exception(failText ?? "Expected false.");
        }
    }
    def isInRange(least:Double, most:Double, actual:Double, failText:String = null) {
        if (actual < least || actual > most) {
            throw new Exception(failText ?? "Expected " + least + " to " + most + ", but got " + actual + ".");
        }
    }
}
