/// Binary tree
type Tree<'a> = 
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Node of 'a

/// Filter of tree
let rec filter (condition : 'a -> bool) (tree : Tree<'a>)= 
    match tree with
    | Node node -> 
        if condition node then
            [node]
        else
            []
    | Tree (node, left, right) ->
        if condition node then
            node :: (filter condition left) @ (filter condition right)
        else
            (filter condition left) @ (filter condition right)

let tree = Tree(1, Tree(2, Tree.Node(3), Tree.Node(4)), Tree.Node(5))
printfn "%A" (filter (fun x -> x % 2 = 0) tree)