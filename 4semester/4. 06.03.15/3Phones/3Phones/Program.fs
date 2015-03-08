type Number = int
type Name = string
type Phones = 
    | Contact of Name * Number
    | Contactes of Name * Number * Phones
    | Empty

/// Add new contact to phones.
let add name number phones = 
    Contactes(name, number, phones)

/// Search by name.
let rec searchByName (phones: Phones) name = 
    match phones with
    | Contact (cName, cNumber) -> 
        if name = cName then
            cNumber
        else
            -1
    | Contactes(cName, cNumber, cPhones) -> 
        if name = cName then
            cNumber
        else
            searchByName cPhones name
    | Empty -> -1

/// Search by number.
let rec searchByNumber (phones: Phones) number = 
    match phones with
    | Contact (cName, cNumber) -> 
        if number = cNumber then
            cName
        else
            "Not Found"
    | Contactes(cName, cNumber, cPhones) -> 
        if number = cNumber then
            cName
        else
            searchByNumber cPhones number
    | Empty -> "Empty"

/// Convert phones to string.
let phonesToString phones = 
    let rec recPhonesToString phones (str: List<string>) = 
        match phones with
        | Contact (name, number) -> ((string <| name) + " " + number.ToString())::str
        | Contactes (name, number, cPhones) -> 
            recPhonesToString cPhones (((string <| name) + " " + number.ToString())::str)
        | Empty -> str

    recPhonesToString phones List<string>.Empty

/// Convert string to phones.
let stringsToPhones (contactes: List<string>) = 
    let rec recStringToPhones (contactes: List<string>) phones = 
        match contactes with
        | head::tail -> 
            let str = List.ofArray (head.Split(' '))
            recStringToPhones tail (Contactes(str.Head, (int <| str.Tail.Head), phones))
        | [] -> phones
    recStringToPhones contactes Phones.Empty

/// Write phones to file.
let writeToFile fileName (phones: Phones) = 
    System.IO.File.WriteAllLines(fileName, phonesToString phones)

/// Read phones from file.
let readFromFile fileName = 
    let contactes : List<string> = List.ofArray (System.IO.File.ReadAllLines(fileName))
    stringsToPhones contactes

/// Add, search and other in console.
let rec workWithUser phones=
    printfn "%A" (phonesToString phones)
    printfn "0 - exit"
    printfn "1 - add contact"
    printfn "2 - search by name"
    printfn "3 - search by number"
    printfn "4 - write to file"
    printfn "5 - read from file"
    let pressed = int <| System.Console.ReadLine()

    match pressed with
    | 0 -> phones
    | 1 -> 
        printfn "Put new name:"
        let name = System.Console.ReadLine() 
        printfn "Put new number:"
        let number = int <| System.Console.ReadLine()
        workWithUser (add name number phones)
    | 2 -> 
        printfn "Put name: "
        (searchByName phones (System.Console.ReadLine())) |> printfn "Number: %d"
        workWithUser phones
    | 3 ->
        printfn "Put number:"
        (searchByNumber phones (int <| (System.Console.ReadLine()))) |> printfn "Number: %s"
        workWithUser phones
    | 4 ->
        writeToFile "phones.txt" phones
        printfn "Was written to phones.txt"
        workWithUser phones
    | 5 -> 
        printfn "Was read from phones.txt"
        workWithUser (readFromFile "phones.txt")
    | _ -> workWithUser phones

let phones = Contactes("aaa", 111, Contactes("bbb", 222, Contact("ccc", 333)))
let telephones = workWithUser phones

