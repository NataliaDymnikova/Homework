open System
open System.Collections.Generic

/// Exception of empty queue
exception ErrorEmpty of string

/// Queue with priority
type QueueWithPriority () =
    let mutable queue : list<(int * list<'a>)> = []

    // Add new number with priority
    member this.Add number (priority : int) =
        let rec recAdd (number : 'a) (priority : int) (qList : list<(int * list<'a>)>) =
            match qList with
            | h::t -> 
                let prior,listPrior = h
                if prior = priority then
                    [(priority, listPrior @ [number])] @ t
                elif priority > prior then
                    h :: recAdd number priority t
                else
                    h :: [(priority, [number])] @ t
           
            | [] -> [(priority, [number])]

        queue <- recAdd number priority queue

    /// Get first number. Throw exceprion if queue is empty
    member this.GetValue =
        match queue with
        | h::t ->
            let prior,listPrior = h
            match listPrior with
            | returnVal::tail -> 
                if tail = [] then
                    queue <- t
                else
                    queue <- (prior, tail)::t
                returnVal
            | [] -> raise(ErrorEmpty("Empty queue"))
        | [] -> raise(ErrorEmpty("Empty queue"))

    /// Get list
    member this.List =
        let rec reclist partOfqueue =
            match partOfqueue with
            | h::t  ->
                let prior,listPrior = h
                listPrior @ reclist t
            | [] -> []
        reclist queue


let queue = QueueWithPriority()
queue.Add 1 1
queue.Add 2 3
queue.Add 3 2
queue.Add 4 1

let list = queue.List
printfn "%A" list

try
    printfn "%d" queue.GetValue
    printfn "%d" queue.GetValue
    printfn "%d" queue.GetValue
    printfn "%d" queue.GetValue
    printfn "%d" queue.GetValue
with
    | ErrorEmpty(msg) -> printfn "Error! - %s" msg
