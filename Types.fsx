open System

// Option is a discriminated union that returns either the data, or none
let firstOdd = List.tryPick (fun x -> if x % 2 = 1 then Some x else None)
firstOdd[1;2;3]

// Option.bind takes a function and an option, add returns the resulting option
// useful for chaining checks
let toNumAndSquare o =
    Option.bind (fun s ->
        let (success, value) = Double.TryParse(s)
        if success then Some value else None) o
    |> Option.bind (fun n -> n * n |> Some)
Some "5" |> toNumAndSquare

// choice - represents multiple mutually exclusive values (i.e. on eor the other)
let safeDiv num den =
    if den = 0. then
        Choice1Of2 "can't divide by zero"
    else
        Choice2Of2 (num / den )
safeDiv 1. 0.

// sequences are lazily evaluated ordered collections
// good for creating large collections as only stores as are being created
seq {0L..System.Int64.MaxValue}