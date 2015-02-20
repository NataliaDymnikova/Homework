// Fibbonacci numbers.
[<EntryPoint>]
let main argv = 
    System.Console.WriteLine("Put number:")
    let number = int (System.Console.ReadLine())

    let rec Fibbonacci num =
        if num <= 1
        then 1
        else Fibbonacci (num - 2) + Fibbonacci (num - 1)

    System.Console.WriteLine("Fibbonacci: {0}", Fibbonacci number)
    0