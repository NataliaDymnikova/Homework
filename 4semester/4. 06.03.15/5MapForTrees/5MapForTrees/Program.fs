type Tree<'a> = 
    | Leaf of 'a
    | Tree of 'a * Tree<'a> * Tree<'a>

/// Map for trees.
let rec mapForTrees (func: 'a->'b) (tree: Tree<'a>) = 
    match tree with
    | Leaf leaf -> Leaf(func leaf)
    | Tree (value, left, right) -> Tree(func value, mapForTrees func left, mapForTrees func right)

/// Convert tree to string
let rec treeToString tree = 
    match tree with
    | Leaf leaf -> leaf.ToString() + " "
    | Tree (value, left, right) -> (treeToString left).ToString() + value.ToString() + " " + (treeToString right).ToString()

let tree = Tree(5, Tree(2, Leaf(1), Leaf(3)), Leaf(9))
let func = (*) 2
printfn "%s" (treeToString tree)
printfn "%s" (treeToString (mapForTrees func tree))
    

