// Exceptions
try
    failwith "My Error"
with
    | Failure msg -> printfn "Failed with %s" msg

// with finally
try
    try
        failwith "My Error"
    with
        | Failure msg -> printfn "Failed with %s" msg
finally
    printfn "Always executes"

// Custom exceptions
exception MyException of string * int

try
    raise (MyException ("My number is:", 53))
with
    | MyException (msg, num) -> printfn "%s %d" msg num


// catching .NET exceptions (:? = type test operator)
try
    1 / 0
with
    | :? System.DivideByZeroException as ex -> 
        printfn "%s" ex.Message
        0

// pattern matching
// destructuring assignment
let (a, b) = (1, 2)
a

// as function arguments
let addPair (a, b) = // pattern match the tuple
    a + b

// match statement
let addPair2 p =
    match p with
    | (a, 0) -> a
    | (0, b) -> b
    | (a, b) -> a + b

// when statement
let fizzbuzzer i = 
    match i with
        | _ when i % 3 = 0 && i % 5 = 0 -> "fizzbuzz"
        | _ when i % 3 = 0 -> "fizz"
        | _ when i % 5 = 0 -> "buzz"
        | _ -> string i
[1..100] |> List.map fizzbuzzer