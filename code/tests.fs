module Tests
open Code;
let helloWorldTest() = 
    Assert.areEqual "Hello World!" (Code.helloWorld())
let capitalizeEveryNthWordTest() =
    let sentence = "Lorem ipsum dolor sit amet";
    Assert.areEqual "Lorem ipsum dolor Sit amet" (capitalizeEveryNthWord sentence 0 2)
    Assert.areEqual "Lorem ipsum Dolor Sit Amet" (capitalizeEveryNthWord sentence 2 1)
