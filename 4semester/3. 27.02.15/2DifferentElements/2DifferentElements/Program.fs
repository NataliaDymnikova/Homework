/// Return true if all elements are different, false - otherwise.
let isDifferentAllElements list = 
    let rec isDifferentThis list currentElement = 
        match list with
        | head::tail -> if currentElement <> head then 
                            isDifferentThis tail currentElement
                        else
                            false
        | [] -> true

    let rec isDifferentAll list = 
        match list with
        | head::tail -> if not (isDifferentThis tail head) then false
                        else isDifferentAll tail
        | [] -> true

    isDifferentAll list

printfn "Put list:"
let list = List.map (fun x -> int <| x) (List.ofArray (System.Console.ReadLine().Split(' ')))
printfn "All elements are different is %b" (isDifferentAllElements list)