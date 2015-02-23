/// Convert list and print to console.
let ConvertList =
    let rec func previousList = 
        match previousList with
        | head::tail -> List.append (func tail) [head] 
        | [] -> []
    
    printfn "Put list:"
    let list = List.map (fun x -> int <| x) (List.ofArray (System.Console.ReadLine().Split(' ')))
    List.iter (fun x -> printf "%d " x) (func list)            
    