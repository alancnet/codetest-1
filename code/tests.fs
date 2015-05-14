module Tests
open Code;
let helloWorldTest() = 
    Assert.areEqual "Hello World!" (Code.helloWorld()) null
let capitalizeEveryNthWordTest() =
    let sentence = "Lorem ipsum dolor sit amet";
    Assert.areEqual "Lorem ipsum Dolor sit Amet" (capitalizeEveryNthWord sentence 0 2) null
    Assert.areEqual "Lorem ipsum Dolor Sit Amet" (capitalizeEveryNthWord sentence 2 1) null
let isPrimeTest() =
    Assert.isFalse (isPrime -1) "IsPrime(-1) should be false."
    Assert.isFalse (isPrime 0) "IsPrime(0) should be false."
    Assert.isFalse (isPrime 1) "IsPrime(1) should be false."
    Assert.isTrue (isPrime 2) "IsPrime(2) should be true."
    Assert.isTrue (isPrime 5) "IsPrime(5) should be true."
    Assert.isFalse (isPrime 87) "IsPrime(87) should be false."
    Assert.isTrue (isPrime 97) "IsPrime(97) should be true."
let goldenRatioTest() =
    Assert.isInRange 1.61800 1.61806 (goldenRatio 1.0 1.0) null
    Assert.isInRange 1.61800 1.61806 (goldenRatio 100.0 6.0) null
let fibionacciTest() =
    Assert.areEqual 0 (fibionacci 0) null
    Assert.areEqual 1 (fibionacci 1) null
    Assert.areEqual 1 (fibionacci 2) null
    Assert.areEqual 2 (fibionacci 3) null
    Assert.areEqual 6765 (fibionacci 20) null
let squareRootTest() =
    Assert.areEqual 5.0 (Code.squareRoot 25.0) null
    Assert.isInRange 1.414 1.4144 (Code.squareRoot 2.0) null
