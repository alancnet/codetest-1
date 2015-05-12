module Assert
let areEqual<'T> expected actual = 
    if not (expected = null && actual = null) 
       && not (expected = actual) 
       && not (expected <> null && expected.Equals(actual))
       && not (actual <> null && actual.Equals(expected)) then
        failwith (sprintf "Expected '%O' but got '%O'" expected actual)
let isTrue condition = 
    if not condition then
        failwith "Assert failed"
