module Main
open System.Reflection

let test (m : MethodInfo) = 
    try
        m.Invoke(null, null) |> ignore
        printfn "PASS:%s" m.Name
    with
        | ex -> printfn "FAIL:%s: %s" m.Name ex.InnerException.Message
        

[<EntryPoint>]
let main argv =
    printfn "\nF# Tests:"
    let testsType = System.Reflection.Assembly.GetCallingAssembly().GetType("Tests")
    let methods = 
        testsType.GetMethods()
        |> Array.sortBy(fun m -> m.Name)
        |> Array.filter(fun m -> m.Name.EndsWith("Test"))
        |> Array.iter(fun m -> 
            test m
        )
    printfn "Done!"
    0
