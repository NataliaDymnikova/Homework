/// Return true - if list is palindrome. Make first = [].
let rec isPalindrome list first = 
    if List.length list = 0
        then true
    elif List.length list = 1 && List.length first = 1 
        then first.Head = list.Head
    elif list.Length = 1
        then (first.Head = list.Head) && (isPalindrome first.Tail.Tail [first.Tail.Head])
    else
        isPalindrome list.Tail (List.append first [list.Head])

printfn "Put string:"
let list = List.ofArray (System.Console.ReadLine().ToCharArray())
printfn "This string is palindrome - %b" (isPalindrome list [])