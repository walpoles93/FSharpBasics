// Function Definition
let add x y = 
    x + y

// Function application
add 3 4

// Function application is left-associative
add 3 4 + 5
// is equivalent to 
(add 3 4) + 5

// Functions can be partially applied
let add1 = add 1
add1 5

// Normal functions prefix the arguments
// Infix functions (or operators) go between arguments
5 + 6 // + is an infix function

// infix functions can be applied prefix if include in parens
(+) 5 6

// infix operators can be defined, but must only use symbols in name
let (<^>) x y = x + y
1 <^> 2
(<^>) 1 2

// lambda functions
(fun x y -> x + y) 5 6

// recursive functions require the rec keyword
// NOTE no input parameters need be specified when using pattern matching
let rec fib = function
| 0 -> 0
| 1 -> 1
| x -> fib (x - 1) + fib (x - 2)

fib 6

// forward piping allows the input argument to prefix the function
// this is useful for chaining function calls
// NOTE: only one argument can be used
7.
    |> sin
    |> (*) 2.

// The backward pipe operator evaluates the RHS first before passing to function
// Useful for removing parens
sin <| 2. + 1.
sin (2. + 1.)

// can use in conjuction to simulate infix operator
5 |> add <| 6

// there also exist double and triple pipe operators, which allow multiple arguments to be passed

(5, 6) ||> add

// the composition operator allows functions to be composed in the direction of the chevrons
let minus1 x = x - 1
let times2 = (*) 2

let composed = minus1 >> times2
composed 5

let backComposed = times2 << minus1
backComposed 5

// the backwards composition operator also supports piping
times2 << minus1 <| 5