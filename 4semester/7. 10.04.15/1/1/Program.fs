open System.ComponentModel

let mutable result = 0

type PlusOneEvet (array : int list, start) = 
    let number = 10000
    let worker = new BackgroundWorker()
    
    let completed = new Event<_>()
    let cancelled = new Event<_>()
    
    do worker.RunWorkerCompleted.Add(fun args ->
        if args.Cancelled then cancelled.Trigger ()
        else completed.Trigger (args.Result :?> int))

    do worker.DoWork.Add(
        fun args -> 
            let rec add num =
                if worker.CancellationPending then
                    args.Cancel <- true
                elif num < start + number then
                    result <- result + (array.Item num)
                    add (num - 1)
                else
                    args.Result <- result    
            add start  
        )
    
    member x.WorkerCompleted = completed.Publish
    member x.WorkerCancelled = cancelled.Publish
    
    member x.RunWorkerAsync() = worker.RunWorkerAsync()
    member x.CancelAsync() = worker.CancelAsync()
 
let mas = [for x in 1..1000000 -> 1]
let list = [for i in 0..99 -> new PlusOneEvet(mas, 1 + i * 10000)]
for i in 0..99 do
    (list.Item i).RunWorkerAsync()

printfn "%d" result