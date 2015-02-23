/// Convert list and print to console.
let ConvertList =
    let listFirst :list<int> = [1; 2; 1; 3]

    let rec func previousList = 
        match previousList with
        | head::tail -> List.append (func tail) [head] 
        | [] -> []

    List.iter (fun x -> printfn "%d " x) (func listFirst)            
    