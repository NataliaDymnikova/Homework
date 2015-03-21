/// Type Tree
type Tree<'a> =
    | Node of 'a
    | Tree of Tree<'a> * 'a * Tree<'a>
    | Empty

/// Interface Iterator
type IIterator<'a> =
    abstract Current : 'a
    abstract MoveNext : bool

/// Binary Search Tree
type TreeClass<'a when 'a : comparison> (tree : Tree<'a> )= 
    let tree = tree
    new() = TreeClass(Tree.Empty)
    
    /// Get tree
    member t.GetTree = tree

    /// Exist or not
    member t.IsExist number =
        let rec recIsExist number tree = 
            match tree with
            | Empty -> false
            | Node node -> node = number
            | Tree (left, node, right) ->
                if node > number then
                    recIsExist number left
                elif node < number then
                    recIsExist number right
                else 
                    true
        recIsExist number tree

    /// Add number
    member t.Add number =
        let rec recAdd number tree =
            match tree with
            | Empty ->
                Node number
            | Node node ->
                if node > number then
                    Tree.Tree(Node number, node, Empty)
                else
                    Tree.Tree(Empty, node, Node number)
            | Tree (left, node, right) ->
                if node > number then
                    Tree(recAdd number left, node, right)
                else
                    Tree(left, node, recAdd number right)

        if t.IsExist number then
            t
        else
            new TreeClass<'a>(recAdd number tree)

    /// Delete number
    member t.Delete number = 
        let rec recSearchRight tree =
            match tree with
            | Empty -> Empty
            | Node node -> Node(node)
            | Tree (l,n,r) -> 
                if r = Empty then r
                else recSearchRight r

        let rec recDelete number tree = 
            match tree with
            | Empty -> tree     // Not exist
            | Node node -> 
                if node = number then   // Delete from Node
                    Empty
                else    // Not exist
                    tree    
            | Tree (left, node, right) ->
                if node = number then   // Delete here
                    match left with
                    | Empty -> right    // Left is empty
                    | Node nodeL ->     // Left is Node. Add to right and return right
                        let newT = TreeClass(right)
                        (newT.Add nodeL).GetTree
                    | Tree (leftL, nodeL, rightL) ->    // Left is tree
                        let rightLL = recSearchRight leftL  // Real right value in left
                        match rightLL with
                        | Empty -> Tree (leftL, nodeL, right)   
                        | Node node -> Tree (recDelete node leftL, node, right)
                        | _ -> tree
                elif node > number then
                    recDelete number left
                else
                    recDelete number right

        if t.IsExist number then
            new TreeClass<'a>(recDelete number tree)
        else
            t
    
    /// Convert Tree to List
    member t.TreeToList =
        let rec recTreeToList (tree : Tree<'a>) (list : List<'a>) = 
            match tree with
            | Empty -> list
            | Node node -> [node]
            | Tree (left, node, right) ->
                let r = recTreeToList right list
                let l = recTreeToList left list
                List.append l (node::r)
        recTreeToList tree List.Empty

    /// Iterator
    member t.GetIterator = 
        let list = ref t.TreeToList
        { new IIterator<'a> with
            member x.Current = List.head !list
            member x.MoveNext = 
                match !list with
                | h::t ->
                    if t = [] then
                        false
                    else
                        list := t
                        true
                | [] -> false
        }

// Check
let treeEmpty = new TreeClass<int>()
let tree = ((((((treeEmpty.Add 3).Add 1).Add 2).Add 5).Add 4).Add 6)
let list = tree.TreeToList
printfn "0 is exist - %A" (tree.IsExist 0)
printfn "1 is Exist - %A" (tree.IsExist 1)
printfn "1 after delete is exist - %A" ((tree.Delete 1).IsExist 1)
printfn "5 is exist - %A" (tree.IsExist 5)
printfn "5 after delete is exist - %A" ((tree.Delete 5).IsExist 5)
printfn ""

let iter = tree.GetIterator
let rec printIterator (iter : IIterator<int>) =
    printf "%A " iter.Current
    if iter.MoveNext then
        printIterator iter

printIterator iter