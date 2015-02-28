type Tree<'a> = 
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Node of 'a

/// Return height of Tree.
let heightOfTree tree =
    let rec height tree result =
        match tree with
        | Tree(_, left, right) -> max (height left (result + 1)) (height right (result + 1))
        | Node _ -> result
    height tree 1

let tree = Tree(1, Tree(2, Tree.Node(3), Tree.Node(4)), Tree.Node(5))
printfn "Height of tree: %d" (heightOfTree tree)
