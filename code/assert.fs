module Assert
let (|?) lhs rhs = (if lhs = null then rhs else lhs)
let areEqual<'T> expected actual (failText : string) = 
    if not (expected = null && actual = null) 
       && not (expected = actual) 
       && not (expected <> null && expected.Equals(actual))
       && not (actual <> null && actual.Equals(expected)) then
        failwith (failText |? "Findme")
               
let isTrue condition (failText : string) = 
    if not condition then
        failwith (failText |? "Expected true.")
        
let isFalse condition (failText : string) =
    if condition then
        failwith (failText |? "Expected false.")