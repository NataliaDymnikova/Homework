/// Return true - if brackets (), {}, [] in correct order.
let brackets (string: List<char>) =
    let isHeadisChar (ch: char) (list: List<char>) = 
        match list with
        | head::tail -> 
            if head = ch then true
            else false
        | [] -> false

    let rec recBrackets (string: List<char>) (bracket: List<char>) = 
        match string with
        | head::tail when head = '(' || head = '[' || head = '{' -> recBrackets tail (head::bracket)
        | head::tail -> 
            if head = ')' then
                if (isHeadisChar '(' bracket) then recBrackets tail bracket.Tail
                else false
            elif head = ']' then
                if (isHeadisChar '[' bracket) then recBrackets tail bracket.Tail
                else false
            elif head = '}' then
                if (isHeadisChar '{' bracket) then recBrackets tail bracket.Tail
                else false
            else
                recBrackets tail bracket
        | [] -> bracket = [] 

    recBrackets string List<char>.Empty

printfn "Put string:"
let list = List.ofArray (System.Console.ReadLine().ToCharArray())
printfn "It's - %b" (brackets list)