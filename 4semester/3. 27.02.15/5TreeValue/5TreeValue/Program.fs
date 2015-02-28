type Sign = char
type Number = int
type ParseTree =
    | Node of Number
    | ParseTree of Sign * ParseTree * ParseTree

/// Return value of parse tree.
let rec value tree = 
    match tree with
    | ParseTree('+', left, right) -> (value left) + (value right)
    | ParseTree('-', left, right) -> (value left) - (value right)
    | ParseTree('*', left, right) -> (value left) * (value right)
    | ParseTree('/', left, right) -> (value left) / (value right)
    | Node x -> x
    | _ -> 0

let tree = ParseTree('+', ParseTree('-', Node 5, Node 1), ParseTree('*', Node 1, Node 3))
printfn "Value: %d" (value tree)