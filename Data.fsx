// f# requires that types be explicitly converted
// numeric data types have conversion functions
float 3 // converts the integer 3 to the float 3.
float "3" // converts the string "3" to the float 3

// boolean operators
true && false
true || false
not true

// equality operator
5 = 4

// inequality operator
5 <> 4

// indexing requires a . before square brackers
"My string".[1]

// range are defined with ..
"My string".[1..4]
"My string".[1..] // goes to end of string
"My string".[..4] // starts at beginning until index 4

// string functions
// forall - take predicate and evaluates if all chars evaluate to true
String.forall System.Char.IsDigit "01234"

// init - creates a new string by applying a function to each index of given length
String.init 5 (fun i -> i |> string)

// all expressions must return a value. If a value isn't needed, return Unit ()
let returnUnit = ()
returnUnit

// lists
[1;2;3] // create a list with the elements 1,2,3
1::[2;3] // create a list with the element 2,3, then create a new list by appending 1 to the starts

// lists can easily be created using ranges
[0..5] // creates the list with elements 0,1,2,3,4,5
[0..2..5] // creates the list with elements 0,2,4 (start from 0, add two each time, while less than 5)

// lists are concatenated using the @ operator
[0;1]@[2;3]

// list comprehensions are used to create more complex lists
[for x in 1..10 do yield x * 2] // apply x * 2 to the elements 1-10
[for x in 1..10 -> x * 2] // do yield can be replaced by -> in simple examples
// more complex example - print all coordinates of 2D grid except diagonal
[
    for x in 1..8 do
    for y in 1..8 do
        if x <> y then
            yield (x, y)
]

// arrays have similar abilities to lists, except elements can be directly accessed, and there is no :: operator
[|0..5|].[2]

//tuples can contain multiple different data types
(1, "hi", 6.)

// pairs (tuples with only 2 elements) have functions to extract the first or second element
let tuple = (1, "hi")
fst tuple
snd tuple

// tuples can also be destructured
let (one, hi) = (1, "hi")
one
hi

// records allows properties to be defined, as well as members
type Person = {
    name: string;
    age: int;
} with member this.canDrive = this.age > 17

let person = { name = "Sam"; age = 27 }
person.age

person.canDrive

// to clone a record
{person with age = 28}

// discriminated unions are sum type that allow the type to store one of a list of predefined cases
// these can be used similarly to enums
type Status = | Draft | Published
Draft

// or to hold different types of data depending on the case
type Result = | Error | Data of int * string // either error or tuple (int, string)
Error
Data (5, "hello")

// can also provide names
type Result2 = | Error | Data of num: int * str: string
Data (num = 5, str = "Hello")

// also useful for pattern matching
let data = Data (5, "hello")
match data with
    | Data(i, s) -> "This is data"
    | Error -> "This is Error"


// generic types allow any type for a value to be used
type MyGeneric<'a> = {
    data: 'a
}
{ data = 5 }
{ data = 5. }