﻿open System.ComponentModel

let mutable result = 0
let array = Array.create 1000001 1
let flags = Array.create 100 false
//let array = [for x in 1..1000000 -> 1]
    
type PlusOneEvet (start) = 
    let number = 10000
    let worker = new BackgroundWorker()
    
    let completed = new Event<_>()
    let cancelled = new Event<_>()
    let error = new Event<_>()
    let progress = new Event<_>()
    
    do worker.DoWork.Add(
        fun args -> 
            System.Threading.Thread.Sleep 100
            let rec add num =
                if worker.CancellationPending then
                    args.Cancel <- true
                elif num < start + number then
                    result <- result + (array.[num])
                    add (num + 1)
                else
                    args.Result <- result 
                    flags.[start / 10000] <- true 
            add start  
        )

    do worker.RunWorkerCompleted.Add(fun args ->
        if args.Cancelled then cancelled.Trigger ()
        elif args.Error <> null then error.Trigger args.Error
        else completed.Trigger (args.Result :?> int))

    do worker.ProgressChanged.Add(fun args ->
        progress.Trigger (args.ProgressPercentage, (args.UserState :?> 'a)))

    member x.WorkerCompleted = completed.Publish
    member x.WorkerCancelled = cancelled.Publish
    member x.WorkerError = error.Publish
    member x.ProgressChanged = progress.Publish

    member x.RunWorkerAsync() = worker.RunWorkerAsync()
    member x.CancelAsync() = worker.CancelAsync()
 
let list = [for i in 0..99 -> new PlusOneEvet(1 + i * 10000)]
for i in 0..99 do
    (list.Item i).RunWorkerAsync()
    
let isAllTrue mas =
    let mutable temp = true
    for i in 0..(min((Array.length mas) - 1)  99) do
        if mas.[i] = false then
            temp <- false
    not temp    
    
while (isAllTrue flags) do ()
    
printfn "%d" result