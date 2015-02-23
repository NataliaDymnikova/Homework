/// Return multiplication of digits in number.
let rec multiplication number = 
    if number > 9
        then (number % 10) * (multiplication (number / 10))
    else
        number

printfn "Put big number:"
let number = int <| System.Console.ReadLine()
multiplication number |> printfn "Multiplication of digits %d"