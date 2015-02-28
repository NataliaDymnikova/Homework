/// Return index of max sum two adjacent elements in listю
let  positionOfMaxSum list = 
    let rec position list currentIndex resultIndex resultSum = 
        match list with
        | head::tail when tail <> [] -> if (head + tail.Head) > resultSum then
                                            position tail (currentIndex + 1) currentIndex (head + tail.Head)
                                        else
                                            position tail (currentIndex + 1) resultIndex resultSum
        | _ -> resultIndex

    position list 1 -1 -1

printfn "Put list:"
let list = List.map (fun x -> int <| x) (List.ofArray (System.Console.ReadLine().Split(' ')))
printfn "Position of max sum: %d" (positionOfMaxSum list)