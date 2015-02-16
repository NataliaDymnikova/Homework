// Дополнительные сведения о F# см. на http://fsharp.net
// Дополнительную справку см. в проекте "Учебник по F#".

[<EntryPoint>]
let main argv = 
    System.Console.WriteLine("Put a number:")
    let string = System.Console.ReadLine()
    let number : int = int string

    let rec factorial n =
        if n = 1 
        then 1 
        else n * factorial (n - 1) 
    System.Console.WriteLine("Factorial: {0}", factorial number)
    0 // возвращение целочисленного кода выхода
