open Computers
open Network

/// Make one step.
let oneStep (computers : List<Computer>)=
    let rec recOneStep (computers : List<Computer>) (isInfectBefore : bool) (previous : int) (current : int) : bool =
        match computers with
        | h::t ->
            let isInfectNow = h.IsInfect
            if previous = current then // In the begin
                if (recOneStep t isInfectNow previous (current + 1)) then
                    h.TryToInfect
                isInfectNow
            elif network.[previous].[current] = false then // Don't closest
                recOneStep t isInfectBefore previous (current + 1)
            elif isInfectBefore then // Was infect before
                h.TryToInfect
                if (recOneStep t isInfectNow current (current + 1)) then
                    h.TryToInfect
                isInfectNow
            elif (recOneStep t isInfectNow current (current + 1)) then // Wasn't infect before, but next is infect
                h.TryToInfect
                isInfectNow
            else 
                isInfectNow
        | [] -> false
                
    recOneStep computers false 0 0

/// Print - true or false - computer is infect
let rec print (computers : List<Computer>) =
    match computers with
    | h::t -> printf "%A " h.IsInfect; print t
    | [] -> printfn" "

/// Main. While all computers are not infect
let rec go computers = 
    if not (isAllInfect computers) then
        oneStep computers |> ignore
        print computers
        go computers

go computers