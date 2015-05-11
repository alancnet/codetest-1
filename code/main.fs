module Main
let test t name = 
    try
        t()
        printfn "PASS:%s" name
    with
        | ex -> printfn "FAIL:%s: %s" name ex.Message
        

[<EntryPoint>]
let main argv =
    printfn "\nF# Tests:"
    test Tests.helloWorldTest "helloWorld()"
    printfn "Done!"
    0
