/// Return position of nimber in list.
let rec positionOfNumber list number amount = 
    if List.length list = 0
        then -1
    elif List.head list = number
        then amount
    else
        positionOfNumber (List.tail list) number (amount + 1)

printfn "Put list:"
let list = List.map (fun x -> int <| x) (List.ofArray (System.Console.ReadLine().Split(' ')))
printfn "Put number:"
let number = int <| System.Console.ReadLine()

printfn "Amount of %d: %d" number (positionOfNumber list number 0)