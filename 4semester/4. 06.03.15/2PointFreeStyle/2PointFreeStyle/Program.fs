let func x l = List.map (fun y -> y * x) l
let func2 x : List<int> -> List<int> = List.map (fun y -> y * x)
let func3 : int -> List<int> -> List<int> = (fun y -> (*) y) >> List.map
let func4 : int -> List<int> -> List<int> = ((*)) >> List.map 

printfn "Put list"
let list = List.map (int) (List.ofArray (System.Console.ReadLine().Split(' ')))

List.iter (printf "%d ") (func 2 list)
printfn ""
List.iter (printf "%d ") (func2 2 list)
printfn ""
List.iter (printf "%d ") (func3 2 list)
printfn ""
List.iter (printf "%d ") (func4 2 list)
printfn ""

