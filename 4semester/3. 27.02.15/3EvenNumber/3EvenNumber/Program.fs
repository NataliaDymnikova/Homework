let numberOfEvenNumberByMap list = 
    List.length (List.concat (List.map (fun x -> if x % 2 = 0 then [x] else []) list))

let numberOfEvenNumberByFilter list = 
    List.length (List.filter (fun x -> x % 2 = 0) list)
    
let numberOfEvenNumberByFold list = 
    List.fold (fun acc x -> if x % 2 = 0 then (acc + 1) else acc) 0 list

printfn "Put list:"
let list = List.map (fun x -> int <| x) (List.ofArray (System.Console.ReadLine().Split(' ')))
printfn "Number of even numbers "
printfn "by map: %d" (numberOfEvenNumberByMap list)
printfn "by filter: %d" (numberOfEvenNumberByFilter list)
printfn "by fold: %d" (numberOfEvenNumberByFold list)