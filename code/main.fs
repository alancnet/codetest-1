open TestModule

module Assert =
    let areEqual<'T> expected actual = 
        if not (expected = null && actual = null) 
           && not (expected = actual) 
           && not (expected <> null && expected.Equals(actual))
           && not (actual <> null && actual.Equals(expected)) then
            failwith (sprintf "Expected '%O' but got '%O'" expected actual)
    let isTrue condition = 
        if not condition then
            failwith "Assert failed"


let helloWorldTest() = 
    Assert.areEqual (HelloWorld()) "Hello World!"

let test t name = 
    try
        t()
        printfn "PASS:%s" name
    with
        | ex -> printfn "FAIL:%s: %s" name ex.Message
        

[<EntryPoint>]
let main argv =
    printfn "\nF# Tests:"
    test helloWorldTest "HelloWorld()"
    printfn "Done!"
    0
