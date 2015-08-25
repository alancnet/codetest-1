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

    let primesTo1000 = [2; 3; 5; 7; 11; 13; 17; 19; 23; 29; 31; 37; 41; 43; 47;
        53; 59; 61; 67; 71; 73; 79; 83; 89; 97;
        101; 103; 107; 109; 113; 127; 131; 137; 139; 149; 151; 157; 163; 167; 173; 179; 181; 191; 193; 197; 199;
        211; 223; 227; 229; 233; 239; 241; 251; 257; 263; 269; 271; 277; 281; 283; 293;
        307; 311; 313; 317; 331; 337; 347; 349; 353; 359; 367; 373; 379; 383; 389; 397;
        401; 409; 419; 421; 431; 433; 439; 443; 449; 457; 461; 463; 467; 479; 487; 491; 499;
        503; 509; 521; 523; 541; 547; 557; 563; 569; 571; 577; 587; 593; 599;
        601; 607; 613; 617; 619; 631; 641; 643; 647; 653; 659; 661; 673; 677; 683; 691;
        701; 709; 719; 727; 733; 739; 743; 751; 757; 761; 769; 773; 787; 797;
        809; 811; 821; 823; 827; 829; 839; 853; 857; 859; 863; 877; 881; 883; 887;
        907; 911; 919; 929; 937; 941; 947; 953; 967; 971; 977; 983; 991; 997]


    // 3-tuple extraction
    let first (a, _, _) = a
    let second (_, b, _) = b
    let third (_, _, c) = c

    // filtering functions
    let isInPrimeList numToTest = primesTo1000 |> List.exists (fun elem -> elem=numToTest)
    let notPrimeTest (_, b, c) = b <> c

    let oneTo1000 = [1 .. 1000] |> List.map (fun elem -> (elem, isInPrimeList elem, Code.isPrime_TrevorAckerman elem))

    let errors = oneTo1000
                |> List.map (fun (a, b, c) -> (a, b, b <> c))
                |> Seq.filter(fun (x, y, z) -> z)

    if Seq.length errors = 0 then
        0 |> ignore
    else
        let foundItem = errors |> Seq.take 1
        let output = sprintf "IsPrime(%A) should be %A." (errors |> Seq.head |> first) (errors |> Seq.head |> second)
        Assert.isFalse true output


let goldenRatioTest() =
    Assert.isInRange 1.61800 1.61806 (goldenRatio 1.0 1.0) null
    Assert.isInRange 1.61800 1.61806 (goldenRatio 100.0 6.0) null
let fibonacciTest() =
    Assert.areEqual 0 (fibonacci 0) null
    Assert.areEqual 1 (fibonacci 1) null
    Assert.areEqual 1 (fibonacci 2) null
    Assert.areEqual 2 (fibonacci 3) null
    Assert.areEqual 6765 (fibonacci 20) null
let squareRootTest() =
    Assert.areEqual 5.0 (Code.squareRoot 25.0) null
    Assert.isInRange 1.414 1.4144 (Code.squareRoot 2.0) null
