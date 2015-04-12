open Computers
open Network

/// Make one step.
let oneStep (computers : List<Computer>)=
    let tempComputers = List.map (fun (x:Computer) -> x.Copy()) computers
    for i in 0..size do
        if (computers.Item i).IsInfect then
            for j in 0..size do
                if network.[i].[j] then
                    (tempComputers.Item j).TryToInfect
    tempComputers
            
/// Print - true or false - computer is infect
let rec print (computers : List<Computer>) =
    match computers with
    | h::t -> printf "%A " h.IsInfect; print t
    | [] -> printfn" "

/// Main. While all computers are not infect
let rec go computers = 
    print computers
    if not (isAllInfect computers) then
        let tempComputers = oneStep computers
        go tempComputers

go computers