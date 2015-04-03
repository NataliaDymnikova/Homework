/// Return Fibbonacci
let rec Fibbonacci num =
    if num <= 1
    then 1
    else Fibbonacci (num - 2) + Fibbonacci (num - 1)

/// Return sum of first million Fibbonacci numbers
let SumFib =
    let rec recSumFib num =
        let numFib = Fibbonacci num
        if numFib > 1000000 then
            0
        elif numFib % 2 = 0 then
            recSumFib (num + 1) + numFib
        else
        recSumFib (num + 1)
    recSumFib 1

printfn "%d" SumFib