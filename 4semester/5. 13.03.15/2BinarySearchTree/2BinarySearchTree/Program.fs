type Tree<'a> =
    | Node of 'a
    | Tree of Tree<'a> * 'a * Tree<'a>
    | Empty

type IIterator<'a> =
    abstract Current : 'a
    abstract MoveNext : bool

type TreeClass<'a when 'a : equality> ()= 
    let tree = Tree.Empty

    member t.IsExist number =
        let rec recIsExist number tree = 
            match tree with
            | Empty -> false
            | Node node -> node = number
            | Tree (left, node, right) ->
                if node > number then
                    recIsExist number left
                else
                    recIsExist number right
        recIsExist number tree

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
            tree
        else
            recAdd number tree

    member t.Delete number = 
        let rec recDelete number tree = 
            match tree with
            | Empty -> tree
            | Node node -> 
                if node = number then
                    Empty
                else
                    tree
            | Tree (left, node, right) ->
                if node = number then
                    // Уьейся!!!!
                    tree
                elif node > number then
                    recDelete number left
                else
                    recDelete number right

        if t.IsExist number then
            recDelete number tree
        else
            tree
    
    member t.TreeToList =
        let rec recTreeToList (tree : Tree<'a>) (list : List<'a>) = 
            match tree with
            | Empty -> list
            | Node node -> [node]
            | Tree (left, node, right) ->
                let r = recTreeToList right list
                let l = node::(recTreeToList right list)
                List.append r l
        recTreeToList tree List.Empty

    member t.GetIterator = 
        let list = ref t.TreeToList
        { new IIterator<'a> with
            member x.Current = List.head !list
            member x.MoveNext = 
                match !list with
                | h::t ->
                    list := t
                    true
                | [] -> false
        }

