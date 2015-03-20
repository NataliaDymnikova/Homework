/// OS
type OSEnum =
    | Windows = 1
    | Linux = 2
let OS = [(OSEnum.Windows, 50); (OSEnum.Linux, 75)]

/// Type of Computers - can try to infect, has member isInfect.
type Computer (os : OSEnum, isInfect : bool) =
    let protection = 
        let rec recProtection list = 
            match list with
            | h::t -> 
                let name, number = h
                if name = os then
                    number
                else
                    recProtection t
            | _ -> 100
        recProtection OS

    let mutable isInfectMy =  isInfect
    member c.Protection = protection
    member c.IsInfect = isInfectMy

    member c.TryToInfect = 
        if not isInfect then
            let r = System.Random().Next(1, 100)
            if r < c.Protection then
                isInfectMy <- true
          
    
/// Initialization network
let network = [|for x in 0..3 -> [|for y in 0..3 -> false|]|]
network.[0].[1] <- true
network.[1].[0] <- true
network.[2].[1] <- true
network.[1].[2] <- true
network.[3].[2] <- true
network.[2].[3] <- true

/// Initialization computers
let computers = [new Computer(OSEnum.Windows, false); new Computer(OSEnum.Linux, true);new Computer(OSEnum.Linux, false); new Computer(OSEnum.Windows, false)]

/// Check is all infect.
let isAllInfect (computers : List<Computer>) =
    let infects = List.filter (fun (x: Computer) -> x.IsInfect) computers
    if infects.Length = computers.Length then true
    else false

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