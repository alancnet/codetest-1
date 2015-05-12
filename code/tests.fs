module Tests
let helloWorldTest() = 
    Assert.areEqual "Hello World!" (Code.helloWorld())
