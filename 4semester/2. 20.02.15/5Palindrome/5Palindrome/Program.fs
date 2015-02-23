/// Return true - if list is palindrome.
let isPalindrome str =
    let rec convertList list result = 
        match list with
        | head::tail -> convertList tail (head::result)
        | [] -> result

    let list = List.ofArray ((string str).ToCharArray())
    let convert = convertList list []
    convert = list
    
printfn "Put string:"
let str = System.Console.ReadLine()
printfn "This string is palindrome - %b" (isPalindrome str)